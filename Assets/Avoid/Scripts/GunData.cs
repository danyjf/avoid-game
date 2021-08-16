using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GunData{

	public float gunDamage;

	public GunData(GameManager gameManager)
	{
		gunDamage = gameManager.gunDamage;
	}
}
