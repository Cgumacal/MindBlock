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
        //Debug.DrawRay(m_Camera.transform.position, m_Camera.transform.forward, Color.red, 1000);
		ChangeBlockColor ();
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

	private void ChangeBlockColor()
	{
		RaycastHit hit;
		Physics.Raycast(m_Camera.transform.position, m_Camera.transform.forward, out hit);


		if (hit.collider != null)//if the raycast hits something
		{
			if (hit.transform.gameObject.GetComponent<TeleportTo>())//if it is not the same block as you are currently standing on check for a teleport script
			{
				Vector3 teleportTo = hit.transform.gameObject.GetComponent<TeleportTo>().Teleport();//get the transform for the block you are trying to teleport to 
				bool TP_Block = hit.transform.gameObject.GetComponent<TeleportBlock>();
				if (teleportTo.y <= transform.position.y + 1 && Vector3.Distance (teleportTo, transform.position) <= maxTeleport && transform.parent.GetComponent<TeleportTo> ().getBorderNum () == hit.transform.gameObject.GetComponent<TeleportTo> ().getBorderNum () || TP_Block) {
					hit.transform.gameObject.GetComponent<BlockColorChange> ().setStateToTeleportable();
				} 
				else 
				{
					hit.transform.gameObject.GetComponent<BlockColorChange> ().setStateToNonteleportable();
				}
			}
		}

	}

    private void GetInput()
    {
        if (!Ui.active)//check if game is paused
        {
            if (Input.GetButtonDown("Tap")) //making sure we swivel only once per swipe
            {
                oneSwipe = true;
            }
            if (Input.GetButton("Tap"))
            {
                horizontalSwipe = Input.GetAxisRaw("Mouse X"); //swipe intensity
                                                               //Debug.Log(horizontalSwipe);
                if (horizontalSwipe >= swipeSensitivity && oneSwipe)
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

                if (hit.collider != null)//if the raycast hits something
                {
                    if (hit.transform == transform.parent && !hit.transform.gameObject.GetComponent<TeleportBlock>())//check if the block that you are looking at is the one you are standing on
                    {
                        hit.transform.gameObject.SendMessage("Activate");//if it is then send a message to that game object to use the gameObjects Activate() Function this will be to activate triggers
                    }
                    else if (hit.transform.gameObject.GetComponent<TeleportTo>())//if it is not the same block as you are currently standing on check for a teleport script
                    {
                        Vector3 teleportTo = hit.transform.gameObject.GetComponent<TeleportTo>().Teleport();//get the transform for the block you are trying to teleport to 
                        bool TP_Block = hit.transform.gameObject.GetComponent<TeleportBlock>();
                        if (teleportTo.y <= transform.position.y + 1 && Vector3.Distance(teleportTo, transform.position) <= maxTeleport && transform.parent.GetComponent<TeleportTo>().getBorderNum() == hit.transform.gameObject.GetComponent<TeleportTo>().getBorderNum() || TP_Block)
                        {// if it is below the teleport height, and is within the max distance of the teleport and as teleportable through borders
                            tpEffect.StartFade();//activate teleport fade
                            transform.position = teleportTo;//change position of player
                            transform.parent = hit.transform;//change the parent of the player to the current block 
                        }
                        //send thing activating teleport trail
                    }
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!Ui.active) { 
                Ui.SetActive(true);
                Ui.transform.position = m_Camera.transform.position + m_Camera.transform.forward * 1.5f;
                Ui.transform.rotation = m_Camera.transform.rotation;
            }
            else
            {
                Ui.SetActive(false);
                
            }
        }
    }

    public void setMaxTeleport(float distance)
    {
        maxTeleport = distance;
    }

	public float getMaxTeleport()
	{
		return maxTeleport;
	}

    public void resetTeleportDistance()
    {
        maxTeleport = defaultMaxTeleport;
    }
}
