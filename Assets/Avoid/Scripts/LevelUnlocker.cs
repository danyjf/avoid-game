using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUnlocker : MonoBehaviour {


	private GameObject RedRockUI;
	private ResourcesDisplay RedRockScript;

	public static bool level2Unlocked = false;
	public static bool level3Unlocked = false;
	public static bool level4Unlocked = false;
	public static bool level5Unlocked = false;
	public static bool level6Unlocked = false;
	public static bool level7Unlocked = false;

	public GameObject lvl2UnlockButton;
	public GameObject lvl3UnlockButton;
	public GameObject lvl4UnlockButton;
	public GameObject lvl5UnlockButton;
	public GameObject lvl6UnlockButton;
	public GameObject lvl7UnlockButton;

	public int lvl2UnlockCost = 125;
	public int lvl3UnlockCost = 150;
	public int lvl4UnlockCost = 175;
	public int lvl5UnlockCost = 200;
	public int lvl6UnlockCost = 225;
	public int lvl7UnlockCost = 250;

	private void Start()
	{
		RedRockUI = GameObject.Find("Red Rock UI");
		RedRockScript = RedRockUI.GetComponentInChildren<ResourcesDisplay>();
	}

	private void Update()
	{
		if (level2Unlocked == true)
		{
			Destroy(lvl2UnlockButton);
		}

		if (level3Unlocked == true)
		{
			Destroy(lvl3UnlockButton);
		}

		if (level4Unlocked == true)
		{
			Destroy(lvl4UnlockButton);
		}

		if (level5Unlocked == true)
		{
			Destroy(lvl5UnlockButton);
		}

		if (level6Unlocked == true)
		{
			Destroy(lvl6UnlockButton);
		}

		if (level7Unlocked == true)
		{
			Destroy(lvl7UnlockButton);
		}
	}

	public void UnlockLvl2()
	{
		if(ResourcesDisplay.redRockQuantity >= lvl2UnlockCost)
		{
			RedRockScript.SpendRock(lvl2UnlockCost);
			level2Unlocked = true;
		}
	}

	public void UnlockLvl3()
	{
		if(level2Unlocked == true && ResourcesDisplay.redRockQuantity >= lvl3UnlockCost)
		{
			RedRockScript.SpendRock(lvl3UnlockCost);
			level3Unlocked = true;
		}
	}

	public void UnlockLvl4()
	{
		if (level3Unlocked == true && ResourcesDisplay.redRockQuantity >= lvl4UnlockCost)
		{
			RedRockScript.SpendRock(lvl4UnlockCost);
			level4Unlocked = true;
		}
	}

	public void UnlockLvl5()
	{
		if(level4Unlocked == true && ResourcesDisplay.redRockQuantity >= lvl5UnlockCost)
		{
			RedRockScript.SpendRock(lvl5UnlockCost);
			level5Unlocked = true;
		}
	}

	public void UnlockLvl6()
	{
		if(level5Unlocked == true && ResourcesDisplay.redRockQuantity >= lvl6UnlockCost)
		{
			RedRockScript.SpendRock(lvl6UnlockCost);
			level6Unlocked = true;
		}
	}

	public void UnlockLvl7()
	{
		if(level6Unlocked == true && ResourcesDisplay.redRockQuantity >= lvl7UnlockCost)
		{
			RedRockScript.SpendRock(lvl7UnlockCost);
			level7Unlocked = true;
		}
	}
}
