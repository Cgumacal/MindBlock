using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour {
    [SerializeField] private Transform Endpoint1;
    [SerializeField] private Transform Endpoint2;
    [SerializeField] private float MoveSpeed = 0.5f;
    private Vector3 Target;
    // Use this for initialization
    void Start () {

        Target = Endpoint1.position;

	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, Target, MoveSpeed * Time.deltaTime);
        ChangeTarget();
	}

    void ChangeTarget()
    {
        if (transform.position == Endpoint1.position)
        {
            Target = Endpoint2.position;
        }
        else if (transform.position == Endpoint2.position)
        {
            Target = Endpoint1.position;
        }
        
    }
}
