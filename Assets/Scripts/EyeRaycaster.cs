using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeRaycaster : MonoBehaviour {
    [SerializeField] private Reticle m_Reticle;
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
            if (m_Reticle) {
                Debug.Log(hit);
                m_Reticle.SetPosition(hit);
            }
            if (interactable && interactable != mLastInteractible)//being looked at right now
            {
                interactable.Staring();
                
                if(mLastInteractible != null)
                {
                    mLastInteractible.Out();
                }
                mLastInteractible = mCurInteractible;
                
                //hit.collider.gameObject.GetComponent<UnityEngine.UI.Button>().Select();
            }
            if (interactable != mLastInteractible)//deactivate the last one
            {
                mLastInteractible.Out();
                mLastInteractible = null;
            }
            
        }
        else
        {
            if (mLastInteractible != null)//we stopped looking at the thing
            {
                mLastInteractible.Out();
                mLastInteractible = null;
                if (m_Reticle) {
                    m_Reticle.SetPosition();
                }
            }
        }
	}
}
