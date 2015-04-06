using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BonusText : MonoBehaviour 
{
	Text text;

	void Awake ()
	{
		text = GetComponent<Text>();

	}


	public void DisplayBonusText(int points)
	{
		gameObject.SetActive (true);

		text.text = ("Bonus: " + points + "p!");

		Invoke ("DisableBonusText", 2f);
	}

	void DisableBonusText()
	{
		gameObject.SetActive (false);
	}
}
