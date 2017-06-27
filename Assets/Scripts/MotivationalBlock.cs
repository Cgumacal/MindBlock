using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotivationalBlock : MonoBehaviour {
    private GameObject player;
    private FPScontroller controller;
    [SerializeField] private float AreaOfEffect = 3f;
    [SerializeField] private float increasedTeleportRange = 3f;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<FPScontroller>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(player.transform.position,transform.position) <= AreaOfEffect)
        {
            controller.setMaxTeleport(controller.defaultMaxTeleport + increasedTeleportRange);
        }
        else
        {
            controller.resetTeleportDistance();
        }
	}
}
