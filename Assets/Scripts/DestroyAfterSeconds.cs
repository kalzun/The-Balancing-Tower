using UnityEngine;
using System.Collections;

public class DestroyAfterSeconds : MonoBehaviour 
{
	public float destroyAfterSeconds = 1f;


	void Start () 
	{
		Destroy (gameObject, destroyAfterSeconds);
	}
	

}
