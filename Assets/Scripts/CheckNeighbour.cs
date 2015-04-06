using UnityEngine;
using System.Collections;

// Checks if neighbour is the same

public class CheckNeighbour : MonoBehaviour 
{
	int connectingTwo = 1;
	int connectingFour = 6;

	float heightOfBlock;
	float rayLengthUp;
	float rayLengthDown;
	float widthOfBlock;

	userController userController;


	int blocksConnected;
	public Rigidbody prefabDestroyFour;
	public int destroySpeed = 10;

	void Awake ()
	{
		userController = GetComponent<userController> ();
	}

	void Start () 
	{
		heightOfBlock = transform.localScale.y;
		rayLengthUp = (transform.localScale.y / 2);
		rayLengthDown = (heightOfBlock * connectingFour) + (transform.localScale.y / 2);

	}


	void FixedUpdate () 
	{
		if (userController.isDropped)
		{
			bool anotherBlockInRay = false;
			Ray down = new Ray (transform.position, Vector3.down * rayLengthDown);
			RaycastHit[] hitDown;
			hitDown = Physics.RaycastAll (down);
			
			int i = 0;
			int hitSame = 0;
			while (i < hitDown.Length)
			{
				if (hitDown[i].transform.tag == gameObject.tag && hitDown[i].transform.name != gameObject.name)
				{
					anotherBlockInRay = true;
	
				}

				else if (hitDown[i].transform.tag == gameObject.tag && hitDown[i].transform.name == gameObject.name)
				{
					hitSame++;
					
					Debug.DrawRay (transform.position, down.direction * rayLengthDown, Color.cyan);
					//Debug.Log (hitDown.Length);
					if (hitSame == connectingFour && !anotherBlockInRay)
					{
						DestroyFourBlocks();

					}
					
				}
				
				i++;
			}

			/*
			int i = 0;
			while (i < hitUp.Length)
			{
				if (hitUp[i].transform.tag == gameObject.tag && hitUp[i].transform.name == gameObject.name)
				{
					if (i == connectingTwo)
					{

						GameObject hitBlocks;
						hitBlocks = hitUp[i].transform.gameObject;
						DestroyConnectedBlocks(hitBlocks);

					}

					if (i == connectingFour)
					{
						for (int j = 0; j < connectingFour; j++)
						{
							GameObject[] hitBlocks;
							// hitUp[i].transform.gameObject.BroadcastMessage("
							hitBlocks = hitUp[i].transform.gameObject;
							DestroyConnectedBlocks(hitBlocks);
							Debug.Log ("Connecting four!");
						}
					}

		
				}
				i++;
			}
				
			while (i < hitDown.Length)
			{
				if (hitDown[i].transform.tag == gameObject.tag && hitDown[i].transform.name == gameObject.name)
				{
					if (i == connectingTwo)
					{

						GameObject hitBlocks;
						hitBlocks = hitDown[i].transform.gameObject;
						DestroyConnectedBlocks(hitBlocks);

						//Debug.Log ("Connecting two!");
					}
					
					if (i == connectingFour)
					{
						// Debug.Log ("Connecting four!");
					}

					
				}
				
				i++;
			}

			/*
				if (hitLeft.Length > 2)
				{
					Debug.Log ("Hit more than one on HitLeft!");
				}
				if (hitRight.Length > 2)
				{
					Debug.Log ("Hit more than one on HitRight!");
				}
			*/

			
		}
	}

	void DestroyFourBlocks()
	{
		Rigidbody clone;
		clone = Instantiate (prefabDestroyFour, transform.position, transform.rotation) as Rigidbody;
		clone.velocity = transform.TransformDirection (Vector3.down * destroySpeed);
		clone.name = gameObject.name;
	
	}


}
