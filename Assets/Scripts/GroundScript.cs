using UnityEngine;
using System.Collections;

public class GroundScript : MonoBehaviour 
{
	public bool hitGround = false;
	BoxCollider collider;

	void Awake()
	{
		collider = GetComponent<BoxCollider> ();
	}

	void FixedUpdate()
	{
		if (Input.GetKey (KeyCode.O)) 
		{
			if (collider.enabled)
			{
					collider.enabled = false;
			}
			else
			{
				collider.enabled = true;
			}
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "PlayerObjectDropped" || other.gameObject.tag == "PlayerObjects") 
		{
			// Debug.Log ("GameOver!");
			hitGround = true;
			GetComponent<AudioSource>().Play();
		}
	}
}
