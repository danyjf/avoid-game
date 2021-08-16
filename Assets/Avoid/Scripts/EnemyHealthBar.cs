using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour {

	private Transform bar;

	// Use this for initialization
	void Start () {
		bar = transform.Find("Bar");
	}

	public void SetSize(float sizeNormalized)
	{
		if(bar != null)
		{
			bar.localScale = new Vector3(sizeNormalized, 1f);
		}
	}
}
