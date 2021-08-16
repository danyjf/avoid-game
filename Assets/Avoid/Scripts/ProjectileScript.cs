using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileScript : MonoBehaviour {

	public int projectileDamage = 5;

	private GameObject healthSlider;

	public GameObject projectileDestructionParticles;

	// Use this for initialization
	void Start () {
		healthSlider = GameObject.Find("HealthSlider");
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Wall" || other.tag == "Wormhole")
		{
			Instantiate(projectileDestructionParticles, this.transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		}
		else if(other.tag == "Player")
		{
			PlayerScript.health -= projectileDamage;
			healthSlider.GetComponent<Slider>().value = PlayerScript.health;

			Instantiate(projectileDestructionParticles, this.transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		}
	}
}
