using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointBlock : MonoBehaviour {

	private GlobalControl globalControl;
	// Use this for initialization
	void Start () {
		globalControl = FindObjectOfType<GlobalControl> ();
	}

	// Update checkpoint location when player enters checkpoint block
	void OnTriggerEnter(Collider col) 
	{
		if (col.CompareTag ("Player")) 
		{
			globalControl.currCheckpointLocation = transform.position;
		}
	}


}
