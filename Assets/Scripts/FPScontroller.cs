using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class FPScontroller : MonoBehaviour {
    [SerializeField]private MouseLook m_MouseLook;
    public GameObject Ui;

    private Camera m_Camera;
    //private bool m_Jump;
    //private float m_YRotation;
    //private Vector2 m_Input;
    //private Vector3 m_MoveDir = Vector3.zero;
    private CharacterController m_CharacterController;
    //private CollisionFlags m_CollisionFlags;
    //private bool m_PreviouslyGrounded;
    private Vector3 m_OriginalCameraPosition;
    //private float m_StepCycle;
    //private float m_NextStep;
    //private bool m_Jumping;
    private AudioSource m_AudioSource;

    // Use this for initialization
    private void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
        m_Camera = Camera.main;
        m_OriginalCameraPosition = m_Camera.transform.localPosition;
        //m_FovKick.Setup(m_Camera);
        //m_HeadBob.Setup(m_Camera, m_StepInterval);
        //m_StepCycle = 0f;
        //m_NextStep = m_StepCycle / 2f;
        //m_Jumping = false;
        //m_AudioSource = GetComponent<AudioSource>();
        m_MouseLook.Init(transform, m_Camera.transform);
    }

    // Update is called once per frame
    void Update () {
#if UNITY_EDITOR
        RotateView();
#endif
        GetInput();
    }

    private void UpdateCameraPosition(float speed)
    {
        Vector3 newCameraPosition;
        
        newCameraPosition = m_Camera.transform.localPosition;
            
        m_Camera.transform.localPosition = newCameraPosition;
    }

    private void RotateView()
    {
        m_MouseLook.LookRotation(transform, m_Camera.transform);
    }

    private void GetInput()
    {
        
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
