using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRInteractiveItem : MonoBehaviour {
    public float stareDuration = 3.0f;
    public float currentStareLength = 0.0f;
    public GameObject objectWithMenu;
    private Button button;
    public bool stared = false;
    public SelectionMeter meter;

    public virtual void Update()
    {
        if (stared)
        {
            currentStareLength += Time.deltaTime;
            if(currentStareLength >= stareDuration || Input.GetButtonUp("Tap"))
            {
                this.gameObject.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
                
            }
        }
    }

    public void Staring()
    {
        stared = true;
        meter.Show();
    }
    //stopped looking
    public void Out()
    {
        currentStareLength = 0.0f;
        stared = false;
        meter.Hide();
    }
}
