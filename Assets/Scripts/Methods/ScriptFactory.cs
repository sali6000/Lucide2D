using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptFactory : MonoBehaviour
{
	// --------------------------------------------------------
	// GAMEOBJECTS
	// -----------
	// GAMEOBJECTS WITH TAG "Bot"
	public static GameObject[] GetGameObjectsBot()
	{
		return GameObject.FindGameObjectsWithTag("Bot");
	}

	// GAMEOBJECT WITH TAG "Human"
	public static GameObject GetGameObjectHuman()
	{
		return GameObject.FindGameObjectWithTag("Player");
	}

	// --------------------------------------------------------
	// SCRIPTS GENERIQUES
	// ------------------
	// GAMEOBJECT => SCRIPT
	public static T GetScriptAttachedOnGO<T>(GameObject gameObject) where T : MonoBehaviour
	{
		return gameObject.GetComponent<T>();
	}

	// GAMEOBJECT => GAMEOBJECT (CHILD) => SCRIPT
	public static T GetScriptAttachedInChildOfGO<T>(GameObject gameObject) where T : MonoBehaviour
    {
		return gameObject.GetComponentInChildren<T>();
	}

	// --------------------------------------------------------
	// SCRIPT METHODES
	// ---------------
	// SCRIPT => Parler
	public static ScriptParler GetScriptParler(GameObject gameObject)
	{
		return gameObject.GetComponent<ScriptParler>();
	}

	// SCRIPT => ShowDialogue
	public static ScriptShowDialogue GetScriptShowDialogue()
	{
		return FindObjectOfType<ScriptShowDialogue>();
	}

	// SCRIPT (IN CHILD) => Trigger
	public static ScriptTrigger GetScriptTriggerInChildOf(GameObject gameObject)
	{
		return gameObject.GetComponentInChildren<ScriptTrigger>();
	}
}
