using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ericL_PopoutBlock : MonoBehaviour {

	//FYI : AUTOSNAP FEATURE OF THE MAP EDITOR WILL MOVE THE TRIGGER FOR THIS OBJECT INSIDE OF THE BLOCK ITSELF, MAKING IT UNREACHABLE
	//      SO IF THAT HAPPENS, MAKE SURE TO MOVE IT BACK INTO A REACHABLE PLACEMENT, IT IS LABELED AS THE TRIGGER


	//INSTRUCTIONS -         once the Popoutblock.cs script is placed onto the TRIGGER of an object, place the block you wish to be spawned in
	//                       dispensedBlock,   place a gameObject without a renderer to use for its transform location in slots created under
	//                       spawnPoints,      edit the duration value to increase or decrease the duration of spawned blocks before despawn

	//                       not all blocks have been tested with use of PopoutBlock, there may still be bugs

	//Declare what block type to spawn in inspector
	public GameObject dispensedBlock;
	//Declare spawn points of blocks to be spawned in inspector by creating spawn point objects in the game screen and placing in the inspector
	public GameObject[] spawnPoints;
	//Time before objects are deleted from creation
	public float duration = 5f;
	//To temporarilly hold the block to be instantiated / created into the game screen
	private List<GameObject> summonedBlock = new List<GameObject>();

	bool isColliding = false;

	void OnTriggerEnter(Collider col)
	{
		if (isColliding)
			return;
		isColliding = true;
		Invoke ("spawnBlocks", 0);
	}

	void spawnBlocks()
	{
		foreach (GameObject i in spawnPoints) {
			var newBlock = ((GameObject)Instantiate (dispensedBlock, i.transform.position, i.transform.rotation));
			summonedBlock.Add(newBlock);
			newBlock.transform.parent = i.transform;

			Invoke ("deleteBlocks", duration);
			//Destroy (summonedBlock, duration);
		}
	}
	//To delete block object without deleting player on top of block
	void deleteBlocks()
	{
		Transform tempPlayer = findPlayer ();

		if (tempPlayer != null) {
			if (tempPlayer.name == "Player") {
				Debug.Log ("DEPARENTED");
				tempPlayer.parent = null;
			}
		}

		foreach (GameObject i in summonedBlock) {
			Destroy (i);
		}
		summonedBlock.Clear ();
	}

	Transform findPlayer()
	{
		foreach (GameObject i in summonedBlock) {
			if (i.transform.Find ("Player") != null) {
				return i.transform.Find ("Player");
			}
		}

		return null;
	}
}
