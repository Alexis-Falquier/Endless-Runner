using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileGenerator : MonoBehaviour {

	//set all the tiles to Tile class
	public Tile StartTile;

	public List<Tile> tiles = new List<Tile>();

	public int TileCount;

	private List<Tile> activeTileList = new List<Tile> ();
	private Tile backMostTile; 
	private Tile frontMostTile; 
	//marble to measure distances for generation and deletion purposes
	private Transform marble;



	void Awake()
	{

	}

	// Use this for initialization
	void Start () {
		//set and find appropriate tiles
		activeTileList.Add (StartTile);

		backMostTile = StartTile;

		GenerateNewTiles (StartTile.Front_Connector);

		frontMostTile = activeTileList [activeTileList.Count - 1];

		//find marble transform
		marble = GameObject.Find ("Marble").transform;

	}

	// Update is called once per frame
	void Update () {
		//find distance between the front most tile and the marble
		float frontDistance = (frontMostTile.transform.position - marble.position).magnitude;
		//find the distance between the back most tile and the marble
		float backDistance = (backMostTile.transform.position - marble.position).magnitude;
		//checks if the distance to the front most tile is less than 1000
		if (frontDistance < 1000f){
			//if it is then new tiles will be generated infront of it
			GenerateNewTiles (frontMostTile.Front_Connector);

		}
		//checks to see if the distance between the player and the back most tile is less than 100
		if(backDistance > 100f){
			//if so it calls DeleteTiles() which will delete the backmost tile
			DeleteTiles ();
		}

	}
	//function to delete tiles player has passed
	void DeleteTiles() {
		//set the last tile to the backmost tile in the active tile list
		Tile lastTile = activeTileList [0];
		//that tile will be removed from the list
		activeTileList.Remove(activeTileList[0]);
		//that tile will now be destroyed
		Destroy (lastTile.gameObject);
		//set backmost tile value to the new backmosttile in the active tile list
		backMostTile = activeTileList [0];
	}

	void GenerateNewTiles(Transform startPoint){

		Transform curConnector = startPoint;

		for (int i = 0; i < TileCount; i++) {
			Tile tile;

			int randomNum = Random.Range (0, tiles.Count);

			tile = tiles [randomNum];

			Vector3 offset = tile.GetBackHook_OffsetPosition ();
			Vector3 spawnPosition = curConnector.position - offset;

			GameObject obj = Instantiate (tile.gameObject, spawnPosition, tile.transform.rotation) as GameObject;

			tile = obj.GetComponent<Tile> ();

			curConnector = tile.GetFrontHook ();

			activeTileList.Add (tile);

		}

		frontMostTile = activeTileList [activeTileList.Count - 1];

	}
}
