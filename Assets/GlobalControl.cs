using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour {


	public static GlobalControl Instance;
	public Vector3 _currCheckpointLocation;

	void Awake ()   
	{
		// Makes sure there is only one instance of this class
		if (Instance == null)
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy (gameObject);
		}
		// Debug.Log ("Should only happen once");


	}

	void Start() 
	{
		_currCheckpointLocation = FindObjectOfType<StartBlock> ().transform.position;
	}

	public Vector3 latestCheckpointLocation()
	{
		return _currCheckpointLocation;
	}


}
