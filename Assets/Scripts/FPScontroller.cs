using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class FPScontroller : MonoBehaviour {
	//ericL - I made this public in order to access MouseLook through the pause menu script, needed to unlock the cursor when in the pause menu
	//        if this breaks code in any way, feel free to remove it and let me know. Currently, ericL_PauseMenu.cs needs this to unlock the mouse
    [SerializeField] public MouseLook m_MouseLook;   
    public GameObject Ui;
    public GameObject GameOverScreen;
    public GameObject LevelCompleteScreen;
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
    private bool levelEnd = false;
    RaycastHit hit;
    private float swapDistance = 3f;
	[SerializeField] private Text blockIdentificationText;

    private GameObject storedBlock;
    private float buttonDownTime;
    private bool didSwap = false;
    [SerializeField] private float holdDelay = 1;


    // Use this for initialization
    private void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
        m_Camera = Camera.main;
        m_OriginalCameraPosition = m_Camera.transform.localPosition;
        m_MouseLook.Init(transform, m_Camera.transform);
        maxTeleport = defaultMaxTeleport;
        levelEnd = false;
    }

    private void ReInitMouseLook()
    {
        m_MouseLook.Init(transform, m_Camera.transform);
    }

    // Update is called once per frame
    void Update () {
        //Debug.DrawRay(m_Camera.transform.position, m_Camera.transform.forward, Color.red, 1000);
		
#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
        RotateView();
#endif

        if (!levelEnd)
        {
			DisplaySwappableBlockType ();
            ChangeBlockColor();
            GetInput();
        }
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
				if (Vector3.Distance (teleportTo, transform.position) <= maxTeleport && transform.parent.GetComponent<TeleportTo> ().getBorderNum () == hit.transform.gameObject.GetComponent<TeleportTo> ().getBorderNum () || TP_Block) {
					hit.transform.gameObject.GetComponent<BlockColorChange> ().setStateToTeleportable();
				} 
				else 
				{
					hit.transform.gameObject.GetComponent<BlockColorChange> ().setStateToNonteleportable();
				}
			}
		}

	}

	private void DisplaySwappableBlockType() 
	{
		RaycastHit hit;
		Physics.Raycast(m_Camera.transform.position, m_Camera.transform.forward, out hit);

		blockIdentificationText.text = "";
		if (hit.collider != null) //if the raycast hits something
		{
			GameObject block = hit.transform.gameObject;
			if (block.GetComponent<ericL_Swappable> () != null) // The block is swappable 
			{
				if (block.name.Contains ("AI Rights Block")) {
					blockIdentificationText.text = "AI Rights Block";
				} else if (block.name.Contains ("Death Block")) {
					blockIdentificationText.text = "Death Block";
				} else if (block.name.Contains ("Falling Cube")) {
					blockIdentificationText.text = "Falling Cube";
				} else if (block.name.Contains ("Motivational Cube")) {
					blockIdentificationText.text = "Motivational Cube";
				} else if (block.name.Contains ("Standard Cube")) {
					blockIdentificationText.text = "Standard Cube";
				} else if (block.name.Contains ("PopoutBlock")) {
					blockIdentificationText.text = "Popout Block";
				} else if (block.name.Contains ("GlassBlock")) {
					blockIdentificationText.text = "Glass Block";
				} else {
					blockIdentificationText.text = "This block is not listed";
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
                buttonDownTime = Time.time;
                didSwap = false;
                Physics.Raycast(m_Camera.transform.position, m_Camera.transform.forward, out hit);

            }
            if (Input.GetButton("Tap"))
            {
                //swipes
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

                //hold for trait swap
                if(Time.time - buttonDownTime > holdDelay && !didSwap)
                {
                    RaycastHit holdhit;
                    Physics.Raycast(m_Camera.transform.position, m_Camera.transform.forward, out holdhit);

                    
                    if(hit.collider != null)
                    {
                        if (holdhit.transform == hit.transform && Vector3.Distance(hit.transform.position, transform.position) < swapDistance)
                        {
                            if (!hit.transform.name.Contains("Wall") && !hit.transform.name.Contains("Goal") && !hit.transform.name.Contains("Start") && !hit.transform.name.Contains("Checkpoint"))
                            {
                                if (storedBlock == null) {
                                    Debug.Log(holdhit.transform.name + " saved");
                                    if (hit.transform.name.Contains("Moving"))
                                    {
                                        storedBlock = holdhit.transform.parent.gameObject;
                                        didSwap = true;
                                    }
                                    else
                                    {
                                        storedBlock = holdhit.transform.gameObject;
                                        didSwap = true;
                                    }
                                }
                                else
                                {
                                    swapBlocks(holdhit.transform.gameObject);
                                    didSwap = true;
                                }
                            }
                        }
                    }
                }

            }
            if (Input.GetButtonUp("Tap"))
            {
                if (!didSwap)
                {
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
                            if (Vector3.Distance(teleportTo, transform.position) <= maxTeleport && transform.parent.GetComponent<TeleportTo>().getBorderNum() == hit.transform.gameObject.GetComponent<TeleportTo>().getBorderNum() || TP_Block)
                            {// if it is below the teleport height, and is within the max distance of the teleport and as teleportable through borders
                                tpEffect.StartFade();//activate teleport fade
                                transform.position = teleportTo;//change position of player
                                transform.parent = hit.transform;//change the parent of the player to the current block 
                                AkSoundEngine.PostEvent("Play_Test_Duck", gameObject);
                            }
                            //send thing activating teleport trail
                        }
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
        swapDistance = distance;
    }

	public float getMaxTeleport()
	{
		return maxTeleport;
	}

    public void resetTeleportDistance()
    {
        maxTeleport = defaultMaxTeleport;
        swapDistance = defaultMaxTeleport;
    }

    private void swapBlocks(GameObject secondBlock)
    {
        Vector3 temp;
        int parentSwap = 0;
        if (secondBlock.transform.name.Contains("Moving"))
        {
            secondBlock = secondBlock.transform.parent.gameObject;
        }

        if(transform.parent == storedBlock.transform)
        {
            parentSwap = 1;
            transform.parent = null;
        }else if(transform.parent == secondBlock.transform)
        {
            parentSwap = 2;
            transform.parent = null;
        }


        temp = secondBlock.transform.position;
        secondBlock.transform.position = storedBlock.transform.position;
        storedBlock.transform.position = temp;


        if (parentSwap == 1)
        {
            if (secondBlock.name.Contains("Moving"))
            {
                secondBlock = secondBlock.GetComponentInChildren<TeleportTo>().gameObject;
                Debug.Log(secondBlock.name);
                transform.position = secondBlock.transform.position;
            }
            transform.parent = secondBlock.transform;

        } else if (parentSwap == 2)
        {
            if (storedBlock.name.Contains("Moving"))
            {
                storedBlock = storedBlock.GetComponentInChildren<TeleportTo>().gameObject;
                Debug.Log(storedBlock.name);
                transform.position = storedBlock.transform.position;
            }
            transform.parent = storedBlock.transform;
        }

        Debug.Log("swapped " + secondBlock.name + " with " + storedBlock.name);
        storedBlock = null;
    }

    public void GameOver()
    {
        GameOverScreen.SetActive(true);
        GameOverScreen.transform.position = m_Camera.transform.position + m_Camera.transform.forward * 1.5f;
        GameOverScreen.transform.rotation = m_Camera.transform.rotation;
        levelEnd = true;
    }

    public void LevelComplete()
    {
        LevelCompleteScreen.SetActive(true);
        LevelCompleteScreen.transform.position = m_Camera.transform.position + m_Camera.transform.forward * 1.5f;
        LevelCompleteScreen.transform.rotation = m_Camera.transform.rotation;
        levelEnd = true;
    }

}
