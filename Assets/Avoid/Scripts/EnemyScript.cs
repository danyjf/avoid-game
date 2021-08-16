using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	private EnemyHealthBar enemyHealthBar;

	public GameObject destructionParticleSystem;

	public float enemyMaxHealth = 30f;
	public float enemyHealth = 30f;
	public static float playerProjectileDamage = 3f;

	private void Start()
	{
		enemyHealthBar = this.gameObject.transform.GetChild(1).GetComponent<EnemyHealthBar>();

		this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
	}

	private void Update()
	{
		if(enemyHealth <= 0f)
		{
			Instantiate(destructionParticleSystem, this.gameObject.transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "PlayerProjectile")
		{
			enemyHealth -= playerProjectileDamage;

			enemyHealthBar.SetSize(enemyHealth / enemyMaxHealth);

			this.gameObject.transform.GetChild(1).gameObject.SetActive(true);

			Debug.Log(enemyHealth);
		}
	}
}
