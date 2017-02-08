using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	//set transforms for points it will move to and from
	public Transform startPoint;
	public Transform endPoint;
	//public float for speed setting
	public float speed = 1.0f;

	// Use this for initialization
	void Start () {
		//set the start point to current position of platform
		startPoint.position = transform.position;
	}

	// Update is called once per frame
	void Update () {

		//set the direction of travel for the platform (from start point to end point)
		Vector3 directionMovement = endPoint.position - startPoint.position;
		//normalize the direction so it is only the direction and wont "teleport" from the start and end point
		directionMovement.Normalize ();
		//multiply direction by 0.1 so it moves gradually and not in bursts
		//multiply by speeed so it moves quicker or slower depending on value
		directionMovement *= 0.1f * speed;
		//add movementdirection to the position so the platform moves
		transform.position += directionMovement;
		//make direction movement value between end point and current position to be able to measure the distance to the end point
		directionMovement = endPoint.position - transform.position;
		//find the distance between end point and current position
		float distance = directionMovement.magnitude;
		//checks if that distance is less than 0.1
		if (distance < 0.1f) {
			//if so the cube will change direction and head back to the start point
			//to do this set a new start point to the end point
			Transform newStartPoint = endPoint;
			//set the end point to the previous start point
			endPoint = startPoint;
			//set the start point to the new start point which was the old end point
			startPoint = newStartPoint;
		}
	}
}
