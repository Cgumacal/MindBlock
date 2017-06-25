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
			Debug.Log ("CLEARED SWITCHABLE BLOCKS");
			blockToSwitch = null;
			blockSwitchWith = null;
		}

		LookAtBlock ();

		if(blockToSwitch != null && blockSwitchWith != null)
			SwitchBlocks ();
	}


	//uses raycast to sense block that player is looking at
	public void LookAtBlock()
	{
		bool swap = false;
		bool needsParent = false;

		if (Physics.Raycast (player.transform.position, player.transform.forward, out hit)) 
		{
			ericL_Swappable canSwap = hit.transform.GetComponent<ericL_Swappable>();
			MovingCube isMoving = hit.transform.GetComponent<MovingCube> ();
				
			if (canSwap != null)//(hit.transform.CompareTag ("SwitchableBlock"))
			{
				swap = canSwap.GetCanSwap();
				Debug.Log ("COUNT STARTED");
				startCount = true;

				if (isMoving != null) 
				{
					needsParent = true;
				}
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
			Debug.Log ("CAN ATTEMPT SWITCH");
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
				if (swap)
				{
					Debug.Log ("ADDED");

					if (needsParent) 
					{
						if (blockToSwitch == null) 
						{
							blockToSwitch = hit.transform.parent.gameObject;
						} 
						else
							blockSwitchWith = hit.transform.parent.gameObject;
					}
					else
					{
						if (blockToSwitch == null)
						{
							blockToSwitch = hit.transform.gameObject;
						} 
						else
							blockSwitchWith = hit.transform.gameObject;
					}
				} 
				else if (!swap) 
				{
					Debug.Log ("HOW DARE YOU TRY TO SWAP ME");
				}
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
