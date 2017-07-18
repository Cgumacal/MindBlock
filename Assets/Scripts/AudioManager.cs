using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        AudioListener.volume = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ChangeMasterVolume(Slider slider)
    {
        Debug.Log("TEST");
        AudioListener.volume = slider.value;
        Debug.Log(AudioListener.volume);
    }
}
