using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBlock : MonoBehaviour {
    private GameObject m_Player;
	private GlobalControl _globalControl;

	// Use this for initialization
	void Start () {
        m_Player = GameObject.FindGameObjectWithTag("Player");


		_globalControl = GameObject.FindObjectOfType<GlobalControl> ();
		// Whenever a new scene loads, we update the previous and new scene names in the global object
		_globalControl.updateSceneNames ();		

		if (_globalControl.sceneHasChanged()) {
			//Debug.Log ("Scene Changed");
			// If the scene has changed, the player should spawn on the start block
			_globalControl.checkpointBlockName = name;

			m_Player.transform.position = transform.position;
			m_Player.transform.parent = transform;

		} else {
			//Debug.Log ("Scene NOT Changed");
			// Otherwise spawn on the latest checkpoint which may still be the start block
			GameObject checkpointBlock = GameObject.Find (_globalControl.checkpointBlockName);
			m_Player.transform.position = checkpointBlock.transform.position;
			m_Player.transform.parent = checkpointBlock.transform;
		}

    }
}
