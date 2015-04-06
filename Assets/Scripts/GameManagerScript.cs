using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManagerScript : MonoBehaviour 
{
	private GroundScript groundScript;
	public ScoreManager scoreManager;
	public LeaderBoardScript highScoreText;

	public GameObject restartDialog;
	public GameObject newHighScorePanel;



	public Animator restartDlgAnim;
	public Animator newHighScoreAnim;

	public InputField inputField; 

	public string newHighScoreName;

	void Awake () 
	{
		groundScript = GameObject.Find ("GroundTriggerCollider").GetComponent<GroundScript> ();
		highScoreText = GameObject.Find ("highScoreText").GetComponent<LeaderBoardScript> ();
		// PreLoad PlayerPrefs to cut down loadtime when checking the HighScore.
		highScoreText.LeaderBoard ();
	}

	void Start ()
	{
		scoreManager = GameObject.Find ("ScoreManager").GetComponent<ScoreManager> ();

		restartDlgAnim = GameObject.Find ("dlg_restart").GetComponent<Animator> ();
		restartDialog.SetActive (false);
		newHighScoreAnim = GameObject.Find ("pnl_newHighScore").GetComponent<Animator> ();
		newHighScorePanel.SetActive (false);

		// restartDlgAnim.SetBool ("isHidden", true);

		// restartDlgAnim.SetBool ("newHighScore", false);

		// Resets the Highscore:
		// PlayerPrefs.SetInt ("High Score", 3);

		// highScore = PlayerPrefs.GetInt ("High Score");
	}


	void Update () 
	{


		if (groundScript.hitGround == true) 
		{
			scoreManager.CheckHighScore();

			// Check if High Score is within top 5 
			if (scoreManager.scoreEnteredHighScore)
			{
				NewHighScore();
			}


			EndGameDialog();

		}
	}

	/* public void AddScore()
	{
		score ++;
		Debug.Log ("Score is now: " + score);
	}
	*/

	public void EnteredHighScore() // Runs when player have pressed ENTER after typing their name in the HSInput.
	{
		newHighScoreName = inputField.text;
		GetComponent<AudioSource>().Play ();

	}

	public void EndGameDialog()
	{

		restartDialog.SetActive (true);
		restartDlgAnim.SetBool ("isHidden", false);
	
		UpdateLeaderBoard ();
	}


	public void RestartGame()
	{
		restartDlgAnim.SetBool ("isHidden", true);
		GetComponent<AudioSource>().Play ();
		Application.LoadLevel (Application.loadedLevelName);


	}

	public void ExitToMenu()
	{	
		restartDlgAnim.SetBool ("isHidden", true);
		GetComponent<AudioSource>().Play ();
		Application.LoadLevel ("MenuScene");
	}

	public void NewHighScore()
	{
		newHighScorePanel.SetActive (true);
		newHighScoreAnim.SetBool ("isHidden", true);


		// Debug.Log ("Inputname is: " + newHighScoreName);

		scoreManager.scoreEnteredHighScore = false;
	}

	public void UpdateLeaderBoard()
	{
		highScoreText.highScoreText.text = "";
		highScoreText.LeaderBoard ();
	}

}
