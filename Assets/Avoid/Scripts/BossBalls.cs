using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBalls : MonoBehaviour {

	private GameObject boss;
	private EnemyHealthBar enemyHealthBar;
	public GameObject destructionParticleSystem;

	private void Start()
	{
		boss = GameObject.Find("EnemyBoss");
		enemyHealthBar = boss.gameObject.transform.GetChild(1).GetComponent<EnemyHealthBar>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "PlayerProjectile")
		{
			boss.GetComponent<EnemyScript>().enemyHealth -= 25;
			enemyHealthBar.SetSize(boss.GetComponent<EnemyScript>().enemyHealth / boss.GetComponent<EnemyScript>().enemyMaxHealth);
			boss.gameObject.transform.GetChild(1).gameObject.SetActive(true);

			Instantiate(destructionParticleSystem, this.gameObject.transform.position, Quaternion.identity);
			Destroy(this.gameObject);
			Destroy(other.gameObject);
		}
	}
}
