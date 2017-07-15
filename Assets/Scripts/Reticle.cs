using UnityEngine;
using UnityEngine.UI;

public class Reticle : MonoBehaviour {

    [SerializeField]
    private float m_DefaultDistance = 5.0f;     //default distance the reticle will be placed when looking at nothing/far away
    [SerializeField]
    private bool m_UseNormal;                   //should the reticle be placed along a surface or just infront of it?
    [SerializeField]
    private Image m_Image;                      //the image that is the reticle
    [SerializeField]
    private Transform m_ReticleTransform;       //we need the transform of our reticle
    [SerializeField]    
    private Transform m_Camera;                 //we need the transform of the camera to place our reticle relatively

    private Vector3 m_OriginalScale;            //we are changing the scale of the reticle, so we need to keep the original
    private Quaternion m_OriginalRotation;      //same deal with rotation

    public bool UseNormal {
        get { return m_UseNormal; }
        set { m_UseNormal = value; }
    }

    public Transform ReticleTRansform {
        get { return m_ReticleTransform; }
    }

    private void Awake() {
        //saving original transform info
        m_OriginalRotation = m_ReticleTransform.localRotation;
        m_OriginalScale = m_ReticleTransform.localScale;
    }

    public void Hide() {
        m_Image.enabled = false;
    }

    public void Show() {
        m_Image.enabled = true;
    }

    //hitting nothing
    public void SetPosition() {
        m_ReticleTransform.position = m_Camera.position + m_Camera.forward * m_DefaultDistance; //default positions
        m_ReticleTransform.localScale = m_OriginalScale * m_DefaultDistance;
        m_ReticleTransform.localRotation = m_OriginalRotation;
    }

    //hitting something
    public void SetPosition(RaycastHit hit) {
        m_ReticleTransform.position = hit.point;
        m_ReticleTransform.localScale = m_OriginalScale * hit.distance;

        if (m_UseNormal) {
            m_ReticleTransform.rotation = Quaternion.FromToRotation(Vector3.forward, hit.normal); //rotate from our default forward towards the normal of the surface we just hit
        }
        else {
            m_ReticleTransform.localRotation = m_OriginalRotation;
        }
    }
}
