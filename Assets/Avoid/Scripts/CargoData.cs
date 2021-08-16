using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CargoData{

	public int cargo;

	public CargoData(GameManager gameManager)
	{
		cargo = gameManager.cargo;
	}
}
