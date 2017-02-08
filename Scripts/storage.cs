using UnityEngine;
using System.Collections;

public class storage : MonoBehaviour {

	//values for score and highscore
	public float storedHighScore;
	public float storedScore;

	void Start (){

		//set values for first startup of the game
		storedScore = 0f;

	
	}

	//This will be a singleton
	//create a static instance for this singleton
	private static storage instance;
	//create a public function to access the instance and therefore the stored values
	public static storage Instance()
	{
		//will return the instance that is set on Awake()
		return instance;
	}


	//called when script is created in the game
	void Awake(){
		//set highscore to the stored value in player prefs 
		//if this is the first time running it will default to 0
		storedHighScore = PlayerPrefs.GetFloat ("HighScore",0f); 
		//if this is the first time it is created (when the game first starts up)
		//there should be no instance
		//this checks to see if that is the case
		if (instance == null) {
			//if so, then this (the original storage) will become the instance
			instance = this;
		//If there already exists an instance AND that instance is not this storage
		//that means that this is not the original storage, and will be destroyed
		//thus keeping only the singleton (the original storage)
		} else if(instance != this) {
			Destroy (gameObject);
		}
		//if this was not destroyed in the statements above, this means it is the original storage
		//therefore it should not be destroyed between scenes, so we call DontDestroyOnLoad
		//this way the score can be kept between the menu and play scene
		DontDestroyOnLoad (gameObject);


	}

}
