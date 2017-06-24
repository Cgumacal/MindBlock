using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel : MonoBehaviour {
    [SerializeField] private float resetHeight = -2f;
	private GlobalControl _globalControl;

	// Use this for initialization
	void Start () {
		_globalControl = GameObject.FindObjectOfType<GlobalControl> ();
		Debug.Log ("In PLayer Start");
		Debug.Log ("Player position @ " + transform.position);
		transform.position = FindObjectOfType<GlobalControl>()._currCheckpointLocation;
		Debug.Log ("Chechpoint @ " + FindObjectOfType<GlobalControl> ()._currCheckpointLocation);
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < resetHeight)
        {
			LevelManager.ResetLevel();

        }
	}
}
