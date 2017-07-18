using UnityEngine;

public class EndBlock : MonoBehaviour {
    public bool positive = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col) {
        if (col.transform.tag == "Player") {
            Debug.Log("Win");
            if (positive) {
                AkSoundEngine.PostEvent("Play_Test_Duck", gameObject);
            }
            else {
                AkSoundEngine.PostEvent("Play_Test_Duck", gameObject);
            }
        }
    }
}
