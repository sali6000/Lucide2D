﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMenuCentral : MonoBehaviour {
	public bool closeMenuCentral = false;
	public bool onTriggerCentral = false;

	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {
	}

	// Lorsque l'un collider2D (humain) se trouve sur un trigger (central), il est autorisé à voir le GUI (menu)
	void OnTriggerEnter2D(Collider2D col)
	{
		onTriggerCentral = true;
	}
	
	// Lorsque le collider2D quitte l'emplacement où se trouve le trigger (central), il n'est plus autorisé
	// à voir le GUI (menu)
	void OnTriggerExit2D()
	{
		onTriggerCentral = false;
	}

	public void QuitMenu()
	{
		closeMenuCentral = true;
	}
}
