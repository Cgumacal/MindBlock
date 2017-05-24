﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour {
    [SerializeField] private float fallSpeed = 1;
    [SerializeField] private float fallDelay = 2;

    private bool falling = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (falling)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - fallSpeed * Time.deltaTime, transform.position.z);
        }
	}
    
    void OnTriggerEnter(Collider col)
    {
        if(col.transform.tag == "Player")
        {
            StartCoroutine(Delay(fallDelay));
            
        }
    }

    IEnumerator Delay(float time)
    {
        yield return new WaitForSeconds(time);
        falling = true;
        // Code to execute after the delay
    }

}
