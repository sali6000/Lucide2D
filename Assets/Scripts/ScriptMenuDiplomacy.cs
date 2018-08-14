using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMenuDiplomacy : MonoBehaviour {

	public bool closeMenuTableau = false;
	public bool onTriggerTableau = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		onTriggerTableau = true;
	}

	void OnTriggerExit2D()
	{
		onTriggerTableau = false;
	}

	public void QuitMenu()
	{
		closeMenuTableau = true;
	}

}
