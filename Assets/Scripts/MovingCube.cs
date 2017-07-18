using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour {
    [SerializeField] private GameObject Endpoint1;
    [SerializeField] private GameObject Endpoint2;
    [SerializeField] private float MoveSpeed = 0.5f;
    public bool canMove = true;
    private GameObject Target;
    // Use this for initialization
    void Start () {

        Target = Endpoint1;

	}
	
	// Update is called once per frame
	void Update () {
        if (canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, MoveSpeed * Time.deltaTime);
            ChangeTarget();
        }
	}

    void ChangeTarget()
    {
        if (transform.position == Endpoint1.transform.position)
        {
            Target = Endpoint2;
        }
        else if (transform.position == Endpoint2.transform.position)
        {
            Target = Endpoint1;
        }
        
    }
}
