using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	//Main menu UI elements
	public Text highScore;
	public Button play;
	public Button exit;
	public Text score;
	public Button reset;
		

	// Use this for initialization
	void Start () {
		//Access the sotrage singleton score value and display the score that was last achieved 
		//(0 if it jus started up)
		score.text = "Score: " + storage.Instance ().storedScore;
		//Access the storage singleton highscore value and display it
		highScore.text = "Highscore: " + storage.Instance().storedHighScore;
		
	
	}
	//function for when player clicks play
	public void playClick(){
		//using scene manager load the play scene
		SceneManager.LoadScene ("Room1");
	}
	//function for when player wants to reset the highscore
	public void resetScores(){
		//delete player prefs key where the score is stored when game is closed
		PlayerPrefs.DeleteKey("HighScore");
		//reset stored highscore value to 0
		storage.Instance ().storedHighScore = 0f;
		//display corrected text 
		highScore.text = "Highscore: " + storage.Instance().storedHighScore; 
		score.text = "Score: 0";
	}

	//function for when player clicks exit
	public void exitClick(){
		//save the highscore on player prefs so it will appear next time the game is opened
		PlayerPrefs.SetFloat ("HighScore", storage.Instance ().storedHighScore);
		//quits the game completely
		Application.Quit ();

	}
	
}
