using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform objectToFollow;
	public Vector3 movementRatio = Vector3.one;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 newPosition = objectToFollow.position;
		newPosition.x *= movementRatio.x;
		newPosition.y *= movementRatio.y;
		newPosition.z *= movementRatio.z;
		transform.position = newPosition;

	}
}
