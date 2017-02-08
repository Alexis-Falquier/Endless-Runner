using UnityEngine;
using System.Collections;

public class DisapearingPlatform : MonoBehaviour {

	//boolean for platform to start falling
	bool falling;
	//float to use as counter
	float count;

	// Use this for initialization
	void Start () {
		//set values
		falling = false;
		count = 0f;
	}
	
	//runs when something collides with the platform
	void OnCollisionEnter (Collision other) {
		//checks to see if it is the marble (player)
		if (other.gameObject == GameObject.Find ("Marble")) {
			//if so set falling to true
			falling = true;

		}
	
	}
	//runs once per frame
	void Update (){
		//checks if player has touched it
		if (falling == true) {
			//if so starts a counter
			count += Time.deltaTime; 
		}
		//checks if counter has reched half a second
		if (count > 0.5f) {
			//if so the platform start falling down
			transform.Translate (Vector3.down * 3f * Time.deltaTime);
		}
	}
		
}
