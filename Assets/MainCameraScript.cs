using UnityEngine;
using System.Collections;

public class MainCameraScript : MonoBehaviour 
{
	public Camera mainCam;

	private Vector3 oldRotation;	
	private float newRotationX = 36f;

	private Vector3 oldPosition;
	private float newPositionZ = -4.0f;



	void Awake()
	{
		mainCam = GameObject.Find ("MainCamera").GetComponent<Camera> ();
		if (mainCam == null)
			Debug.LogWarning ("mainCam-reference is not set correctly!");
	}

	void Start()
	{
		oldRotation = mainCam.transform.eulerAngles; 
		oldPosition = mainCam.transform.position;
		StartCoroutine ("Lerp");
	}

	IEnumerator Lerp() 
	{
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / 4) 
		{	
			//s is a smoothed t
			float s = Mathf.SmoothStep (0.0f, 1.0f, t);
			//Spherical linear interpolation (Slerp) will give us a better rotation
			//if the rotations are far apart
			mainCam.transform.eulerAngles = new Vector3(Mathf.Lerp (oldRotation.x, newRotationX, s), oldRotation.y, oldRotation.z);
			mainCam.transform.position = new Vector3(oldPosition.x, oldPosition.y, (Mathf.Lerp (mainCam.transform.position.z, newPositionZ, s)));
			
			// Instantiate (endParticles, mainCam.transform.position, mainCam.transform.rotation);
			
			// yield return new WaitForSeconds(6);
			
			yield return null;
		}
	}
}
