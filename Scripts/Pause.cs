using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

	//pause menu UI elements
	public Button pause;
	public Button cont;
	public Button restart;
	public Button exit;
	public Canvas pauseMenu;


	// Use this for initialization
	void Start () {
		//set my menu to its respective canvas
		pauseMenu = pauseMenu.GetComponent<Canvas>();
		//set the buttons so I can manipulate them
		cont = cont.GetComponent<Button>();
		restart = restart.GetComponent<Button>();
		exit = exit.GetComponent<Button>();
		//disable pause menu so it is not visible when player starts playing
		pauseMenu.enabled = false;

	
	}
	//function for when the player clicks pause
	public void pauseClick(){
		//set timescale to 0 so everything stops running
		Time.timeScale = 0.0f;
		//enable the pause menu so all the buttons are visible
		pauseMenu.enabled = true;
		//enable all the buttons so they can be clicked
		cont.enabled = true;
		restart.enabled = true;
		exit.enabled = true;

	
	}
	//function for when player clicks continue from pause menu
	public void contClick(){
		//disables the pause menu so it is not visble anymore
		pauseMenu.enabled = false;
		//set timescale to 1 so game runs as normal again
		Time.timeScale = 1.0f;
		//disable all buttons to avoid them from being clicked while playing
		cont.enabled = false;
		restart.enabled = false;
		exit.enabled = false;
	}

	//funstion for when player clicks restart on pause menu
	public void restartClick(){
		//set timescale to 1 so game runs as normal again
		Time.timeScale = 1.0f;
		//call scene manager to load the scene again,
		//since there is no more platform at respawn calling the scene again will regenerate all the platforms again
		SceneManager.LoadScene ("Room1");


	}
	//function for when player clicks exit on pause menu
	public void exitClick(){
		//save the highscore on player prefs so it will appear next time the game is opened
		PlayerPrefs.SetFloat ("HighScore", storage.Instance ().storedHighScore); 
		//quits game completely
		Application.Quit ();
	}

		
}
