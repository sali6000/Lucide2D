using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScriptManagementGUI : MonoBehaviour {
	
	// Allocation divers de la mémoire pour la gestion des menus
	public bool canShowMenu = false;

	// Allocation de mémoire pour les objets ainsi que les scripts associés
	
	// Humain
	private GameObject humanObject;

	// Triggers (evennements)
	private GameObject trigCentral;
	private GameObject trigTableau;

	// Panels
	private GameObject panelMenuCentral;
	private GameObject panelMenuDiplomacy;
	private GameObject panelMenuEconomy;
	private GameObject panelInformatif;

	// Scripts
	private ScriptHuman scriptHuman;
	private ScriptMenuCentral scriptCentral;
	private ScriptMenuDiplomacy scriptTableau; // MenuDiplomacy

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
		panelMenuEconomy = GameObject.Find("PanelMenuEconomy");
		panelInformatif = GameObject.Find("PanelInformatif");

		// Objet permettant de fermer un menu


		// Script associés aux objets
		scriptHuman = humanObject.GetComponent<ScriptHuman>();
		scriptCentral = trigCentral.GetComponent<ScriptMenuCentral>();
		scriptTableau = trigTableau.GetComponent<ScriptMenuDiplomacy>();


	}
	
	// Update is called once per frame
	void Update () 
	{
		// Gestion des actions à effectuer sur les objets

		// Si le joueur appuie sur ENTER
		if(Input.GetKey(KeyCode.KeypadEnter))
		{
			// et que le personnage se trouve sur un trigger
			if(ATriggerIsTrue(scriptCentral.onTriggerCentral,scriptTableau.onTriggerTableau))
			{
				// Le personnage ne peut plus bouger et le GUI peut apparaître
				scriptHuman.canMove = false;
				canShowMenu = true;
			}
		}
		// Si aucun menu n'est affiché
		else if(!panelMenuCentral.activeSelf && !panelMenuDiplomacy.activeSelf && !panelMenuEconomy.activeSelf)
		{
			// Le personnage peut bouger et le GUI ne peut plus apparaitre
			scriptHuman.canMove = true;
			canShowMenu = false;
		}
	}

	void OnGUI()
	{
		// Si le GUI peut apparaître
		if(canShowMenu)
		{
			// suivant le trigger sur lequel il est, affiché le menu suivant:
			if(scriptTableau.onTriggerTableau)panelMenuDiplomacy.SetActive(true);
			if(scriptCentral.onTriggerCentral)panelMenuCentral.SetActive(true);
		}
		// Sinon, ne rien afficher
		else
		{
				panelMenuCentral.SetActive(false);
				panelMenuDiplomacy.SetActive(false);
				panelMenuEconomy.SetActive(false);
				panelInformatif.SetActive(false);		
		}
	}

	// Fonction retournant true si un trigger est actionné
	bool ATriggerIsTrue(params bool[] tr)
	{
		return tr.Any(t=>t);
	}
}
