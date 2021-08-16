using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float trailLength;

    public int redRockQuantity;

    public GameObject Upgrader;
    public UpgraderScript UpgraderScript;

	//public GameObject levelUnlocker;
	//public LevelUnlocker levelUnlockerScript;

    public int collectorLengthLvl;

    public int shieldLvl;

	public int cargoLvl;

	public int gunLvl;

    public float health;

	public int cargo;

	public float gunDamage;

	public bool level2Unlocked;
	public bool level3Unlocked;
	public bool level4Unlocked;
	public bool level5Unlocked;
	public bool level6Unlocked;
	public bool level7Unlocked;

	// Use this for initialization
	void Start () {
        Debug.Log(TrailRendererWith2DCollider.lifeTime);

        Upgrader = GameObject.Find("Upgrader");
        if (Upgrader)
        {
            UpgraderScript = Upgrader.GetComponent<UpgraderScript>();
        }

		/*levelUnlocker = GameObject.Find("LevelUnlocker");
		if (levelUnlocker)
		{
			levelUnlockerScript = levelUnlocker.GetComponent<LevelUnlocker>();
		}*/
	}

    public void SaveData()
    {
        trailLength = TrailRendererWith2DCollider.lifeTime;
        SaveSystem.SaveGame(this);
        Debug.Log("Saving trail length");
    }

    public void LoadData()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        trailLength = data.trailLength;
        TrailRendererWith2DCollider.lifeTime = trailLength;

        Debug.Log("Loading data");
        Debug.Log(TrailRendererWith2DCollider.lifeTime);
        Debug.Log(Application.persistentDataPath);
    }

    public void SaveRedRockQuantity()
    {
        redRockQuantity = ResourcesDisplay.redRockQuantity;
        SaveSystem.SaveRedRockQuantity(this);
        Debug.Log("Saving red rock quantity");
    }

    public void LoadRedRockQuantity()
    {
        RedRockData data = SaveSystem.LoadRedRockQuantity();

        redRockQuantity = data.redRockQuantity;
        ResourcesDisplay.redRockQuantity = redRockQuantity;

        Debug.Log("Loading red rock quantity");
        Debug.Log(ResourcesDisplay.redRockQuantity);
    }

    public void SaveUpgradeLvl()
    {
        collectorLengthLvl = UpgraderScript.collectorLengthCurrentLevel;
        shieldLvl = UpgraderScript.shieldCurrentLevel;
		cargoLvl = UpgraderScript.cargoCurrentLevel;
		gunLvl = UpgraderScript.gunCurrentLevel;
        SaveSystem.SaveUpgradeLvl(this);

        Debug.Log("Saving upgrade lvl");
    }

    public void LoadUpgradeLvl()
    {
        LevelData data = SaveSystem.LoadUpgradeLvl();

        collectorLengthLvl = data.collectorLengthLvl;
        shieldLvl = data.shieldLvl;
		cargoLvl = data.cargoLvl;
		gunLvl = data.gunLvl;
        UpgraderScript.collectorLengthCurrentLevel = collectorLengthLvl;
        UpgraderScript.shieldCurrentLevel = shieldLvl;
		UpgraderScript.cargoCurrentLevel = cargoLvl;
		UpgraderScript.gunCurrentLevel = gunLvl;

        Debug.Log("Loading upgrade level");
    }

    public void SaveHealthValue()
    {
        health = PlayerScript.health;
        SaveSystem.SaveHealthValue(this);

        Debug.Log("Saving health value");
    }

    public void LoadHealthValue()
    {
        HealthData data = SaveSystem.LoadHealthValue();

        health = data.health;
        PlayerScript.health = health;
        Debug.Log(health);
        Debug.Log("Loading health value");
    }

	public void SaveCargoValue()
	{
		cargo = ResourcesDisplay.maxRedRockQuantity;
		SaveSystem.SaveCargoValue(this);

		Debug.Log("Saving health value");
	}

	public void LoadCargoValue()
	{
		CargoData data = SaveSystem.LoadCargoValue();

		cargo = data.cargo;
		ResourcesDisplay.maxRedRockQuantity = cargo;
		Debug.Log(cargo);
		Debug.Log("Loading cargo value");
	}

	public void SaveGunDamage()
	{
		gunDamage = EnemyScript.playerProjectileDamage;
		SaveSystem.SaveGunDamage(this);

		Debug.Log("Saving gun damage");
	}

	public void LoadGunDamage()
	{
		GunData data = SaveSystem.LoadGunDamage();

		gunDamage = data.gunDamage;
		EnemyScript.playerProjectileDamage = gunDamage;
		Debug.Log(gunDamage);
		Debug.Log("Loading gun damage");
	}

	public void SaveUnlockedLevels()
	{
		level2Unlocked = LevelUnlocker.level2Unlocked;
		level3Unlocked = LevelUnlocker.level3Unlocked;
		level4Unlocked = LevelUnlocker.level4Unlocked;
		level5Unlocked = LevelUnlocker.level5Unlocked;
		level6Unlocked = LevelUnlocker.level6Unlocked;
		level7Unlocked = LevelUnlocker.level7Unlocked;
		SaveSystem.SaveUnlockedLevels(this);

		Debug.Log("Saving unlocked level");
	}

	public void LoadUnlockedLevels()
	{
		UnlockedLevelsData data = SaveSystem.LoadUnlockedLevels();

		level2Unlocked = data.level2Unlocked;
		level3Unlocked = data.level3Unlocked;
		level4Unlocked = data.level4Unlocked;
		level5Unlocked = data.level5Unlocked;
		level6Unlocked = data.level6Unlocked;
		level7Unlocked = data.level7Unlocked;

		LevelUnlocker.level2Unlocked = level2Unlocked;
		LevelUnlocker.level3Unlocked = level3Unlocked;
		LevelUnlocker.level4Unlocked = level4Unlocked;
		LevelUnlocker.level5Unlocked = level5Unlocked;
		LevelUnlocker.level6Unlocked = level6Unlocked;
		LevelUnlocker.level7Unlocked = level7Unlocked;

		Debug.Log("Loading unlocked levels");
	}
}
