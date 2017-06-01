using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ericL_SequenceCompleted_DeleteBlock : MonoBehaviour {

	public GameObject[] toDelete;

	void reward()
	{
		foreach (GameObject i in toDelete) 
		{
			i.SetActive (false);
		}
	}
}
