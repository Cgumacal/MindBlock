using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ericL_AIRightsBlock : MonoBehaviour {

	void OnTriggerEnter(Collider block)
	{
		ericL_Swappable canSwap = block.GetComponent<ericL_Swappable> ();
		Debug.Log ("blocked");
		if (canSwap != null) 
		{
			Debug.Log ("blocked");
			canSwap.NoSwap ();
		}
	}

	void OnTriggerExit(Collider block)
	{
		ericL_Swappable canSwap = block.GetComponent<ericL_Swappable> ();

		if (canSwap != null) 
		{
			canSwap.AllowSwap ();
		}
	}
}
