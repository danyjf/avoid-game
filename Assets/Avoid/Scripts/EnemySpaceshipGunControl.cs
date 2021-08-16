using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaceshipGunControl : MonoBehaviour {

	GameObject player;
	Vector3 playerPos;
	Vector3 playerDirection;

	public float projectileSpawnTime = 3f;

	public float projectileSpeed = 3f;

	private GameObject projectileClone;

	public GameObject projectile;

	private GameObject projectileSpawner;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");

		projectileSpawner = this.gameObject.transform.GetChild(0).gameObject;

		StartCoroutine(TimeToShootProjectile());
	}

	// Update is called once per frame
	void Update () {	
		if(player != null)
		{
			playerPos = player.transform.position;

			playerDirection = Vector3.Normalize(playerPos - this.transform.position);

			if(playerDirection.y > 0)
			{
				transform.eulerAngles = new Vector3(0, 0, Mathf.Acos(playerDirection.x) * Mathf.Rad2Deg);
			}
			else
			{
				transform.eulerAngles = new Vector3(0, 0, - (Mathf.Acos(playerDirection.x) * Mathf.Rad2Deg));
			}
		}

		if(projectileClone != null)
		{
			projectileClone.GetComponent<Rigidbody2D>().velocity = playerDirection * projectileSpeed;
		}
	}

	void SpawnProjectile()
	{
		projectileClone = Instantiate(projectile, projectileSpawner.transform.position, Quaternion.identity) as GameObject;
	}

	private IEnumerator TimeToShootProjectile()
	{
		yield return new WaitForSeconds(projectileSpawnTime);
		SpawnProjectile();
		StartCoroutine(TimeToShootProjectile());
	}
}
