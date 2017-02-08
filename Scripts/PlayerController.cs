using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float marbleSpeedRotation;
	public float marbleHorzForce;
	public float jumpForce;

	public Transform respawn;

	//float value to increase speed as time goes by
	float increaseSpeed;


	Rigidbody body;


	// Use this for initialization
	void Start () {
		//set my increase speed value to 0
		increaseSpeed = 0f;

	
		body = GetComponent<Rigidbody> ();


	}
	
	// Update is called once per frame
	void FixedUpdate () {

		JumpCheck ();

		UserMovement ();

		ForwardMovement ();

		if (transform.position.y < -10) {
			Death ();
		}
	}
		
	void JumpCheck()
	{


		if (Input.GetButton ("Jump")) {
		
			bool grounded = false;

			Vector3 right = Quaternion.AngleAxis (0, Vector3.forward) * Vector3.right;
			right *= 0.6f;
			right += transform.position;

			grounded = Physics.Linecast (transform.position, right);
			if (grounded) {
				right = new Vector3 (-right.x, 0, 0);
				right.Normalize ();

				body.AddForce (right * jumpForce); 
				body.AddForce (Vector3.up * (jumpForce));

				grounded = false;
			}




			Vector3 left = Quaternion.AngleAxis (180, Vector3.forward) * Vector3.right;
			left *= 0.6f;
			left += transform.position;

			grounded = Physics.Linecast (transform.position, left);
			if (grounded) {
				left = new Vector3 (-left.x, 0, 0);
				left.Normalize ();

				body.AddForce (left * jumpForce); 
				body.AddForce (Vector3.up * (jumpForce));

				grounded = false;
			}


			Vector3 up = Quaternion.AngleAxis (90, Vector3.forward) * Vector3.right;
			up *= 0.6f;
			up += transform.position;

			grounded = Physics.Linecast (transform.position, up);
			if (grounded) {
				up = new Vector3 (0, up.y, 0);
				up.Normalize ();

				body.AddForce (up * jumpForce); 

				grounded = false;
			}


			Vector3 down = Quaternion.AngleAxis (270, Vector3.forward) * Vector3.right;
			down *= 0.6f;
			down += transform.position;

			grounded = Physics.Linecast (transform.position, down);
			if (grounded) {
				down = new Vector3 (0, down.y, 0);
				down.Normalize ();

				body.AddForce (down * jumpForce); 

				grounded = false;
			}
		}

	}



	void UserMovement()
	{

		float h = Input.GetAxis ("Horizontal");

		Vector3 hMovement = Vector3.right * h * marbleHorzForce * Time.deltaTime;

		body.AddForce (hMovement, ForceMode.Force);
	}
		

	void ForwardMovement (){
		//increase the value with delta time to multiply with marbleSpeed
		increaseSpeed += Time.deltaTime;
		// Here I multiply the marble speed with my new value, I divide it by 10 so it does not increase so quickly
		//but will guarantee a gradual increase in dificulty
		float newSpeed = (increaseSpeed / 10) + marbleSpeedRotation;
		//make the player move forward with this new speed value
		body.AddForce (Vector3.forward * newSpeed, ForceMode.Force);
	}

	//public function that will be called by the fast platform
	public void startSpeedUp(){
		//will start the coroutine
		StartCoroutine (SpeedUp ());
	}
	//coroutine to speed up the game temporarily
	IEnumerator SpeedUp (){
		//set timescale to 1.5 to speed game up
		Time.timeScale = 1.5f;
		//I call a yield waitforseconds which will essentially pause this function for the time given
		//since it is affected my timescale i give it a value of 10 seconds but will last less than that
		yield return new WaitForSeconds (10f);
		//once over timescale is returned to normal
		Time.timeScale = 1f;
			
	}
	//public function that will be called by the slow platform
	public void startSlowDown(){
		//will start the coroutine
		StartCoroutine (SlowDown ());
	}
	//corooutine to slow down the game temporarily
	public IEnumerator SlowDown(){
		//set timescale to 0.5 to slow down the game
		Time.timeScale = 0.5f;
		//I call a yield waitforseconds which will essentially pause this function for the time given
		//since it is affected my timescale i give it a value of5  seconds but will last longer than that
		yield return new WaitForSeconds (5f);
		//once over timescale is returned to normal
		Time.timeScale = 1f;
		
	}


	public void Death()
	{
		//I took this away as 1. with a menu I didnt need to respawn
		//2. with the platforms disapearing behind the marble as it moves means there is no more platform at respawn
//		body.velocity = Vector3.zero;
//		transform.position = respawn.position;

		//I set timescale back to normal in case player dies during a speed up or slow down
		Time.timeScale = 1f;
		//access score manager to indicate player has falled, so it stores the score values
		ScoreManager scoreManager = GameObject.Find ("ScoreManager").GetComponent<ScoreManager> ();
		scoreManager.hasFallen ();
		//load the menu scene, so player can see their score, and choose what to do next
		SceneManager.LoadScene ("Menu");

	}

}
