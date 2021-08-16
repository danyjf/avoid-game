using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    public int collectorLengthLvl;

    public int shieldLvl;

	public int cargoLvl;

	public int gunLvl;

    public LevelData(GameManager gameManager)
    {
        collectorLengthLvl = gameManager.collectorLengthLvl;
        shieldLvl = gameManager.shieldLvl;
		cargoLvl = gameManager.cargoLvl;
		gunLvl = gameManager.gunLvl;
    }
}
