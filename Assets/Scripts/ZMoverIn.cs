using UnityEngine;
using System.Collections;

public class ZMoverIn : MonoBehaviour {

	Vector3 origPos;
	Vector3 newPos;
	Vector3 screenPoint;

	void OnMouseDown()
	{
		
		origPos = transform.parent.position;
		screenPoint = Camera.main.WorldToScreenPoint(transform.parent.position);
		
		newPos = new Vector3 (transform.parent.position.x, transform.parent.position.y, origPos.z - 0.5f);
		transform.parent.position = newPos;
		
	}
}
