using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlayerScript : MonoBehaviour {

	private GameObject player;

    [SerializeField]
    private float _rockSpawnTime = 5.0f;

    [SerializeField]
    private GameObject enemy;

    private Vector3[] sideToSpawn = new Vector3[4];

	public GameObject destructionParticles;

    private GameObject levelChanger;
    private LevelChanger levelChangerScript;

    private GameObject gameManager;
    private GameManager gameManagerScript;

    GameObject trail;

    public GameObject healthSlider;

    public static float health = 30;

	int enemiesLeft = 0;

	GameObject[] enemies;

	private float projectileSpeed = 4f;

	public int projectileSpawnTime;

	private GameObject projectileClone;
	public GameObject projectile;
	private GameObject projectileSpawner;

	float distanceToClosestEnemy;

	GameObject closestEnemy = null;

	GameObject[] enemySpawners;

	SpawnPoints spawnPoints;

	private void Awake()
	{
		StartCoroutine(turnOffCollider());
	}

	// Use this for initialization
	void Start() {
		player = GameObject.FindGameObjectWithTag("Player");

		gameManager = GameObject.Find("GameManager");
		gameManagerScript = gameManager.GetComponent<GameManager>();

		levelChanger = GameObject.Find("LevelChanger");
		levelChangerScript = levelChanger.GetComponent<LevelChanger>();

		enemies = GameObject.FindGameObjectsWithTag("Enemy");

		if (player != null)
		{
			projectileSpawner = this.gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject;
		}

        if(healthSlider != null)
        {
            healthSlider.GetComponent<Slider>().maxValue = health;
            healthSlider.GetComponent<Slider>().value = health;
        }

		StartCoroutine(TimeToSpawnRock());
		StartCoroutine(TimeToShootProjectile());

		if(player != null && GameObject.Find("EnemySpawner") != null)
		{
			PositionEnemies();
		}
	}

    // Update is called once per frame
    void Update () {
		trail = GameObject.FindGameObjectWithTag("Trail");

		Vector3 leftSpawn = new Vector3(-16f, Random.Range(-14f, 14f), -1.5f);
        Vector3 rightSpawn = new Vector3(16f, Random.Range(-14f, 14f), -1.5f);
        Vector3 upperSpawn = new Vector3(Random.Range(-14f, 14f), 16f, -1.5f);
        Vector3 downSpawn = new Vector3(Random.Range(-14f, 14f), -16f, -1.5f);

        sideToSpawn[0] = leftSpawn;
        sideToSpawn[1] = rightSpawn;
        sideToSpawn[2] = upperSpawn;
        sideToSpawn[3] = downSpawn;

		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		enemiesLeft = enemies.Length;

		FindClosestEnemy();

		if(enemiesLeft == 0)
		{
			if (player != null)
			{
				this.gameObject.transform.GetChild(2).transform.eulerAngles = new Vector3(this.gameObject.transform.eulerAngles.x, this.gameObject.transform.eulerAngles.y, this.gameObject.transform.eulerAngles.z + 90);

				this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
			}
		}
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Wall" || other.tag == "Trail")
        {
            Instantiate(destructionParticles, this.transform.position, Quaternion.identity);

			if (trail != null)
			{
				Destroy(trail.gameObject);
			}
			Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "RedRock")
        {
            health -= 3;
            healthSlider.GetComponent<Slider>().value = health;
        }
        else if(other.tag == "Wormhole")
        {
			gameManagerScript.SaveRedRockQuantity();

			levelChangerScript.FadeToLevel(0);
			Debug.Log("Go back to main menu");
		}
		else if(other.tag == "Enemy")
		{
			health -= other.gameObject.GetComponent<EnemyScript>().enemyHealth;
			healthSlider.GetComponent<Slider>().value = health;
		}

		if (health < 0)
        {
            Instantiate(destructionParticles, this.transform.position, Quaternion.identity);

			Destroy(other.gameObject);
			if (trail != null)
			{
				Destroy(trail.gameObject);
			}
			Destroy(this.gameObject);
        }
    }

    private void SpawnRock()
    {
        if(enemy != null)
        {
            Instantiate(enemy, sideToSpawn[Random.Range(0, 4)], Quaternion.identity);
        }
    }

    private IEnumerator TimeToSpawnRock()
    {
        yield return new WaitForSeconds(_rockSpawnTime);
        SpawnRock();
		StartCoroutine(TimeToSpawnRock());
    }

	void FindClosestEnemy()
	{
		distanceToClosestEnemy = Mathf.Infinity;
		closestEnemy = null;

		foreach (GameObject currentEnemy in enemies)
		{
			float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
			if (distanceToEnemy < distanceToClosestEnemy)
			{
				distanceToClosestEnemy = distanceToEnemy;
				closestEnemy = currentEnemy;
			}

			Vector3 enemyDirection = Vector3.Normalize(closestEnemy.transform.position - transform.position);
			if (distanceToClosestEnemy < 50)
			{
				if (enemyDirection.y > 0)
				{
					this.gameObject.transform.GetChild(2).transform.eulerAngles = new Vector3(0, 0, Mathf.Acos(enemyDirection.x) * Mathf.Rad2Deg);
				}
				else
				{
					this.gameObject.transform.GetChild(2).transform.eulerAngles = new Vector3(0, 0, -(Mathf.Acos(enemyDirection.x) * Mathf.Rad2Deg));
				}
			}
			else
			{
				this.gameObject.transform.GetChild(2).transform.eulerAngles = new Vector3(this.gameObject.transform.eulerAngles.x, this.gameObject.transform.eulerAngles.y, this.gameObject.transform.eulerAngles.z + 90);
			}
		}
	}

	void SpawnProjectile()
	{
		projectileClone = Instantiate(projectile, projectileSpawner.transform.position, Quaternion.identity) as GameObject;

		Vector3 enemyShootingDirection = Vector3.Normalize(closestEnemy.transform.position - transform.position);

		if (projectileClone != null)
		{
			projectileClone.GetComponent<Rigidbody2D>().velocity = enemyShootingDirection * projectileSpeed;
		}
	}

	private IEnumerator TimeToShootProjectile()
	{
		yield return new WaitForSeconds(projectileSpawnTime);
		if(distanceToClosestEnemy < 50)
		{
			SpawnProjectile();
		}
		StartCoroutine(TimeToShootProjectile());
	}

	private IEnumerator turnOffCollider()
	{
		yield return new WaitForSeconds(0.5f);

		if(player != null)
		{
			this.GetComponent<PolygonCollider2D>().enabled = !this.GetComponent<PolygonCollider2D>().enabled;
		}
	}

	private void PositionEnemies()
	{
		//create an array with all the spawners
		spawnPoints = GameObject.Find("EnemySpawner").GetComponent<SpawnPoints>();

		for (int i = 0; i < enemies.Length; i++)
		{
			//determine the number of spawners inside the enemySpawners array
			int availableSpawns = spawnPoints.SpawnPositions.Count;

			//sets the enemy position to the position of a random spawner
			var pickedSpawn = spawnPoints.SpawnPositions[Random.Range(0, availableSpawns)];
			enemies[i].transform.position = pickedSpawn;

			//destroy the picked spawner in which the enemy spawned
			spawnPoints.SpawnPositions.Remove(pickedSpawn);
		}
	}

	private IEnumerator GoToMainMenu()
	{
		yield return new WaitForSeconds(2f);

		levelChangerScript.FadeToLevel(0);
	}
}
