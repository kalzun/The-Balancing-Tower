using UnityEngine;
using System.Collections;

public class DestroyFourColliderScript : MonoBehaviour 
{
	public ParticleSystem explosion;



	void OnTriggerEnter (Collider other)
	{
		// gameObjectColor.transform.renderer.material.color = other.GetComponent<Color> ();


	
		if (other.tag == "PlayerObjectDropped" && other.name == gameObject.name)
		{
			// for (int i = 0; i < 4; i++)
			// {
				Color otherColor = other.GetComponent<Renderer>().material.color;
			Debug.Log ("Other Color = " + otherColor);
				otherColor = Color.Lerp (otherColor, Color.black, 0f);
			Debug.Log ("Other Color = " + otherColor);
				/*
				gameObjectColor.material.color = new Color ( (Mathf.Lerp (gameObjectColor.r, 0f, 3f) ),
					                             	(Mathf.Lerp (gameObjectColor.g, 0f, 3f) ),
					                             	(Mathf.Lerp (gameObjectColor.b, 0f, 3f) ) );
				*/
				// Instantiate (explosion, other.transform.position, other.transform.rotation);

				Destroy (other.gameObject);
			// }
		
			// Instantiate (explosion, transform.position, transform.rotation);
			Invoke ("FourExplosions", 0f);
			Destroy (gameObject,2f);

		}

	}

	void FourExplosions()
	{
		Instantiate (explosion, transform.position, transform.rotation);
	}

}