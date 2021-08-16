using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour {

	private Transform target;

	public float speed = 4.5f;
	public float rotateSpeed = 150f;

	private Rigidbody2D rb;

	private GameObject healthSlider;

	public int projectileDamage = 15;

	public GameObject projectileDestructionParticles;

	// Use this for initialization
	void Start () {
		if(GameObject.FindGameObjectWithTag("Player") != null)
		{
			target = GameObject.FindGameObjectWithTag("Player").transform;
		}

		rb = GetComponent<Rigidbody2D>();

		healthSlider = GameObject.Find("HealthSlider");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(target != null)
		{
			Vector2 direction = (Vector2)target.position - rb.position;

			direction.Normalize();

			float rotateAmount = Vector3.Cross(direction, transform.up).z;

			rb.angularVelocity = -rotateAmount * rotateSpeed;

			rb.velocity = transform.up * speed;
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Wall" || other.tag == "Wormhole" || other.tag == "HomingMissile")
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
