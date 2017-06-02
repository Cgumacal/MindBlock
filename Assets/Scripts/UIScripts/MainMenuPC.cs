using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuPC : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void loadLevel(string str)
    {
        SceneManager.LoadScene(str);
    }
    public void exitGame()
    {
        Application.Quit();
    }
}
