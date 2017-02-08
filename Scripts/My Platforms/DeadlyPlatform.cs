using UnityEngine;
using System.Collections;

public class DeadlyPlatform : MonoBehaviour {


	// Use this for initialization
	void Start () {

	
	}
	
	//checks to see if something has collided with the object
	void OnCollisionEnter (Collision other) {
		//checks if said object is the player (marble)
		if (other.gameObject == GameObject.Find ("Marble")) {
			//if so it calls the death function on the player controller
			PlayerController controller = GameObject.Find ("Marble").GetComponent<PlayerController> ();
			controller.Death ();
		}
	}
}
