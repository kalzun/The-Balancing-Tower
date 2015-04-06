using UnityEngine;
using System.Collections;

public class UIManagerScript : MonoBehaviour 
{
	public Animator startButton;
	public Animator highScoreButton;
	public Animator settingsButton;
	public Animator settingsDialoge;
	public Animator highScoreDialoge;

	public void StartGame()
	{
		Application.LoadLevel ("scene1");
		GetComponent<AudioSource>().Play ();
	}

	public void OpenSettings()
	{
		startButton.SetBool ("isHidden", true);
		settingsButton.SetBool ("isHidden", true);
		highScoreButton.SetBool ("isHidden", true);
		settingsDialoge.enabled = true;
		settingsDialoge.SetBool ("isHidden", false);
		GetComponent<AudioSource>().Play ();

	}

	public void CloseSettings()
	{
		startButton.SetBool ("isHidden", false);
		settingsButton.SetBool ("isHidden", false);
		highScoreButton.SetBool ("isHidden", false);
		settingsDialoge.SetBool ("isHidden", true);
		// settingsDialoge.enabled = false;
		GetComponent<AudioSource>().Play ();
	}

	public void OpenHighScores()
	{
		startButton.SetBool ("isHidden", true);
		settingsButton.SetBool ("isHidden", true);
		highScoreButton.SetBool ("isHidden", true);
		highScoreDialoge.SetBool ("isHidden", false);
		highScoreDialoge.enabled = true;
		// Update highscore:
		// LeaderBoardScript updateLeaderBoard = GameObject.Find ("txt_highScores").GetComponent<LeaderBoardScript>();
		// updateLeaderBoard.LeaderBoard ();
		GetComponent<AudioSource>().Play ();
	}

	public void CloseHighScores()
	{
		startButton.SetBool ("isHidden", false);
		settingsButton.SetBool ("isHidden", false);
		highScoreButton.SetBool ("isHidden", false);
		highScoreDialoge.SetBool ("isHidden", true);
		// highScoreDialoge.enabled = false;
		GetComponent<AudioSource>().Play ();
	}

	public void ResetHighScore()
	{
		PlayerPrefs.DeleteAll ();	
		LeaderBoardScript updateLeaderBoard = GameObject.Find ("txt_highScores").GetComponent<LeaderBoardScript>();
		updateLeaderBoard.highScoreText.text = ("No High Scores.");
		GetComponent<AudioSource>().Play ();
	}







}
