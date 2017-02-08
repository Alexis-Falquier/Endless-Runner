using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	public Transform Front_Connector;
	public Transform Back_Connector;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public Transform GetFrontHook()
	{
		return Front_Connector.transform;
	}

	public Vector3 GetBackHook_OffsetPosition()
	{
		return Back_Connector.position;
	}
}
