using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionMeter : MonoBehaviour {
    public GameObject meter;
    public float stareDuration = 3.0f;
    public float UIButtonSize = 3.6f;
    private bool showmeter = false;
    private float progress = 0;
    // Use this for initialization
    void Start() {
        Hide();
    }

    // Update is called once per frame
    void Update() {
        if (showmeter)
        {
            meter.transform.localScale = new Vector3(Mathf.Clamp(progress += UIButtonSize / stareDuration * Time.deltaTime, 0f, UIButtonSize), meter.transform.localScale.y, meter.transform.localScale.z);
        }
    }

    public void Show()
    {
        meter.SetActive(true);
        showmeter = true;
    }

    public void Hide()
    {
        meter.transform.localScale = new Vector3(0, meter.transform.localScale.y, transform.localScale.z);
        progress = 0;
        showmeter = false;
        meter.SetActive(false);
    }
}
