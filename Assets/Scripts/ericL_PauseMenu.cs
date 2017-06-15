using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//to access buttons
using UnityEngine.UI;

public class ericL_PauseMenu : MonoBehaviour {

	public Transform pauseCanvas;

	//When other panels are created, add here
	public Transform paused;
	public Transform controls;
	public Transform sounds;
	public Transform settings;
	public Transform mainMenu;

	private Transform toClose;

	public Transform player;

	//check if escape is pressed to pull up pause menu
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Pause();	
		}
	}

	//sets time of game world to 0 or 1 respectively for pause / unpause
	//unlocks mouse to select from menu when paused, locks again when going back to first person
	//pulls up menu when paused, (setActive) closed when unpaused
	public void Pause()
	{
		if (pauseCanvas.gameObject.activeInHierarchy == false) 
		{
			pauseCanvas.gameObject.SetActive (true);
			player.GetComponent<FPScontroller> ().m_MouseLook.SetCursorLock(false);
			player.GetComponent<FPScontroller> ().enabled = false;
			Time.timeScale = 0;
		} 
		else
		{
			pauseCanvas.gameObject.SetActive (false);
			player.GetComponent<FPScontroller> ().m_MouseLook.SetCursorLock(true);
			player.GetComponent<FPScontroller> ().enabled = true;
			Time.timeScale = 1;
		}
	}

	public void GoToControls()
	{
		Debug.Log ("controls");
		paused.gameObject.SetActive (false);
		controls.gameObject.SetActive (true);

		toClose = controls;
	}

	public void GoToSounds()
	{
		Debug.Log ("Sounds");
		paused.gameObject.SetActive (false);
		sounds.gameObject.SetActive (true);

		toClose = sounds;
	}

	public void GoToSettings()
	{
		Debug.Log ("Settings");
		paused.gameObject.SetActive (false);
		settings.gameObject.SetActive (true);

		toClose = settings;
	}

	public void GoToMainMenu()
	{
		Debug.Log ("Main Menu");

		//change to main menu scene here
	}
		
	public void ResumeGame()
	{
		Pause ();
	}

	public void ReturnToPaused()
	{
		toClose.gameObject.SetActive (false);
		paused.gameObject.SetActive (true);
	}
}
