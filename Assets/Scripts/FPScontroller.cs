using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class FPScontroller : MonoBehaviour {
	//ericL - I made this public in order to access MouseLook through the pause menu script, needed to unlock the cursor when in the pause menu
	//        if this breaks code in any way, feel free to remove it and let me know. Currently, ericL_PauseMenu.cs needs this to unlock the mouse
    [SerializeField]public MouseLook m_MouseLook;
    public GameObject Ui;
    public ScreenFadeOnTeleport tpEffect;
    private Camera m_Camera;
    private CharacterController m_CharacterController;
    private Vector3 m_OriginalCameraPosition;
    private AudioSource m_AudioSource;
    private float horizontalSwipe;
    public float swipeSensitivity = 3.0f;
    public bool oneSwipe = false;
    private Vector3 currentAngle;
    private float maxTeleport;
    public float defaultMaxTeleport = 3f;

    // Use this for initialization
    private void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
        m_Camera = Camera.main;
        m_OriginalCameraPosition = m_Camera.transform.localPosition;
        m_MouseLook.Init(transform, m_Camera.transform);
        maxTeleport = defaultMaxTeleport;
    }

    private void ReInitMouseLook()
    {
        m_MouseLook.Init(transform, m_Camera.transform);
    }

    // Update is called once per frame
    void Update () {
        #if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
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

    private IEnumerator rotate(float direction)
    {
        //this shit isn't smooth, fix it
        transform.Rotate(0, 90 * direction, 0);
        yield return 0f;
    }

    private void GetInput()
    {
        if (Input.GetButtonDown("Tap")) //making sure we swivel only once per swipe
        {
            oneSwipe = true;
        }
        if (Input.GetButton("Tap"))
        {
            horizontalSwipe = Input.GetAxisRaw("Mouse X"); //swipe intensity
            //Debug.Log(horizontalSwipe);
            if(horizontalSwipe >= swipeSensitivity && oneSwipe)
            {
                oneSwipe = false;
                currentAngle = transform.eulerAngles;
                StartCoroutine(rotate(1));
                UpdateCameraPosition(0);
                ReInitMouseLook();
            }
            if (horizontalSwipe <= -swipeSensitivity && oneSwipe)
            {
                oneSwipe = false;
                currentAngle = transform.eulerAngles;
                StartCoroutine(rotate(-1));
                UpdateCameraPosition(0);
                ReInitMouseLook();
            }
            Debug.Log(oneSwipe);
        }
        if (Input.GetButtonUp("Tap"))
        {
            RaycastHit hit;
            Physics.Raycast(m_Camera.transform.position, m_Camera.transform.forward, out hit);
            Debug.DrawRay(m_Camera.transform.position, m_Camera.transform.forward, Color.red, 1000);

            if (hit.transform.gameObject.GetComponent<TeleportTo>())
            {
                Vector3 teleportTo = hit.transform.gameObject.GetComponent<TeleportTo>().Teleport();
                if(teleportTo.y <= transform.position.y+1 && Vector3.Distance(teleportTo, transform.position) <= maxTeleport)
                {
                    tpEffect.StartFade();
                    transform.position = teleportTo;
                    transform.parent = hit.transform;
                }
                //send thing activating teleport trail
            }
        }
    }

    public void setMaxTeleport(float distance)
    {
        maxTeleport = distance;
    }

    public void resetTeleportDistance()
    {
        maxTeleport = defaultMaxTeleport;
    }
}
