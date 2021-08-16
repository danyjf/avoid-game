using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData {

    public float trailLength;

    public PlayerData(GameManager gameManager)
    {
        trailLength = gameManager.trailLength;
    }
}
