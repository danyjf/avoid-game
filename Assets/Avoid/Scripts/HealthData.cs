﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HealthData{

    public float health;

    public HealthData(GameManager gameManager)
    {
        health = gameManager.health;
    }
}
