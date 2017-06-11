using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionMeter : MonoBehaviour {
    public GameObject meter;
    private bool showmeter = false;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (showmeter)
        {
            
        }
    }

    public void Show()
    {  
        meter.transform.localScale = new Vector3(Mathf.Clamp(Time.deltaTime / 2, 0f, 1f), meter.transform.localScale.y, meter.transform.localScale.z);
        meter.SetActive(true);
        showmeter = true;
    }

    public void Hide()
    {
        meter.transform.localScale = new Vector3(0, transform.localScale.y, transform.localScale.z);
        meter.SetActive(false);
        showmeter = false;
    }
}
