using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class LoadDataScript : MonoBehaviour {

    GameObject gameManager;
    GameManager gameManagerScript;

   // Use this for initialization
    void Start () {
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();

        if (File.Exists(Application.persistentDataPath + "/player.save"))
        {
            gameManagerScript.LoadData();

            Debug.Log("File exists");
            Debug.Log(Application.persistentDataPath);
        }
        else
        {
            gameManagerScript.SaveData();

            Debug.Log("File doesn't exist");
        }

        if (File.Exists(Application.persistentDataPath + "/redrock.save"))
        {
            gameManagerScript.LoadRedRockQuantity();

            Debug.Log("File exists");
        }
        else
        {
            gameManagerScript.SaveRedRockQuantity();

            Debug.Log("File doesn't exist");
        }
    }
}
