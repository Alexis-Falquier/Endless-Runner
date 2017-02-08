using UnityEngine;
using System.Collections;

public class FastPlatform : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnCollisionEnter (Collision other) {
		//checks if said object is the player (marble)
		if (other.gameObject == GameObject.Find ("Marble")) {
			//if so it calls the speedup function in controller that will start the coroutine to speed up the game temporarily
			PlayerController controller = GameObject.Find ("Marble").GetComponent<PlayerController> ();
			controller.startSpeedUp (); 
		}
	}
}
