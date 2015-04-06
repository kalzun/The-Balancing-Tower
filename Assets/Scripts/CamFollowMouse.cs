using UnityEngine;
using System.Collections;

public class CamFollowMouse : MonoBehaviour 
{
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 };
	public RotationAxes axes = RotationAxes.MouseXAndY; 
	public float sensitivityX = 15F; 
	public float sensitivityY = 15F;
	public float minimumX = -360F;
	public float maximumX = 360F;
	
	public float minimumY = -60F;
	public float maximumY = 60F;
	
	float rotationY = 0F;

	// Look at Hemisphere
	public Transform target;
	// Look at Spawn
	public Transform targetSpawn;
	
	void Update ()
	{

		// transform.LookAt (target);
		// transform.LookAt (targetSpawn);

		// Draw mouseRay from main camera

		Ray mouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		// Stores all objects hit by raycasts in list hit
		RaycastHit[] hit;
		hit = Physics.RaycastAll (mouseRay);

		// Debug.DrawRay (Camera.main.transform.position, mouseRay.direction * 10, Color.cyan);

		if (Input.GetMouseButtonDown (0))				// (Physics.Raycast	(mouseRay, out hit))
		{
			// If ray hits something when clicking mouse,
			// it checks the length of the list, of which stores all the hit objects, and 
			// shares its name
			if (hit.Length > 0)
			{
				for (int i = 0; i < hit.Length; i++)
				{
					// Debug.Log ("MouseRay looks at " + hit[i].transform.name + ". Distance is " + hit[i].distance);
				}
			}
			// 	Debug.Log ("Mouse looks at " + hit.transform.name);
		}

		/* ROTATE WITH MOUSE:
		if(Input.GetMouseButton (0)) {
			if (axes == RotationAxes.MouseXAndY) {
				float rotationX = new float();
				
				if(transform.parent != null && transform.parent.CompareTag("Player") == true) {
					rotationX = transform.parent.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
					
					rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
					rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
					
					transform.parent.transform.localEulerAngles = new Vector3(0, rotationX, 0);
					transform.localEulerAngles = new Vector3(-rotationY, 0, 0);
					
				}
				else if(transform.parent != null) {
					rotationX = transform.parent.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
					
					rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
					rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
					
					transform.parent.transform.localEulerAngles = new Vector3(0, rotationX, 0);
					transform.localEulerAngles = new Vector3(-rotationY, 0, 0);
				}
				/*
                 else {
                     rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
                     
                     rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                     rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
                     
                     transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
                 }

			}
			else if (axes == RotationAxes.MouseX) {
				if(transform.parent != null) {
					transform.parent.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
				}
				else {
					transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
				}
			}
			else {
				rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
				rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
				
				transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
			}
		}
*/

	}
}