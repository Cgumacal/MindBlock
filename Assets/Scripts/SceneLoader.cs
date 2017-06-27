using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Basic Loading Screen Logic
/// </summary>
public class SceneLoader : MonoBehaviour {
    [SerializeField]
    private Text text;
	[SerializeField]
	private string levelToLoad;

    private void Start()
    {
        StartCoroutine("LoadSceneAsync", levelToLoad);        
    }
	/// <summary>
	/// Loads the given scene asynchronously.
	/// </summary>
	/// <param name="levelToLoad">Level to load.</param>
	IEnumerator LoadSceneAsync(string levelToLoad)
	{

		AsyncOperation async = SceneManager.LoadSceneAsync (levelToLoad);
		async.allowSceneActivation = false;

		// Do stuff while waiting for scene to load
		while (!async.isDone) {
			float progress = Mathf.Clamp01 (async.progress / 0.9f);
            text.text = "Loading... " + progress * 100 + "%";
			Debug.Log("Loading Progess: " + (progress * 100) + "%");

			//Loading Complete
			if(async.progress == 0.9f)
			{
                text.text = "Press a key to continue";
				Debug.Log("Press a key to start");
				if (Input.anyKey)
				{
					async.allowSceneActivation = true;	
				}
			}

			yield return null;
		}
	}
		
}
