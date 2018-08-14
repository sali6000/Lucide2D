using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScriptManagementGUI : MonoBehaviour {
	
	// Allocation divers de la mémoire pour la gestion des menus
	public bool canShowMenu = false;

	// Allocation de mémoire pour les objets ainsi que les scripts associés
	private GameObject humanObject;
	private GameObject trigCentral;
	private GameObject trigTableau;
	private GameObject panelMenuCentral;
	private GameObject panelMenuDiplomacy;
	private GameObject panelInformatif;
	private GameObject buttonCloseMenuCentral;
	private GameObject buttonCloseMenuDiplomacy;

	private ScriptHuman scriptHuman;
	private ScriptMenuCentral scriptCentral;
	private ScriptMenuDiplomacy scriptTableau; // MenuDiplomacy
	private ScriptMenuCentral scriptCloseMenuCentral;
	private ScriptMenuDiplomacy scriptCloseMenuTableau;

	// Use this for initialization
	void Start () 
	{
		// Chargement des données.
		// Assigner les objets ayant un script d'attacher ainsi que le script à l'emplacement mémoire allouée
		
		// Objet étant le personnage principal
		humanObject = GameObject.Find("Human");

		// Objets ayant un trigger
		trigCentral = GameObject.Find("TrigCentral");
		trigTableau = GameObject.Find("TrigTableau");

		// Objets permettant l'affichage d'un menu
		panelMenuCentral = GameObject.Find("PanelMenuCentral");
		panelMenuDiplomacy = GameObject.Find("PanelMenuDiplomacy"); // MenuDiplomacy
		panelInformatif = GameObject.Find("PanelInformatif");

		// Objet permettant de fermer un menu
		buttonCloseMenuCentral = GameObject.Find("ButtonCloseMenuCentral");
		buttonCloseMenuDiplomacy = GameObject.Find("ButtonCloseMenuDiplomacy");

		// Script associés aux objets
		scriptHuman = humanObject.GetComponent<ScriptHuman>();
		scriptCentral = trigCentral.GetComponent<ScriptMenuCentral>();
		scriptTableau = trigTableau.GetComponent<ScriptMenuDiplomacy>();
		scriptCloseMenuCentral = buttonCloseMenuCentral.GetComponent<ScriptMenuCentral>();
		scriptCloseMenuTableau = buttonCloseMenuDiplomacy.GetComponent<ScriptMenuDiplomacy>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Gestion des actions à effectuer sur les objets

		// Si le joueur appuie sur ENTER
		if(Input.GetKey(KeyCode.KeypadEnter))
		{
			// Si la touche ENTER est pressée et qu'un trigger est actionné
			if(ATriggerIsTrue(scriptCentral.onTriggerCentral,scriptTableau.onTriggerTableau))
			{
				// Le personnage ne peut plus bouger et le GUI apparaît
				scriptHuman.canMove = false;
				canShowMenu = true;
			}
		}
		// Si le joueur clique sur un boutton quittant un menu
		else if(scriptCloseMenuCentral.closeMenuCentral || scriptCloseMenuTableau.closeMenuTableau)
		{
			// Le personnage peut bouger et le GUI disparait
			scriptHuman.canMove = true;
			canShowMenu = false;
		}
	}

	void OnGUI()
	{
		// Si le GUI peut apparaître
		if(canShowMenu)
		{
			// Et que le personnage se trouve sur le trigger d'un tableau
			if(scriptTableau.onTriggerTableau)panelMenuDiplomacy.SetActive(true);
			if(scriptCentral.onTriggerCentral)panelMenuCentral.SetActive(true);
		}
		else
		{
				panelMenuCentral.SetActive(false);
				panelMenuDiplomacy.SetActive(false);
				panelInformatif.SetActive(false);	
				scriptCloseMenuCentral.closeMenuCentral = false;
				scriptCloseMenuTableau.closeMenuTableau = false;	
		}
	}

	// Fonction retournant true si un trigger est actionné
	bool ATriggerIsTrue(params bool[] tr)
	{
		return tr.Any(t=>t);
	}
}
