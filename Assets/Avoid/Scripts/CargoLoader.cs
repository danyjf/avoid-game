using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CargoLoader : MonoBehaviour
{

	GameObject gameManager;
	GameManager gameManagerScript;

	// Use this for initialization
	void Awake()
	{
		gameManager = GameObject.Find("GameManager");
		gameManagerScript = gameManager.GetComponent<GameManager>();

		if (File.Exists(Application.persistentDataPath + "/cargo.save"))
		{
			gameManagerScript.LoadCargoValue();

			Debug.Log("File exists");
		}
		else
		{
			gameManagerScript.SaveCargoValue();

			Debug.Log("File doesn't exist");
		}

		if (File.Exists(Application.persistentDataPath + "/gundamage.save"))
		{
			gameManagerScript.LoadGunDamage();

			Debug.Log("File exists");
		}
		else
		{
			gameManagerScript.SaveGunDamage();

			Debug.Log("File doesn't exist");
		}
	}
}
