using UnityEngine;
using System.Collections;

public class SpwnCollider : MonoBehaviour 
{
	SpawnerScript spawner;
	void Awake()
	{
		spawner = GetComponentInParent<SpawnerScript> ();
	}


	
	void OnTriggerStay(Collider other)
	{
		if (other.tag == "PlayerObjectDropped")
		{
			spawner.MoveUp ();
			spawner.spaceToSpawn = false;
		}
		// Debug.Log (" Spacetospawn: " + spaceToSpawn);
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "PlayerObjectDropped")
		{
			spawner.spaceToSpawn = true;
		}
		// Debug.Log (" Spacetospawn: " + spaceToSpawn);
	}


}
