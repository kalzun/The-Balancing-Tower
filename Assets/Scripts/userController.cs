using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(MeshCollider))]

public class userController : MonoBehaviour {

	float brickSpeed = 3f;
	Vector3 startPosition;
	Vector3 startRotation;
	public bool isDropped = false;
	bool hitGroundTag = false;

	public SpawnerScript spawnObject;
	public RayCastScript rayCasterScript;
	public GameManagerScript gameManager;
	public GroundScript groundScript;
	public LeaderBoardScript leaderBoardScript;
	ScoreManager scoreManager;

	ScoreTextScript scoreText;

	// Camera-change
	public Camera cam1;
	public Camera cam2;

//	Camera cam2.enabled = false; 
	// cam2.enabled = false;

	// For mousedrag
	private Vector3 screenPoint;
	private Vector3 offset;
	public bool mouseClickObject = false;


	// Change when connecting to same blocks:
	// Texture btn_9slice_normal = Resources.Load ("btn_9slice_normal", typeof(Texture));



	// Bonuspoints:
	bool bonusPointWithinDelay = true;
	int bonusPoint = 0;



	// public float spawningHeigth = 2f;
	public float preGravityMovement = 2f;
	public float moveStrength = 0.5f;

	void Start()
	{
		groundScript = GameObject.Find ("GroundTriggerCollider").GetComponent<GroundScript> ();
		scoreText = GameObject.Find ("score").GetComponent<ScoreTextScript> ();
		spawnObject = GameObject.Find ("Spawner").GetComponent<SpawnerScript> ();
		rayCasterScript = gameObject.GetComponent<RayCastScript> ();

		gameManager = GameObject.Find ("GameManager").GetComponent<GameManagerScript> ();

		scoreManager = GameObject.Find ("ScoreManager").GetComponent<ScoreManager> ();
		cam1 = GameObject.Find ("MainCamera").GetComponent<Camera>();
		cam2 = GameObject.Find ("SecondCamera").GetComponent<Camera>();
		// leaderBoardScript = GameObject.Find ("LeaderBoard").GetComponent<LeaderBoardScript> ();
	}

	void Update()
	{
		// Camera-change:
		if (Input.GetKeyDown(KeyCode.C)) 
		{
			cam1.enabled = !cam1.enabled;
			cam2.enabled = !cam2.enabled;
		}

		if (!isDropped) 
		{
			// Debug.Log ("isDropped is = " + isDropped);
			MovementController ();



		}

		if (isDropped) 
		{
			AddingScore();
			KillThisUserController();
			CallSpawnNewObject();
			
		}
	}

	public void AddingScore ()
	{
		ScoreManager.score++;
		scoreText.AddingScore ();

	}
	
	void CallSpawnNewObject()	
	{
		spawnObject.SpawnNext ();
		// Debug.Log ("SPAWN NEXT NOW!");
	} 

	void KillThisUserController()
	{
		// Debug.Log ("KillThisUserController reached!");

		GameObject.DestroyObject (this);
		// Remove raycast (Does this also when pressing SPACE
		GameObject.DestroyObject (rayCasterScript);	
		
	}

	void MovementController()
	{
		if // ( !groundScript.hitGround) { // If true, controls will not work.
			(!hitGroundTag) 
			{
			// Button for spawn new object if not spawning
			if (Input.GetKeyDown (KeyCode.P)) {
					CallSpawnNewObject ();
			}

			// Rotate
			if (Input.GetKeyDown (KeyCode.Q)) {
					transform.Rotate (0, -45 / 3, 0); 
			}

			if (Input.GetKeyDown (KeyCode.E)) {
					transform.Rotate (0, 45 / 3, 0); 
			}

			// ^ END Rotate

			// Get Restart-dialoge
			if (Input.GetKeyDown (KeyCode.Escape)) {
					gameManager.EndGameDialog ();
			}

			// Normal Arrow-keys in X- and Y:
			if (Input.GetKey (KeyCode.LeftArrow)) {
					transform.Translate (-Vector3.right * Time.deltaTime * brickSpeed);
			
			}

			if (Input.GetKey (KeyCode.RightArrow)) {
					transform.Translate (Vector3.right * Time.deltaTime * brickSpeed);
			}
			if (Input.GetKey (KeyCode.UpArrow)) {
					transform.Translate (Vector3.forward * Time.deltaTime * brickSpeed); 
			}
			if (Input.GetKey (KeyCode.DownArrow)) {
					transform.Translate (Vector3.back * Time.deltaTime * brickSpeed); 
			}

			if (Input.GetKey (KeyCode.W))
			{
				transform.Translate (Vector3.up * Time.deltaTime * brickSpeed);
			}

			if (Input.GetKey (KeyCode.S))
			{
				transform.Translate (Vector3.down * Time.deltaTime * brickSpeed);
			}
	
			// DROP
			if (Input.GetKey (KeyCode.Space)) 
			{
				gameObject.GetComponent<Rigidbody>().useGravity = true;	
				// Remove raycast
				GameObject.DestroyObject (rayCasterScript);	
			}
			}
	}


	public void OnTriggerEnter (Collider other)
	{ 
		OffZMover ();
			/* 
	if (other.gameObject.tag == "GroundTag") 
	{
		Debug.Log ("Ground hit, game over");
	}
	*/


	/* Checks if dropped block is landing (colliding) on either an already placed block, or hemisphere (player).
	if (other.collider.tag == "PlayerObjectDropped" || other.collider.tag == "Player" || other.collider.tag == "GroundTag") 
	{
		SameNameConnecting(other);
	}
	*/
	if (other.GetComponent<Collider>().tag == "PlayerObjectDropped" || other.GetComponent<Collider>().tag == "Player" || other.GetComponent<Collider>().tag == "GroundTag") 
	{
		isDropped = true; 
		gameObject.GetComponent<Rigidbody>().useGravity = true;	
		gameObject.tag = "PlayerObjectDropped";
		spawnObject.blocksSpawned = 0;
		
		if (other.GetComponent<Collider>().tag == "GroundTag")
			{
				hitGroundTag = true;
			}

		if (other.GetComponent<Collider>().tag != "SpawnTag") 
		{
			GetComponent<AudioSource>().Play ();
		}

	}
	}

	void OnMouseDown()
	{
		// Toggles raycasting on block when pressed
		if (!mouseClickObject)
		{
			mouseClickObject = true;
			OnZMover();
		}
		else
		{
			mouseClickObject = false;
			OffZMover();
		}



		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));


	}

	public void OnZMover()
	{
		foreach (Transform child in gameObject.transform)
		{
			if (!child.gameObject.activeSelf)
			{
				child.gameObject.SetActive(true);
			}
			

		}
	
	}

	public void OffZMover()
	{
		foreach (Transform child in gameObject.transform)
		{
			if (child.gameObject.activeSelf) 
			{
				child.gameObject.SetActive(false);
			}
		}
	
	}



	void OnMouseDrag()
	{


		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
	
		curPosition.z = transform.position.z;
		transform.position = curPosition;

	}



	/* Change rendering when same block connecting:
	public void SameNameConnecting(Collider other)
	{
		Object changeGOColour = Resources.Load ("btn_9slice_normal", typeof(Texture));
		Texture gOTextureChange = (Texture) changeGOColour;
		
		// check colour on trigger
		if (gameObject.name == other.name && other.collider.tag != "Player")
		{
			// thisGOColour.color = new Color (100,100,100);
			gameObject.renderer.material.mainTexture = gOTextureChange;
			// thisGOColour.mainTexture = Resources.Load ("btn_9slice_normal", typeof(Texture));
			other.renderer.material.mainTexture = gOTextureChange;

			// Use coroutine to avoid getting multiple BonusPoints when colliders trigger
		}
		if (bonusPointWithinDelay == true) 
		{
			BonusPoints (1);
			// Debug.Log ("Same name connecting!");
        }

		StartCoroutine(BonusPointHitDelay());
	}
	*/
	
	public void BonusPoints (int regId)
	{
		// Bonuspoints: 
		//
		// Debug.Log ("RegId is: " + regId);

		if (regId == 0) 
		{

		}

		if (regId == 1)  // 1 bonuspoint for hitting another block of the same
		{
			scoreManager.AddBonusPoints (1) ;
		}



	}

	public IEnumerator BonusPointHitDelay()
	{
		bonusPointWithinDelay = false;
		yield return new WaitForSeconds (1f); // wait for 1 second
		bonusPointWithinDelay = true; 

	}






		/* Move camera and spawner without raycasting:
		if (other.gameObject.tag == "TowerH1") 
		{
			spawnObject.MoveUp();
			Debug.Log ("H1 ");
		}
		*/


	/*
	public void MoveUpSpawnedObject()
	{
		
		float originalPositionY = transform.position.y;
		float newPosition = originalPositionY + spawnPointMoveAmount;
		Vector3 movePosition = new Vector3 (0, newPosition, 0);
		transform.position = movePosition;
	}
	*/

	public void MoveUpSpawnedObject()
	{
		float originalPositionY = transform.position.y;
		float newPosition = originalPositionY + preGravityMovement;
		Vector3 movePosition = new Vector3 (transform.position.x, (Mathf.Lerp (originalPositionY, newPosition, moveStrength * Time.deltaTime)),transform.position.z);
		transform.position = movePosition;
	}



	public void MoveDownSpawnedObject()
	{
		float originalPositionY = transform.position.y;
		float newPosition = originalPositionY - preGravityMovement;
		Vector3 movePosition = new Vector3 (transform.position.x, (Mathf.Lerp (originalPositionY, newPosition, moveStrength * Time.deltaTime)), transform.position.z);
		transform.position = movePosition;
	}
}
