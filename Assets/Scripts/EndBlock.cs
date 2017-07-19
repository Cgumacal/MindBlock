using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBlock : MonoBehaviour {

    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnTriggerEnter(Collider col)
    {
        if(col.transform.tag == "Player")
        {
            Debug.Log("Win");
            player.GetComponent<FPScontroller>().LevelComplete();
        }
    }
}
