using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ericL_BlockInSequence : MonoBehaviour {

	//INSTRUCTIONS:   place the SequenceBlocks.cs script onto the block to manage the 'key' blocks to be placed in a sequence
	//                you will be able to manage the inspector from the block with the SequenceBlocks.cs script

	//                BlockInSequence.cs is to be placed on the TRIGGER of a block
	//                blocks with the BlockInSequences.cs script on them will be placed in the order they are entered into the SequenceBlocks.cs inspector
	//                this order will be how to unlock the 'completed' task

	//                the reward for completing a task will be from ANY gameobject's script that has a function name of 'reward'
	//                the gameobject containing the script with 'reward' must be placed within the SequenceBlocks.cs inspector

	//                the 'reward' function is called throught the function <gameObjectName>.SendMessage(" nameofmethod ");


	public bool isTriggered = false;

	public ericL_SequenceBlocks testOrder;

	//Activates the item to begin sequence
	void OnTriggerEnter()
	{
		isTriggered = true;
		//Tests trigger order
		testOrder.testOrder ();
	}

	//Changes the value of item to activate to false (to reset search for sequence)
	public void wrongOrder()
	{
		isTriggered = false;
	}
}
