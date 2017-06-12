using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeRaycaster : MonoBehaviour {
    public Camera camera;
    private RaycastHit hit;
    private VRInteractiveItem mCurInteractible, mLastInteractible;
	// Use this for initialization
	void Start () {
		
	}

    //Works! requires some kind of feedback showing that you are staring at something
	void Update () {
        Physics.Raycast(camera.transform.position, camera.transform.forward, out hit);

        if (hit.collider)
        {
            VRInteractiveItem interactable = hit.collider.GetComponent<VRInteractiveItem>();
            mCurInteractible = interactable;
            if (interactable && interactable != mLastInteractible)//being looked at right now
            {
                Debug.Log("COuNTING!!@#!@#!@#");
                interactable.Staring();
                mLastInteractible = mCurInteractible;
                //hit.collider.gameObject.GetComponent<UnityEngine.UI.Button>().Select();
            }
            if(interactable != mLastInteractible)
            {
                //do something here? probably useless shit
                Debug.Log("stopped!!!@#!@");
                mLastInteractible.Out();
                mLastInteractible = null;
            }
            
        }
        else
        {
            if (mLastInteractible != null)//we stopped looking at the thing
            {
                Debug.Log("stopped!!!@#!@");
                mLastInteractible.Out();
                mLastInteractible = null;
            }
        }
	}
    private void DeactiveLastInteractible()
    {
        if (mLastInteractible == null)
            return;

        mLastInteractible.Out();
        mLastInteractible = null;
    }
}
