using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Level manager utility class.
/// </summary>
public class LevelManager {

	/// <summary>
	/// Resets the current level. 
	/// </summary>
	/// <remarks>
	/// NOTE: When testing in the Unity Editor, resetting the level may cause scene to
	/// look significantly darker. But, when the game is built the lighting looks fine.
	/// 
	/// If you want to get rid of this, you can bake the lighting for the scene. On the menu bar: 
	/// 	1) Go to Window -> Lighting -> Lighting Setting
	/// 	2) Uncheck the "Auto Generate" check box on the bottom of the window
	/// 	3) Click "Generate Lighting" to bake the lighting manually
	/// 
	/// If you make changes to the lighting, bake it again.
	/// 
	/// </remarks>
	public static void ResetLevel()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
