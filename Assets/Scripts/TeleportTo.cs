using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTo : MonoBehaviour {
    private Camera m_Player = null;

	//float value to limit the maximum amount of spaces the player can teleport from
	//       fyi - block distance (standard) is .5 x y and z
	public float maxTeleRadius;

	// Use this for initialization
	void Start () {
		maxTeleRadius = 3f;
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
		//if the distance between point a and point b is greater than the set max
		//dont allow a teleport
		//float distance = Vector3.Distance (transform.position, m_Player.transform.parent.transform.position);

		/*if (distance > maxTeleRadius) 
		{
			return m_Player.transform.parent.transform.position;
		}*/
			
		//else teleport
		return transform.position;
    }
}
