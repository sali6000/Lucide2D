using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPnjProperties : MonoBehaviour {

	public bool CanWalk {get;set;}

	[Header("Have a name")]
	public string name;

	[Header("Can die")]
    public int vie;

	[Header("Can be breathless")]
    public float endurance;

    public void DecrementerEndurance(float value)
    {
        if(this.endurance > 0)
        this.endurance -= (value * Time.deltaTime);
    }

    public void IncrementerEndurance(float value)
    {
        if(this.endurance < 100)
        this.endurance += (value * Time.deltaTime);
    }
}
