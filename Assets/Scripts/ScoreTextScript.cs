using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreTextScript : MonoBehaviour {

	Text scoreText;

	// Use this for initialization
	void Start () {
		scoreText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		// Debug.Log (scoreText.text);

	}

	public void AddingScore()
	{
		scoreText.text = ("Score: " + ScoreManager.score);
	}
}
