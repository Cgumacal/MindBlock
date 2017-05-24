using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetInput();
	}

    private void GetInput()
    {

        if (Input.GetButtonDown("Tap"))
        {
            RaycastHit hit;
            TeleportTo teleport;
            Physics.Raycast(transform.position, transform.forward, out hit);
            Debug.DrawRay(transform.position, transform.forward, Color.red, 1000);
            Debug.Log(hit.transform.name);
            if (teleport = hit.transform.gameObject.GetComponent<TeleportTo>())
            {
                transform.position = teleport.Teleport();
            }
        }
    }
}
