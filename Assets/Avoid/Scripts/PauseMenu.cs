using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	private GameObject pauseMenu;

	private void Start()
	{
		pauseMenu = gameObject.transform.GetChild(0).gameObject;
	}

	public void Pause()
	{
		Time.timeScale = 0;
		pauseMenu.SetActive(true);
	}

	public void Resume()
	{
		Time.timeScale = 1;
		pauseMenu.SetActive(false);
	}
}
