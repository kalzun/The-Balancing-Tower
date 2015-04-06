using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LeaderBoardScript : MonoBehaviour 
{

	public int[] highScores = new int[5];
	string highScoreKey = "";
	string nameKey = "";
	
	string newHighScore = "";

	public Text highScoreText;
	
	void Start()
	{
		highScoreText = GetComponent<Text> ();
		// PlayerPrefs.DeleteAll ();
		LeaderBoard ();

	}

	void Update ()
	{

		/* 
		 * if (Input.GetKeyDown (KeyCode.Backspace))
		{
			LeaderBoard();
			Debug.Log ("Leaderboard higscore-string: " + PlayerPrefs.GetString ("Name ", ""));
		}
		*/
	}
	
	public void LeaderBoard()
	{
	

		for (int i = 0; i < highScores.Length; i++)
		{
			highScoreKey = "HighScore " + (i + 1).ToString();
			highScores[i] = PlayerPrefs.GetInt (highScoreKey,0);
			nameKey = "Name " + (i + 1).ToString ();
			newHighScore = PlayerPrefs.GetString (nameKey, "");
			
			//use these values in whatever shows the leaderboard(s).
			
		    highScoreText.text = highScoreText.text + "\r\n" +  + highScores[i] + "p. " + newHighScore; 
			// Debug.Log ("HighScore is " + highScoreKey + ": " + highScores[i] + " " + newHighScore);
			
		}

		
		
	}



}
