using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RedRockData
{
    public int redRockQuantity;

    public RedRockData(GameManager gameManager)
    {
        redRockQuantity = gameManager.redRockQuantity;
    }
}
