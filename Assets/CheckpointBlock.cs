using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointBlock : MonoBehaviour {

	private GlobalControl globalControl;
	// Use this for initialization
	void Start () {
		globalControl = FindObjectOfType<GlobalControl> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col) 
	{
		if (col.CompareTag ("Player")) 
		{
			globalControl._currCheckpointLocation = transform.position;
		}
	}


}
