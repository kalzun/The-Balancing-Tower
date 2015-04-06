using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour 
{
	public static int score;
	// Reference to the Text component.
	// public Text scoreText; 

	public int[] highScores = new int[5];
	string highScoreKey = "";
	string nameKey = "";
	int newHighScore;
	int oldHighScore;

	// InputField inputField;
	string highScoreName;
	string oldHighScoreName;
	string newHighScoreName;

	int confirmedHighScore = 0; 
	public bool scoreEnteredHighScore = false;

	// int highScore;
 	// public GroundScript groundScript;



	public GameManagerScript gameManagerScript;
	ScoreTextScript scoreText;

	void Awake()
	{
		gameManagerScript = GameObject.Find ("GameManager").GetComponent<GameManagerScript> ();
		scoreText = GameObject.Find ("score").GetComponent<ScoreTextScript> ();

	}

	void Start ()
	{

		// Reset the score.
		score = 0;



	}


	// Update is called once per frame
	public void Update () 
	{
		// scoreText.text = "Score: " + score;

		newHighScoreName = gameManagerScript.inputField.text;

		// Debug.Log ("ScoreManagers inputname is " + newHighScoreName);
		// See WriteText-script
		// Debug.Log ("Donkey shows: " + score);


	}

	public void AddBonusPoints(int bonusPoints)
	{
		score += bonusPoints;
		scoreText.AddingScore ();

		Debug.Log ("Should add " + bonusPoints);
	}

	public void CheckHighScore()
	{

		// Get the lowest score, check if it's higher. 

		string highScoreKeyCheck5 = "HighScore " + (5).ToString ();
		int highScore5 = PlayerPrefs.GetInt (highScoreKeyCheck5, 0);

		if (score > highScore5) 
		{
			scoreEnteredHighScore = true;
			if (gameManagerScript.newHighScoreName != "")
			{
				Invoke ("EnterHighScore", 0f);
			}
		}

	}

	public void EnterHighScore()
	{
		//If our score is greater than highscore, set new highscore and save.
		for (int i = 0; i < highScores.Length; i++)
		{


			//Get the highScore from 1 - 5
			highScoreKey = "HighScore "+(i+1).ToString();
			nameKey = "Name " + (i+1);
			
			oldHighScore = PlayerPrefs.GetInt(highScoreKey,0);
			oldHighScoreName = PlayerPrefs.GetString (nameKey, "");
		
			//if score is greater, store previous highScore
			//Set new highScore
			//set score to previous highScore, and try again
			//Once score is greater, it will always be for the
			//remaining list, so the top 5 will always be 
			//updated
			
			if (score > oldHighScore)
			{
					int temp = oldHighScore;
					string tempString = oldHighScoreName;
					PlayerPrefs.SetInt(highScoreKey,score);
					PlayerPrefs.SetString(nameKey, newHighScoreName);
					score = temp;
					newHighScoreName = tempString;

					// Send info to gamemanagerscript that Score is valid for HighScore
					// confirmedHighScore++;
					// ConfirmedHighScore();
			}
		}

	}
	/* Redundant code ? 
	public void ConfirmedHighScore()
	{
		// Runs to check if highscore is entered, only when == 1 it is valid

		if (confirmedHighScore == 1) 
		{

			Debug.Log ("ConfirmedHighScore is " + confirmedHighScore);
		}
		if (confirmedHighScore > 1) 
		{
			Debug.Log ("ConfirmedHighscore is " + confirmedHighScore + " and above limit");
		}
		if (confirmedHighScore < 1) 
		{
			Debug.Log ("ConfirmedHighscore is " + confirmedHighScore + " and UNDER limit");
		}
	}
	*/
	/*
 	public void CheckingHighScore()
	{
		// Making list of highScores
		int[] highScores = new int[5];
		
		foreach (int i = 0; i < highScores.Length; i++)
		{
			
			//Get the highScore from 1 - 5
			string highScoreKey = ("HighScore", int i + 1).SetString();
			gameManagerScript.highScore = PlayerPrefs.GetInt(highScoreKey,0);
			
			//if score is greater, store previous highScore
			//Set new highScore
			//set score to previous highScore, and try again
			//Once score is greater, it will always be for the
			//remaining list, so the top 5 will always be 
			//updated
			if (score > gameManagerScript.highScore) 
			{
				int temp = gameManagerScript.highScore;
				PlayerPrefs.SetInt(highScoreKey,score);
				score = temp;
			}
		}
	}
	*/



}
