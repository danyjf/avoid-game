using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
	public GameObject projectileDestructionParticles;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			Debug.Log(other);
		}
		else if(other.tag == "EnemyProjectile")
		{
			Instantiate(projectileDestructionParticles, this.transform.position, Quaternion.identity);
			Destroy(other.gameObject);
		}
		else
		{
			Instantiate(projectileDestructionParticles, this.transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		}
	}
}
