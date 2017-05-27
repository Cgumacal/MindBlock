using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel : MonoBehaviour {
    [SerializeField] private float resetHeight = -2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < resetHeight)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
	}
}
