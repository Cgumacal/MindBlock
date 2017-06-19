using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ericL_SwapAbility : MonoBehaviour {

	/*
	 * instructions -
	 * 
	 * blocks that can be swapped must have the tag - swappable block - on them
	 * 
	 * you must look at the block for x, the set amount of time
	 * 
	 * right clicks add the block to the list to be swapped
	 * 
	 * right clicks over 2 will ALWAYS replace the second selected block
	 * 
	 * left cntrl on the keyboard will CLEAR all selected blocks
	 * 
	 * 
	*/

	GameObject blockToSwitch = null;
	GameObject blockSwitchWith = null;

	RaycastHit hit;

	bool startCount = false;
	bool canSelectSwitch = false;

	//time needed to look at block before swapping
	public float time = 4;
	float count;

	public Camera player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftControl)) 
		{
			blockToSwitch = null;
			blockSwitchWith = null;
		}

		LookAtBlock ();
		SwitchBlocks ();
	}


	//uses raycast to sense block that player is looking at
	public void LookAtBlock()
	{
		if (Physics.Raycast (player.transform.position, player.transform.forward, out hit)) 
		{
			Debug.Log ("hit");
			if (hit.transform.CompareTag ("SwitchableBlock"))
			{
				Debug.Log ("COUNT STARTED");
				startCount = true;
			}
		} 
		else 
		{
			startCount = false;
			count = time;
			canSelectSwitch = false;
		}

		if (count <= 0) 
		{
			Debug.Log ("SWITCH AVAILABLE");
			canSelectSwitch = true;
		}

		if (startCount) 
		{
			count -= Time.deltaTime;
		}

		if (canSelectSwitch) 
		{
			if (Input.GetMouseButtonDown (1)) 
			{
				Debug.Log ("ADDED");
				if (blockToSwitch == null) 
				{
					blockToSwitch = hit.transform.gameObject;
				}
				else
					blockSwitchWith = hit.transform.gameObject;
			}
		}
	}

	//swaps literal block locations
	public void SwitchBlocks()
	{
		var temp = blockToSwitch.transform.position;

		if (blockToSwitch != null && blockSwitchWith != null) 
		{
			blockToSwitch.transform.position = blockSwitchWith.transform.position;
			blockSwitchWith.transform.position = temp;

			blockToSwitch = null;
			blockSwitchWith = null;
		}
	}

}
