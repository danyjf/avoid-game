using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {

    public static void SaveGame(GameManager gameManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/player.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(gameManager);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static void SaveRedRockQuantity(GameManager gameManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/redrock.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        RedRockData data = new RedRockData(gameManager);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static RedRockData LoadRedRockQuantity()
    {
        string path = Application.persistentDataPath + "/redrock.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            RedRockData data = formatter.Deserialize(stream) as RedRockData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static void SaveUpgradeLvl(GameManager gameManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/upgradelvl.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        LevelData data = new LevelData(gameManager);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static LevelData LoadUpgradeLvl()
    {
        string path = Application.persistentDataPath + "/upgradelvl.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            LevelData data = formatter.Deserialize(stream) as LevelData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static void SaveHealthValue(GameManager gameManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/health.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        HealthData data = new HealthData(gameManager);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static HealthData LoadHealthValue()
    {
        string path = Application.persistentDataPath + "/health.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            HealthData data = formatter.Deserialize(stream) as HealthData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

	public static void SaveCargoValue(GameManager gameManager)
	{
		BinaryFormatter formatter = new BinaryFormatter();

		string path = Application.persistentDataPath + "/cargo.save";
		FileStream stream = new FileStream(path, FileMode.Create);

		CargoData data = new CargoData(gameManager);

		formatter.Serialize(stream, data);
		stream.Close();
	}

	public static CargoData LoadCargoValue()
	{
		string path = Application.persistentDataPath + "/cargo.save";
		if (File.Exists(path))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);

			CargoData data = formatter.Deserialize(stream) as CargoData;
			stream.Close();

			return data;
		}
		else
		{
			Debug.LogError("Save file not found in " + path);
			return null;
		}
	}

	public static void SaveGunDamage(GameManager gameManager)
	{
		BinaryFormatter formatter = new BinaryFormatter();

		string path = Application.persistentDataPath + "/gundamage.save";
		FileStream stream = new FileStream(path, FileMode.Create);

		GunData data = new GunData(gameManager);

		formatter.Serialize(stream, data);
		stream.Close();
	}

	public static GunData LoadGunDamage()
	{
		string path = Application.persistentDataPath + "/gundamage.save";
		if (File.Exists(path))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);

			GunData data = formatter.Deserialize(stream) as GunData;
			stream.Close();

			return data;
		}
		else
		{
			Debug.LogError("Save file not found in " + path);
			return null;
		}
	}

	public static void SaveUnlockedLevels(GameManager gameManager)
	{
		BinaryFormatter formatter = new BinaryFormatter();

		string path = Application.persistentDataPath + "/unlockedlevels.save";
		FileStream stream = new FileStream(path, FileMode.Create);

		UnlockedLevelsData data = new UnlockedLevelsData(gameManager);

		formatter.Serialize(stream, data);
		stream.Close();
	}

	public static UnlockedLevelsData LoadUnlockedLevels()
	{
		string path = Application.persistentDataPath + "/unlockedlevels.save";
		if (File.Exists(path))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);

			UnlockedLevelsData data = formatter.Deserialize(stream) as UnlockedLevelsData;
			stream.Close();

			return data;
		}
		else
		{
			Debug.LogError("Save file not found in " + path);
			return null;
		}
	}
}
