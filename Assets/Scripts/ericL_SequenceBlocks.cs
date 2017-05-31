using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ericL_SequenceBlocks : MonoBehaviour {

	//INSTRUCTIONS:   place the SequenceBlocks.cs script onto the block to manage the 'key' blocks to be placed in a sequence
	//                you will be able to manage the inspector from the block with the SequenceBlocks.cs script

	//                BlockInSequence.cs is to be placed on the TRIGGER of a block
	//                blocks with the BlockInSequences.cs script on them will be placed in the order they are entered into the SequenceBlocks.cs inspector
	//                this order will be how to unlock the 'completed' task

	//                the reward for completing a task will be from ANY gameobject's script that has a function name of 'reward'
	//                the gameobject containing the script with 'reward' must be placed within the SequenceBlocks.cs inspector

	//                the 'reward' function is called throught the function <gameObjectName>.SendMessage(" nameofmethod ");



	//Creates list to test sequence order
	public List<ericL_BlockInSequence> order = new List<ericL_BlockInSequence>();
	private List<ericL_BlockInSequence> dupeOrder = new List<ericL_BlockInSequence> ();

	public GameObject finishedEvent;

	bool complete = false;

	void Start()
	{
		dupeOrder.AddRange (order);
	}

	//Test bool values of sequence objects
	public void testOrder()
	{
		//if there is a next in sequence
		if (order.Count != 0) 
		{
			//proceed to next in sequence
			if (order [0].isTriggered) 
			{
				order.RemoveAt (0);
			} 
			//reset sequence
			else if (!order [0].isTriggered) 
			{
				Debug.Log("wrong order");

				order = dupeOrder;
				foreach (ericL_BlockInSequence i in order)//sequence) 
				{
					i.wrongOrder ();
				}
			}
		} 
		//if there is none lift in the sequence, it is done
		if (!complete) 
		{
			if (order.Count == 0) 
			{
				Invoke ("completed", 0);
			}
		}
	}

	void completed()
	{
		Debug.Log ("DONE");

		complete = true;

		gameObject.SendMessage ("reward");
	}

}
