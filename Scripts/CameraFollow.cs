using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {


	public Transform target;
	public float chaseSpeed;

	//I added y value to camera script so it follows the marble when it jumps aswell

	float z_offset;
	float x_offset;
	float y_offset;

	// Use this for initialization
	void Start () {
	
		z_offset = transform.position.z - target.position.z ;
		x_offset = transform.position.x - target.position.x ;
		//set the y value offset as with the z and x
		y_offset = transform.position.y - target.position.y ;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		float distanceZ =  transform.position.z - target.position.z;
		float new_z_offset = Mathf.Lerp (distanceZ, z_offset, chaseSpeed);

		float distanceX =  transform.position.x - target.position.x;
		float new_X_offset = Mathf.Lerp (distanceX, x_offset, chaseSpeed);

		//set the updating offset for y between the camera and marble as with the x an z values
		float distanceY =  transform.position.y - target.position.y;
		float new_Y_offset = Mathf.Lerp (distanceY, y_offset, chaseSpeed);

		//added said y offset to the new transform
		transform.position = new Vector3 (target.position.x + new_X_offset,
			target.position.y + new_Y_offset, target.position.z + new_z_offset);

	}
}
