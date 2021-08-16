using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesDisplay : MonoBehaviour {

    public static int redRockQuantity;
    public int redRockAdd;

    public static int maxRedRockQuantity = 100;

    private Text redRockText;

    private GameObject mineralSlider;
    private Slider mineralSliderSlider;

    // Use this for initialization
    void Start () {
        mineralSlider = GameObject.Find("MineralSlider");
        mineralSliderSlider = mineralSlider.GetComponent<Slider>();

        redRockText = gameObject.GetComponent<Text>();        
        redRockText.text = redRockQuantity.ToString() + "/" + maxRedRockQuantity.ToString();

        mineralSliderSlider.maxValue = maxRedRockQuantity;
        mineralSliderSlider.value = redRockQuantity;
	}

    public void RedRockDisplay()
    {
        redRockQuantity += redRockAdd;

        if (redRockQuantity <= maxRedRockQuantity)
        {
            redRockText.text = redRockQuantity.ToString() + "/" + maxRedRockQuantity.ToString();

            mineralSliderSlider.maxValue = maxRedRockQuantity;
            mineralSliderSlider.value = redRockQuantity;
        }
        else if(redRockQuantity > maxRedRockQuantity)
        {
            redRockQuantity = maxRedRockQuantity;
            Debug.Log("Cargo full");
        }
    }

	public void RedRockAdd(int amount)
	{
		redRockQuantity += amount;

		if (redRockQuantity <= maxRedRockQuantity)
		{
			redRockText.text = redRockQuantity.ToString() + "/" + maxRedRockQuantity.ToString();

			mineralSliderSlider.maxValue = maxRedRockQuantity;
			mineralSliderSlider.value = redRockQuantity;
		}
		else if (redRockQuantity > maxRedRockQuantity)
		{
			redRockQuantity = maxRedRockQuantity;
			Debug.Log("Cargo full");
		}
	}

    public void SpendRock(int cost)
    {
        redRockQuantity -= cost;
        redRockText.text = redRockQuantity.ToString() + "/" + maxRedRockQuantity.ToString();

        mineralSliderSlider.maxValue = maxRedRockQuantity;
        mineralSliderSlider.value = redRockQuantity;
    }

    // Cheat, remove later
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            redRockQuantity += 10;
            redRockText.text = redRockQuantity.ToString() + "/" + maxRedRockQuantity.ToString();

            mineralSliderSlider.maxValue = maxRedRockQuantity;
            mineralSliderSlider.value = redRockQuantity;
        }

		mineralSliderSlider.maxValue = maxRedRockQuantity;
	}
}
