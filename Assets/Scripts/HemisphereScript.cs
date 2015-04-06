using UnityEngine;
using System.Collections;

public class HemisphereScript : MonoBehaviour 
{

	void OnTriggerEnter (Collider other)
	{
		GetComponent<AudioSource>().Play ();
	}

}
