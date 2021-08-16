using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileParticleSelfDestruct : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(SelfDestruct());
	}
	
	private IEnumerator SelfDestruct()
	{
		yield return new WaitForSeconds(1f);
		Destroy(this.gameObject);
	}
}
