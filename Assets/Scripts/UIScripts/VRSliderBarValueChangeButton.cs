using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRSliderBarValueChangeButton : VRInteractiveItem {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public override void Update () {
        if (stared)
        {
            currentStareLength += Time.deltaTime;
            if (currentStareLength >= stareDuration || Input.GetButtonUp("Tap"))
            {
                this.gameObject.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
                currentStareLength = 0;
                base.Out();
                base.Staring();

            }
        }
    }
}
