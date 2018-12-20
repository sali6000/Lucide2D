using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptParler : MonoBehaviour {

	// PROPRIETES
	[Header("Can talk")]
	public List<string> dialogues;
	public bool IsTalking { get; set; }
    private int IndexDialogue { get; set; }

	void Start()
	{
		IsTalking = false;
        IndexDialogue = 0;
	}

	// METHODES
	public void Parler(ScriptShowDialogue showDialogue)
	{
		// OUVRIR UNE CONVERSATION
		if(!showDialogue.isOpen)
		{
			showDialogue.ShowBox();
			IsTalking = true;
		}
		
		if(showDialogue.isOpen && (dialogues.Count > 0) && (IndexDialogue < dialogues.Count))
		{
			// PARCOURIR UNE CONVERSATION
			showDialogue.SetNamePNJ(GetComponent<ScriptPnjProperties>().name);//nameOfContact);
			showDialogue.SetText(dialogues[IndexDialogue]);
			showDialogue.SetAction(0);
			IndexDialogue++;
		}
		else
		{
			// FERMER UNE CONVERSATION
			showDialogue.HideBox();
			IndexDialogue = 0;
			IsTalking = false;
		}
	}
}