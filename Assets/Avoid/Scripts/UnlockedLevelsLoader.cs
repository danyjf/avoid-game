using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class UnlockedLevelsLoader : MonoBehaviour {

	GameObject gameManager;
	GameManager gameManagerScript;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("GameManager");
		gameManagerScript = gameManager.GetComponent<GameManager>();

		if (File.Exists(Application.persistentDataPath + "/unlockedlevels.save"))
		{
			gameManagerScript.LoadUnlockedLevels();

			Debug.Log("File exists");
		}
		else
		{
			gameManagerScript.SaveUnlockedLevels();

			Debug.Log("File doesn't exist");
		}
	}
}
