using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LazerBeamScript : MonoBehaviour {

	private GameObject healthSlider;

	public int projectileDamage = 25;

	public int projectileDestroyTime = 2;

	private void Start()
	{
		healthSlider = GameObject.Find("HealthSlider");

		StartCoroutine(TimeToDestroyProjectile());
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			PlayerScript.health -= projectileDamage;
			healthSlider.GetComponent<Slider>().value = PlayerScript.health;
		}
	}


	private IEnumerator TimeToDestroyProjectile()
	{
		yield return new WaitForSeconds(projectileDestroyTime);
		Destroy(this.gameObject);
	}
}
