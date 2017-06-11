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
            if (interactable && interactable != mLastInteractible)
            {
                interactable.Staring();
                //hit.collider.gameObject.GetComponent<UnityEngine.UI.Button>().Select();
            }
            if(interactable != mLastInteractible)
            {

            }
        }
        else
        {
            //mLastInteractible.gameObject.GetComponent<UnityEngine.UI.Button>();
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
