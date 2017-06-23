using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ericL_Swappable : MonoBehaviour {

	public bool canSwap;
	public bool alwaysSwappable;

	void Start()
	{
		canSwap = true;
	}

	public bool GetCanSwap()
	{
		return canSwap;
	}

	public void NoSwap()
	{
		if (!alwaysSwappable) 
		{
			canSwap = false;
		} 
		else
			canSwap = true;
	}

	public void AllowSwap()
	{
		canSwap = true;
	}
}
