using UnityEngine;
using System.Collections;

public class RayCastScript : MonoBehaviour 
{
	public SpawnerScript spawnerScript;
	public userController userController;

	 float blockRayMinHeight = 1f;
	 float blockRayMaxHeight = 3f;


	// public bool heightToSpawn = true;

	// Use this for initialization
	void Start () 
	{
		spawnerScript = GameObject.Find ("Spawner").GetComponent<SpawnerScript> ();
		userController = gameObject.GetComponent<userController> ();
	}
	

	void FixedUpdate () 
	{
		if (!userController.mouseClickObject)
		{
			// if (!userController.isDropped)

			Ray blockRayMin = new Ray (transform.position, Vector3.down);
			RaycastHit blockRayMinHit;
			Ray blockRayMax = new Ray (transform.position, Vector3.down);
			RaycastHit blockRayMaxHit;


			// Debug.DrawRay (transform.position, Vector3.down * blockRayMinHeight);
			// Debug.DrawRay (transform.position, Vector3.down * blockRayMaxHeight);

			// Check if MinRay is hit
			if (Physics.Raycast (blockRayMin, out blockRayMinHit, blockRayMinHeight)) {
					// If MinRay is hit, block should be moved up:
					userController.MoveUpSpawnedObject ();

					// Redundant code (?) - Checks distance from org pos to Ray hit. 
					//distanceMeasured = hit.distance;
			}

			// If MaxRay is hit when MinRay is NOT hit
			else if (Physics.Raycast (blockRayMax, out blockRayMaxHit, blockRayMaxHeight)) {
					// spawnerScript.SpawnNext ();
			} else { // If MinRay is NOT hit AND MaxRay is NOT hit
					userController.MoveDownSpawnedObject ();
			}
		}
	}


		/*
			if (hit.collider.tag == "PlayerObjectDropped" || hit.collider.tag == "Player")
			{
				
				if (distanceMeasured < spawnerScript.minDistance)  // Alternative to: (distanceMeasured < maxDistance - spawnPointMoveAmount)
				{	
					userController.MoveUpSpawnedObject ();
					heightToSpawn = false; 
				}

				
				
				
				if (distanceMeasured >= spawnerScript.maxDistance) 
				{
						userController.MoveDownSpawnedObject ();
				}
				
				// distanceMeasured = Vector3.Distance(startPoint, hit.distance);
				// Debug.Log ("Distance measured "+ distanceMeasured);
				// MoveUp ();
			}
		}
		} 
		else 
		{
			heightToSpawn = true;
			Debug.Log ("Raycast did not hit anything");
		}
		// END OF RAYCAST
	}
	*/	
}
