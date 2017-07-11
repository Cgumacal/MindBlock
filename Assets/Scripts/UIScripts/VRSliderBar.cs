using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VRSliderBar : MonoBehaviour {
    public Slider slider;
    public GameObject plus;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void increaseSliderValue(float amount)
    {
        slider.value += amount;
    }
    public void decreaseSliderValue(float amount)
    {
        slider.value -= amount;
    }
}
