using UnityEngine;
using System.Collections;

public class ScoreBooster : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	//runs when a collision happens
	void OnCollisionEnter (Collision other) {
		//checks if said collision is with the player (marble)
		if (other.gameObject == GameObject.Find ("Marble")) {
			//if so access score manager to activate the score boost
			ScoreManager manager = GameObject.Find ("ScoreManager").GetComponent<ScoreManager> ();
			manager.ScoreBoost();
		}
	
	}
}
