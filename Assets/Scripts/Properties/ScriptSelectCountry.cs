using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptSelectCountry : MonoBehaviour {
	public Dropdown selectCountry;
	
	void Start ()
	{
		selectCountry = GetComponent<Dropdown>();
		selectCountry.onValueChanged.AddListener(delegate {ChangeCountry(selectCountry);});
		ScriptGameProperties.Country = selectCountry.options[selectCountry.value].text;
	}
	public void ChangeCountry(Dropdown selectCountry)
	{
		ScriptGameProperties.Country = selectCountry.options[selectCountry.value].text;
	}
}
