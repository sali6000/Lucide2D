using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptShowHumanStatut : MonoBehaviour {
	public Text sante;
	public Text endurance;
	public Text country;
	private ScriptPnjProperties human;

	// Use this for initialization
	void Start () {
		human = GameObject.Find("Human").GetComponent<ScriptPnjProperties>();
		sante.text = "Santé: "+human.vie;
		endurance.text = "Endurance: "+ human.endurance.ToString("F0");
	}
	
	// Update is called once per frame
	void Update () {
		sante.text = sante.text = "Santé: "+human.vie;
		endurance.text = "Endurance: "+human.endurance.ToString("F0");
		country.text = "Pays: "+ScriptGameProperties.Country;
	}
}
