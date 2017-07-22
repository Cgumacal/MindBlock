using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderCrossingCube : MonoBehaviour {
    [SerializeField] private int BorderNum = 0;

	/*void Start()
    {
        TeleportTo[] transfers = GameObject.FindObjectsOfType<TeleportTo>();
        foreach(TeleportTo x in transfers)
        {
            if( Vector3.Distance(x.transform.position, transform.position) < 2){
                x.setBorderNum(BorderNum);
            }
        }
    }*/

    void Start()
    {
        GetComponent<TeleportTo>().setBorderNum(BorderNum);
    }
        
    

	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Trigger called");
        if (col.gameObject.GetComponent<TeleportTo>())
        {
            Debug.Log("has teleport");
            col.gameObject.GetComponent<TeleportTo>().setBorderNum(BorderNum);
        }
    }
    
    void OnTriggerExit(Collider col)
    {
        if (col.GetComponent<TeleportTo>())
        {
            col.GetComponent<TeleportTo>().setBorderNum(0);
        }
    }
}
