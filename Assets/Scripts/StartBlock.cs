using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBlock : MonoBehaviour {
    private GameObject m_Player;
	// Use this for initialization
	void Start () {
        m_Player = GameObject.FindGameObjectWithTag("Player");
        m_Player.transform.position = transform.position + new Vector3(0, 0.5f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
