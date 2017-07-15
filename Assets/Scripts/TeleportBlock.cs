using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBlock : TeleportTo{
    public bool powered = false;
    public GameObject pair;
    
    public override Vector3 Teleport() {
        if (transform.Find("Player")) {
            return pair.transform.position;
        }
        else {
            return transform.position;
        }
        
    }
	
}
