using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuPC : MonoBehaviour {
    public GameObject pauseMenu;
    public FPScontroller firstPersonCont;
    private bool isPaused;
	// Use this for initialization
	void Start () {
        pauseMenu.SetActive(false);
        isPaused = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
        if (isPaused)
        {
            Cursor.visible = true;
            firstPersonCont.enabled = false;
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            Cursor.visible = false;
            firstPersonCont.enabled = true;
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }

    }
    public void loadLevel(string str)
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        SceneManager.LoadScene(str);
    }
}
