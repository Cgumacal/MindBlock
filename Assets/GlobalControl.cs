using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class is used to keep track of information between scenes or even the same scene if the scene is reloaded.
/// </summary>
public class GlobalControl : MonoBehaviour {

	private static GlobalControl Instance;	// Singleton instance of this object

	public string checkpointBlockName;
	[SerializeField]
	private string _prevSceneName;			// Previous scene loaded
	[SerializeField]
	private string _newSceneName;			// Current scene loaded

	void Awake ()   
	{
		// Makes sure there is only one instance of this class
		if (Instance == null)
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy (gameObject);
		}
		// Debug.Log ("Should only happen once");

		checkpointBlockName = FindObjectOfType<StartBlock> ().name;
		_prevSceneName = "";
		_newSceneName = "";
	}

	public void setPrevSceneName(string newName) 
	{
		_prevSceneName = newName;
	}

	public void setNewSceneName(string newName)
	{
		_newSceneName = newName;
	}

	/// <summary>
	/// Updates the scene names saved in global object.
	/// </summary>
	public void updateSceneNames()
	{
		_prevSceneName = _newSceneName;
		_newSceneName = SceneManager.GetActiveScene ().name;
	}


	public bool sceneHasChanged ()
	{
		return !string.Equals(_prevSceneName,_newSceneName);
	}


}
