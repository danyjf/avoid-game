using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class UpgradeLevelLoader : MonoBehaviour {

    GameObject gameManager;
    GameManager gameManagerScript;

    // Use this for initialization
    void Start () {
		gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();

        if (File.Exists(Application.persistentDataPath + "/upgradelvl.save"))
        {
            gameManagerScript.LoadUpgradeLvl();

            Debug.Log("File exists");
        }
        else
        {
            gameManagerScript.SaveUpgradeLvl();

            Debug.Log("File doesn't exist");
        }

        if(File.Exists(Application.persistentDataPath + "/health.save"))
        {
            gameManagerScript.LoadHealthValue();

            Debug.Log("File exists");
        }
        else
        {
            gameManagerScript.SaveHealthValue();

            Debug.Log("File doesn't exist");
        }
    }
}
