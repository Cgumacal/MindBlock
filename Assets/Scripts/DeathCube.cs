using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCube : MonoBehaviour {

	void OnTrigger(Collider col)
    {
        if(col.transform.tag == "Player")
        {
            Debug.Log("Dead");
        }
    }
}
