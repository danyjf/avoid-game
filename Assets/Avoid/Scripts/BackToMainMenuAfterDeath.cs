using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMainMenuAfterDeath : MonoBehaviour {

	private GameObject player;

	private GameObject levelChanger;
	private LevelChanger levelChangerScript;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");

		levelChanger = GameObject.Find("LevelChanger");
		levelChangerScript = levelChanger.GetComponent<LevelChanger>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!player)
		{
			StartCoroutine(GoToMainMenu());
		}
	}

	private IEnumerator GoToMainMenu()
	{
		yield return new WaitForSeconds(1.3f);

		levelChangerScript.FadeToLevel(0);
	}
}
