using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTrail : MonoBehaviour
{
    public Camera m_Camera;
    public void CreateCollider()
    {
        //Create collider along raycast
        if (Input.GetButtonUp("Tap"))
        {

            RaycastHit hit;
            //TeleportTo teleport;
            Physics.Raycast(m_Camera.transform.position, m_Camera.transform.forward, out hit);
            Debug.DrawRay(m_Camera.transform.position, m_Camera.transform.forward, Color.red, 1000);
            //Debug.Log(hit.transform.name);
            //transform.position = transform.position + m_Camera.transform.forward;
            if (hit.transform.gameObject.GetComponent<TeleportTo>())
            {
                transform.position = hit.transform.gameObject.GetComponent<TeleportTo>().Teleport();
                transform.parent = hit.transform;
            }
        }
    }
}
    

