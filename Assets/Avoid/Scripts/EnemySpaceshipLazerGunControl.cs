using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaceshipLazerGunControl : MonoBehaviour {

	GameObject player;
	Vector3 playerPos;
	Vector3 playerDirection;

	private bool canRotate;
	public float stopGunTimeMin = 2f;
	public float stopGunTimeMax = 4f;
	public float projectileSpawnTime = 1f;

	public float angularSpeed = 90f;

	public GameObject projectile;

	private GameObject projectileClone;

	private GameObject projectileSpawner;

	// Use this for initialization
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");

		projectileSpawner = this.gameObject.transform.GetChild(0).gameObject;

		canRotate = true;

		StartCoroutine(TimeToStopGun());
	}

	// Update is called once per frame
	void Update () {
		if (player != null)
		{
			if (canRotate == true)
			{
				playerPos = player.transform.position;

				playerDirection = Vector3.Normalize(playerPos - this.transform.position);

				if (playerDirection.y > 0)
				{
					float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, Mathf.Acos(playerDirection.x) * Mathf.Rad2Deg, angularSpeed * Time.deltaTime);
					transform.eulerAngles = new Vector3(0, 0, angle);
				}
				else
				{
					float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, -Mathf.Acos(playerDirection.x) * Mathf.Rad2Deg, angularSpeed * Time.deltaTime);
					transform.eulerAngles = new Vector3(0, 0, angle);
				}
			}
		}
	}

	void SpawnProjectile()
	{
		projectileClone = Instantiate(projectile, projectileSpawner.transform.position, Quaternion.identity);

		projectileClone.transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + 180);
	}

	private IEnumerator TimeToStopGun()
	{
		yield return new WaitForSeconds(Random.Range(stopGunTimeMin, stopGunTimeMax));
		canRotate = false;
		StartCoroutine(TimeToShootProjectile());
	}

	private IEnumerator TimeToShootProjectile()
	{
		yield return new WaitForSeconds(projectileSpawnTime);
		SpawnProjectile();
		canRotate = true;
		StartCoroutine(TimeToStopGun());
	}
}
