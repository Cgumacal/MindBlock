using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour {
    [SerializeField] private float fallSpeed = 1;
    [SerializeField] private float fallDelay = 2;
    private Collider stoppingBlock;

    private bool falling = false;
    private bool canFall = true; 
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
        
        if(col.transform.tag == "Player" && canFall)
        {
            StartCoroutine(Delay(fallDelay));
            
        }
        if (col.transform.tag == "Environment")
        {
            stoppingBlock = col;
            falling = false;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col == stoppingBlock)
        {
            canFall = true;
        }
    }

    IEnumerator Delay(float time)
    {
        yield return new WaitForSeconds(time);
        falling = true;
        canFall = false;
        // Code to execute after the delay
    }

}
