using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour 
{
	public float spawnPointMoveAmount;  // 0.65
	public float minSpawnHeight = 0.5f;
	public float maxSpawnHeight = 6f;
	
	public static int maxSpawned;
	

	// Cameraspeed
	float cameraScrollSpeed = 2f;


	public bool spaceToSpawn = true;

	// public userController userControllerScript;

	public GameManagerScript gameManager;
	// Groups
	public GameObject[] groups;

	// Increases to 1 when spawning, cannot spawn if more. Decrease when object dropped
	public int blocksSpawned = 0;

	// For lerping up and down:
	private float originalPositionY;
	private float newPosition;

	void Start()
	{
		maxSpawned = 0;
		// Spawn initial object
		SpawnNext ();
		// userControllerScript = GameObject.FindGameObjectWithTag ("PlayerObjects").GetComponent<userController> ();
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManagerScript> ();

	}

	void Update()
	{
		// Debug.Log(blocksSpawned);

		//Trying boxcollider-trigger in stead of Raycast for adjusting spawnpoin
		RaycastHit hit;
		// Ray mouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		Ray spawnerRay = new Ray (transform.position, Vector3.down);

		Debug.DrawRay (transform.position, Vector3.down, Color.blue);
		// Debug.DrawRay (transform.position, mouseRay.direction, Color.red);

		if (Physics.Raycast (spawnerRay, out hit)) 
		{
			if (hit.collider.tag == "PlayerObjectDropped") 
			{
				if (hit.distance < minSpawnHeight)
				{
					MoveUp ();

				}

				if (hit.distance > maxSpawnHeight)
				{
					MoveDown ();
				}
			}
			else if (hit.collider.tag == "Player")
			{
				if (hit.distance < minSpawnHeight)
				{
					MoveUp();
				}

				if (hit.distance > maxSpawnHeight)
				{
					MoveDown ();
				}
			}

		}


	}



	
	public void SpawnNext()
	{
		maxSpawned++;
		// Debug.Log ("Spawning 1");

		if (spaceToSpawn == false) 
		{
			MoveUp ();
			Debug.Log ("Not space to spawn, should MoveUp");
			Invoke ("SpawnNext", 1);
			spaceToSpawn = true;
		}


		else if (maxSpawned < 100 && blocksSpawned == 0 && spaceToSpawn)  // Stops spawning at 100 for testing.
		{
			int i = Random.Range (0, groups.Length);
			// Spawn Group at current position
			Instantiate (groups [i], transform.position, Quaternion.identity);
			blocksSpawned++;

		}
	}

	void FixedUpdate ()
	{
		/*
		// Trying this in UserController as well as here.

		RaycastHit minHit;
		RaycastHit maxHit;

		Ray spawnerRayMin = new Ray (transform.position, Vector3.down);
		Ray spawnerRayMax = new Ray (transform.position, Vector3.down);

		Debug.DrawRay (transform.position, Vector3.down * minSpawnHeight);

		if (Physics.Raycast (spawnerRayMin, out minHit, minSpawnHeight)) 
		{
				// distanceMeasured = hit.distance;

				if (minHit.collider.tag == "PlayerObjectDropped" || minHit.collider.tag == "Player") 
			{
			// 			MoveUp ();
				}
		} 
		else if 
		(Physics.Raycast (spawnerRayMax, out maxHit, maxSpawnHeight)) 
		{
				//MoveDown ();
		}
		else
		{
			Debug.Log ("Raycast from Spawnpoint does not hit");
		}
	*/
	


				// distanceMeasured = Vector3.Distance(startPoint, hit.distance);
				// Debug.Log ("Distance measured "+ distanceMeasured);
				// MoveUp ();
		/*
			}
		} 
		else 
		{
			Debug.Log ("Raycast did not hit anything");
		}

		*/
	}

	
	
	


	public void MoveUp()
	{
		originalPositionY = transform.position.y;
		newPosition = originalPositionY + spawnPointMoveAmount;
		StartCoroutine ("LerpUp");
		// Vector3 movePosition = new Vector3 (0, (Mathf.Lerp (originalPositionY, newPosition, cameraScrollSpeed * Time.deltaTime)),0);
		// transform.position = movePosition;
	}


	public void MoveDown()
	{

		originalPositionY = transform.position.y;
		newPosition = originalPositionY - spawnPointMoveAmount;
		StartCoroutine ("LerpDown");
		// Vector3 movePosition = new Vector3 (0, (Mathf.Lerp (originalPositionY, newPosition, cameraScrollSpeed * Time.deltaTime)), 0);
		// transform.position = movePosition;
	}

	IEnumerator LerpUp() 
	{
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / 4) 
		{	
			//s is a smoothed t
			float s = Mathf.SmoothStep (0.0f, 1.0f, t);
			//Spherical linear interpolation (Slerp) will give us a better rotation
			//if the rotations are far apart
			transform.position = new Vector3(transform.position.x, (Mathf.Lerp (originalPositionY, newPosition, s)), transform.position.z);
			// mainCam.transform.position = new Vector3(oldPosition.x, oldPosition.y, (Mathf.Lerp (mainCam.transform.position.z, newPositionZ, s)));
			
			// Instantiate (endParticles, mainCam.transform.position, mainCam.transform.rotation);
			
			// yield return new WaitForSeconds(6);
			
			yield return null;
		}
	}

	IEnumerator LerpDown() 
	{
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / 4) 
		{	
			//s is a smoothed t
			float s = Mathf.SmoothStep (0.0f, 1.0f, t);
			//Spherical linear interpolation (Slerp) will give us a better rotation
			//if the rotations are far apart
			transform.position = new Vector3(transform.position.x, (Mathf.Lerp (originalPositionY, newPosition, s)), transform.position.z);
			
			// Instantiate (endParticles, mainCam.transform.position, mainCam.transform.rotation);
			
			// yield return new WaitForSeconds(6);
			
			yield return null;
		}
	}


}