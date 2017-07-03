using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlockTrigger : MonoBehaviour {
    public GameObject movingblock;
	// Use this for initialization
	void Start () {
        movingblock.GetComponentInChildren<MovingCube>().canMove = false;
	}
	
    public void Activate()
    {
        movingblock.GetComponentInChildren<MovingCube>().canMove = !movingblock.GetComponentInChildren<MovingCube>().canMove;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
