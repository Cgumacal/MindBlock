using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ericL_AIRightsBlock : MonoBehaviour {

	void OnTriggerEnter(Collider block)
	{
        block.GetComponent<TeleportTo>().canSwap = false; ;

	}

	void OnTriggerExit(Collider block)
	{
        block.GetComponent<TeleportTo>().canSwap = true;

    }
}
