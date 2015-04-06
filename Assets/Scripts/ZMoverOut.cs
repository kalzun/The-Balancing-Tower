using UnityEngine;
using System.Collections;

public class ZMoverOut : MonoBehaviour 
{
	private Vector3 screenPoint;
	private Vector3 origPos;
	private Vector3 newPos;


	void OnMouseDown()
	{

		origPos = transform.parent.position;
		screenPoint = Camera.main.WorldToScreenPoint(transform.parent.position);
		
		newPos = new Vector3 (transform.parent.position.x, transform.parent.position.y, origPos.z + 0.5f);
		transform.parent.position = newPos;
		
	}

}
