using UnityEngine;
using System.Collections;

public class StarScript : MonoBehaviour
{

	float speed = 20;
	public int pointsForSmallStar = 5;
	ScoreManager scoreManager;
	public BonusText bonus;


	void Awake ()
	{
		scoreManager = GameObject.Find ("ScoreManager").GetComponent<ScoreManager> ();
		// bonus = GameObject.Find ("BonusPointsText").GetComponent<BonusText> ();
	}

	void Start ()
	{

	}
	// Update is called once per frame
	void FixedUpdate () 
	{
		transform.Rotate (Vector3.down * Time.deltaTime * speed);
		// transform.localScale = Mathf.Lerp (scaleBig, scaleSmall, 5);
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "PlayerObjectDropped")
		{
			bonus.DisplayBonusText(pointsForSmallStar);
			scoreManager.AddBonusPoints(pointsForSmallStar);
			Destroy (gameObject);
		}
	}

	void OnTriggerStay (Collider other)
	{
		if (other.tag == "PlayerObjectDropped")
		{
			OnTriggerEnter(other);
		}
	}
}
