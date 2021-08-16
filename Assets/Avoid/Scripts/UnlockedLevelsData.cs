using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnlockedLevelsData
{
	public bool level2Unlocked;
	public bool level3Unlocked;
	public bool level4Unlocked;
	public bool level5Unlocked;
	public bool level6Unlocked;
	public bool level7Unlocked;

	public UnlockedLevelsData(GameManager gameManager)
	{
		level2Unlocked = gameManager.level2Unlocked;
		level3Unlocked = gameManager.level3Unlocked;
		level4Unlocked = gameManager.level4Unlocked;
		level5Unlocked = gameManager.level5Unlocked;
		level6Unlocked = gameManager.level6Unlocked;
		level7Unlocked = gameManager.level7Unlocked;
	}
}
