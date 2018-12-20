using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScriptManagementGUI : MonoBehaviour {
	
	// PROPERTIES
	private bool ShowMenu { get; set;}
	private Transform TRAllColliders { get; set; }
	public GameObject GOHumanObject { get; set; }
	private GameObject GOPanelMenuCentral { get; set; }
	private GameObject GOPanelMenuDiplomacy { get; set; }
	private GameObject GOPanelMenuEconomy { get; set; }
	private GameObject GOPanelInformatif { get; set; }
	private ScriptTrigger scriptTrigger { get; set; }
	private ScriptPnjProperties scriptPnjProperties { get; set; }

	void Start () 
	{
		// INITIALIZATIONS
		Debug.Log("Initialisation des relations...");
		GOHumanObject = GameObject.Find("Human");
		GOPanelMenuCentral = GameObject.Find("PanelMenuCentral");
		GOPanelMenuDiplomacy = GameObject.Find("PanelMenuDiplomacy"); // MenuDiplomacy
		GOPanelMenuEconomy = GameObject.Find("PanelMenuEconomy");
		GOPanelInformatif = GameObject.Find("PanelInformatif");
		TRAllColliders = GameObject.Find("Colliders").transform;
		scriptPnjProperties = GOHumanObject.GetComponent<ScriptPnjProperties>();
		ScriptStaticMethods.ClearLog();
	}
	
	void Update () 
	{
		// CONDITIONS
		if(Input.GetKeyDown(KeyCode.Space))
		{
				if(ShowMenu)
				{
					scriptPnjProperties.CanWalk = true;
					ShowMenu = false;
					Debug.Log("L'utilisateur appuie sur la barre d'ESPACE, un menu se ferme");
				}
				else
				{
					scriptPnjProperties.CanWalk = false;
					ShowMenu = true;
					Debug.Log("L'utilisateur appuie sur la barre d'ESPACE, un menu s'ouvre");
				}
		}
	}

	// METHODES
	void OnGUI()
	{
		// Si le GUI peut apparaître
		if(ShowMenu)
		{
			// suivant le trigger sur lequel il est, affiché le menu suivant:
			if(TRAllColliders.transform.Find("ColTableau").GetComponentInChildren<ScriptTrigger>().IsOnTrigger)
				GOPanelMenuDiplomacy.SetActive(true);
			if(TRAllColliders.transform.Find("ColCentral").GetComponentInChildren<ScriptTrigger>().IsOnTrigger)
				GOPanelMenuCentral.SetActive(true);
			//if(scriptCentral.OnTrigger())panelMenuCentral.SetActive(true);
		}
		// Sinon, ne rien afficher
		else
		{
				GOPanelMenuCentral.SetActive(false);
				GOPanelMenuDiplomacy.SetActive(false);
				GOPanelMenuEconomy.SetActive(false);
				GOPanelInformatif.SetActive(false);		
		}
	}
}
