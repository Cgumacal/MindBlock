using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTo : MonoBehaviour {
    private Camera m_Player = null;
	// Use this for initialization
	void Start () {
        while (m_Player == null)
        {
            m_Player = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Camera>();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Vector3 Teleport()
    {
        return transform.position;
        //return m_Player.transform.parent.transform.position;
    }
}
