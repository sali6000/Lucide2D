using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScriptShowDialogue : MonoBehaviour {


	public GameObject boiteDeDialogue;
	public Text NameOfContact;
	public Text action;
	private List<string> actionsDisponible;
	public Text text;
	public bool isOpen;


	// Use this for initialization
	void Start () {
		boiteDeDialogue.SetActive(false);
		actionsDisponible = new List<string>();
		actionsDisponible.Add("Appuyez sur ESPACE pour continuer...");
	}

	public void ShowBox()
	{
		boiteDeDialogue.SetActive(true);
		isOpen = true;
	}

	public void HideBox()
	{
		boiteDeDialogue.SetActive(false);
		isOpen = false;
	}

	public void SetText(string s)
	{
		text.text = s;
	}

	public void SetNamePNJ(string s)
	{
		NameOfContact.text = "Vous parlez avec: "+s;
	}

	public void SetAction(int i)
	{
		action.text = actionsDisponible[i];
	}
}
