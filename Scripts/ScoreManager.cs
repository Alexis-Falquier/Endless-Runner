using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	//text elements
	public Text scoreText;
	public Text highScoreText;
	public Text scoreBoostText;

	//will set this to spwan point, to be able to use distance between this and the player as score instead of time
	public Transform startPoint;
	Transform marble;

	float score;
	float highScore;

	//multiplier float
	float multiplier;




	// Use this for initialization
	void Start () {
		//access storage value for current highScore
		highScore = storage.Instance().storedHighScore;
		//get the marbles transform to be able to measure the distance it has moved
		marble = GameObject.Find ("Marble").transform; 
		//set score to 0
		score = 0;
		//Display current Highscore
		highScoreText.text = "Highscore: " + highScore;
		//shows score value
		scoreText.text = "Score: " + score;
		//multiplier to 1 at first
		multiplier = 1f; 
		//disable the boost text
		scoreBoostText.enabled= false;
	
	}

	void FixedUpdate() {
		//I originally used time, but thought distance would be better way to keep score
		//score += (Time.deltaTime * 10000f);

		// measure the distance between the start point and the player assign it to score, 
		//(I round it and multiply by 100 to make it look nicer)
		score = (Mathf.Round(Vector3.Distance(startPoint.position, marble.position)) * 100f);
		//score boost
		score *= multiplier; 
		//display the score
		scoreText.text = "Score: " + score;
		//checks if score is higher than highscore
		if (score > highScore) {
			//if so set highscore to score
			highScore = score;
			//Display this highscore
			highScoreText.text = "Highscore: " + highScore;
		}

	}
	//public score boost function accesed by scorebooster platform
	public void ScoreBoost(){
		//if it is the first multiplier set value to *2 and display multiplier text acordingly
		if (multiplier == 1f) {
			multiplier = 2f;
			scoreBoostText.enabled = true;
			scoreBoostText.text = "x" + multiplier + "!!!";
		//if it is not the first time player got score boost add 2 to the multiplier and display multiplier text accordingly
		} else {
			multiplier += 2f;
			scoreBoostText.text = "x" + multiplier + "!!!";
		}

	}

	//public function accessed by playercontroller, activated when player falls off
	public void hasFallen(){
		//access the storage singleton and update the value for the Score reached this game
		storage.Instance ().storedScore = score;
		//access the storage singleton and update the value for the highScore
		storage.Instance().storedHighScore = highScore;

	}

}
