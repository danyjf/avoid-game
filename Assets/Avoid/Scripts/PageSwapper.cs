using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageSwapper : MonoBehaviour {

	Vector2 nextPagePos;
	Vector2 previousPagePos;

	bool lerpRight = false;
	bool lerpLeft = false;

	public void NextPageOfLevels()
	{
		lerpLeft = false;
		nextPagePos = new Vector2(GetComponent<RectTransform>().anchoredPosition.x - 600, 0);
		lerpRight = true;
	}

	public void PreviousPageOfLevels()
	{
		lerpRight = false;
		previousPagePos = new Vector2(GetComponent<RectTransform>().anchoredPosition.x + 600, 0);
		lerpLeft = true;
	}

	private void Update()
	{
		if (lerpRight == true)
		{
			GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(GetComponent<RectTransform>().anchoredPosition, nextPagePos, 10f * Time.deltaTime);

			if (Mathf.Round(GetComponent<RectTransform>().anchoredPosition.x) == Mathf.Round(nextPagePos.x))
			{
				lerpRight = false;
			}
			Debug.Log(nextPagePos);
			Debug.Log(lerpRight);
		}
		if (lerpLeft == true)
		{
			GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(GetComponent<RectTransform>().anchoredPosition, previousPagePos, 10f * Time.deltaTime);

			if (Mathf.Round(GetComponent<RectTransform>().anchoredPosition.x) == Mathf.Round(previousPagePos.x))
			{
				lerpLeft = false;
			}

			Debug.Log(lerpLeft);
		}
	}
}
