using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ericL_Swappable : MonoBehaviour {

	public bool canSwap;
	public bool alwaysSwappable;
	public bool neverSwap;

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
		if (!alwaysSwappable || neverSwap) 
		{
			canSwap = false;
		} 
		else
			canSwap = true;
	}

	public void AllowSwap()
	{
		if (!neverSwap) 
		{
			canSwap = true;
		} 
		else
			canSwap = false;
	}
}
