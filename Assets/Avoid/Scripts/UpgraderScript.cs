using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgraderScript : MonoBehaviour {

    private GameObject RedRockUI;
    private ResourcesDisplay RedRockScript;

    private GameObject CollectorLengthLvl;
    private Text CollectorLengthCurrentLvlDisplay;

    private GameObject CollectorLengthUpgradeCost;
    private Text CollectorLengthCostDisplay;

    private GameObject ShieldLvl;
    private Text ShieldCurrentLvlDisplay;

    private GameObject ShieldUpgradeCost;
    private Text ShieldUpgradeCostDisplay;

	private GameObject CargoLvl;
	private Text CargoCurrentLvlDisplay;

	private GameObject CargoUpgradeCost;
	private Text CargoUpgradeCostDisplay;

	private GameObject GunLvl;
	private Text GunCurrentLvlDisplay;

	private GameObject GunUpgradeCost;
	private Text GunUpgradeCostDisplay;

    public static int collectorLengthCurrentLevel = 1;
    public static int shieldCurrentLevel = 1;
	public static int cargoCurrentLevel = 1;
	public static int gunCurrentLevel = 1;

    private int mineralCollectorCost;
    private int shieldCost;
	private int cargoCost;
	private int gunCost;

    private static float trailLength = 1;

    private void Start()
    {
        Debug.Log(TrailRendererWith2DCollider.lifeTime);

        RedRockUI = GameObject.Find("Red Rock UI");
        RedRockScript = RedRockUI.GetComponentInChildren<ResourcesDisplay>();

        CollectorLengthLvl = GameObject.Find("CollectorLengthLvl");

        if (CollectorLengthLvl != null)
        {
            CollectorLengthCurrentLvlDisplay = CollectorLengthLvl.GetComponent<Text>();
            CollectorLengthCurrentLvlDisplay.text = "Lvl " + collectorLengthCurrentLevel.ToString();
        }

        CollectorLengthUpgradeCost = GameObject.Find("CollectorLengthUpgradeCost");

        if (CollectorLengthUpgradeCost != null)
        {
            CollectorLengthCostDisplay = CollectorLengthUpgradeCost.GetComponent<Text>();
            mineralCollectorCost = collectorLengthCurrentLevel * 5;
            CollectorLengthCostDisplay.text = mineralCollectorCost.ToString();
        }

        ShieldLvl = GameObject.Find("ShieldLvl");

        if (ShieldLvl != null)
        {
            ShieldCurrentLvlDisplay = ShieldLvl.GetComponent<Text>();
            ShieldCurrentLvlDisplay.text = "Lvl " + shieldCurrentLevel.ToString();
        }

        ShieldUpgradeCost = GameObject.Find("ShieldUpgradeCost");

        if(ShieldUpgradeCost != null)
        {
            ShieldUpgradeCostDisplay = ShieldUpgradeCost.GetComponent<Text>();
            shieldCost = shieldCurrentLevel * 10;
            ShieldUpgradeCostDisplay.text = shieldCost.ToString();
        }

		CargoLvl = GameObject.Find("CargoLvl");

		if(CargoLvl != null)
		{
			CargoCurrentLvlDisplay = CargoLvl.GetComponent<Text>();
			CargoCurrentLvlDisplay.text = "Lvl " + cargoCurrentLevel.ToString();
		}

		CargoUpgradeCost = GameObject.Find("CargoUpgradeCost");

		if(CargoUpgradeCost != null)
		{
			CargoUpgradeCostDisplay = CargoUpgradeCost.GetComponent<Text>();
			cargoCost = cargoCurrentLevel * 10;
			CargoUpgradeCostDisplay.text = cargoCost.ToString();
		}

		GunLvl = GameObject.Find("GunLvl");

		if (GunLvl != null)
		{
			GunCurrentLvlDisplay = GunLvl.GetComponent<Text>();
			GunCurrentLvlDisplay.text = "Lvl " + gunCurrentLevel.ToString();
		}

		GunUpgradeCost = GameObject.Find("GunUpgradeCost");

		if (GunUpgradeCost != null)
		{
			GunUpgradeCostDisplay = GunUpgradeCost.GetComponent<Text>();
			gunCost = gunCurrentLevel * 20;
			GunUpgradeCostDisplay.text = gunCost.ToString();
		}
	}

    public void MineralCollectorUpgrade()
    {
        if (ResourcesDisplay.redRockQuantity >= mineralCollectorCost)
        {
            trailLength = TrailRendererWith2DCollider.lifeTime + 0.1f;
            TrailRendererWith2DCollider.lifeTime = trailLength;

            RedRockScript.SpendRock(mineralCollectorCost);

            Debug.Log(TrailRendererWith2DCollider.lifeTime);

            collectorLengthCurrentLevel += 1;
            CollectorLengthCurrentLvlDisplay.text = "Lvl " + collectorLengthCurrentLevel.ToString();

            mineralCollectorCost = collectorLengthCurrentLevel * 5;
            CollectorLengthCostDisplay.text = mineralCollectorCost.ToString();

            Debug.Log(collectorLengthCurrentLevel);
        }
        else
        {
            Debug.Log("You don't have enough minerals");
        }
    }

    public void ShieldUpgrade()
    {
        if(ResourcesDisplay.redRockQuantity >= shieldCost)
        {
            PlayerScript.health += 5;

            RedRockScript.SpendRock(shieldCost);

            shieldCurrentLevel += 1;
            ShieldCurrentLvlDisplay.text = "Lvl " + shieldCurrentLevel.ToString();

            shieldCost = shieldCurrentLevel * 10;
            ShieldUpgradeCostDisplay.text = shieldCost.ToString();

            Debug.Log(PlayerScript.health);
        }
        else
        {
            Debug.Log("You don't have enough minerals");
        }
    }

	public void CargoUpgrade()
	{
		if (ResourcesDisplay.redRockQuantity >= cargoCost)
		{
			ResourcesDisplay.maxRedRockQuantity += 10;

			RedRockScript.SpendRock(cargoCost);

			cargoCurrentLevel += 1;
			CargoCurrentLvlDisplay.text = "Lvl " + cargoCurrentLevel.ToString();

			cargoCost = cargoCurrentLevel * 10;
			CargoUpgradeCostDisplay.text = cargoCost.ToString();

			Debug.Log(ResourcesDisplay.maxRedRockQuantity);
		}
		else
		{
			Debug.Log("You don't have enough minerals");
		}
	}

	public void GunUpgrade()
	{
		if (ResourcesDisplay.redRockQuantity >= gunCost)
		{
			EnemyScript.playerProjectileDamage++;

			RedRockScript.SpendRock(gunCost);

			gunCurrentLevel += 1;
			GunCurrentLvlDisplay.text = "Lvl " + gunCurrentLevel.ToString();

			gunCost = gunCurrentLevel * 20;
			GunUpgradeCostDisplay.text = gunCost.ToString();

			Debug.Log(EnemyScript.playerProjectileDamage);
		}
		else
		{
			Debug.Log("You don't have enough minerals");
		}
	}
}
