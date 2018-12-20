using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTrigger : MonoBehaviour {
	
	public bool IsOnTrigger {get;set;}
    public bool TouchAWall { get; set; }

	void OnTriggerEnter2D(Collider2D c)
	{
        if (c.gameObject.CompareTag("Player"))
        {
            IsOnTrigger = true;
        }
        else if (c.gameObject.CompareTag("Wall") || c.gameObject.CompareTag("Bot") || c.gameObject.CompareTag("Player")) // A verifier
        {
            TouchAWall = true;
        }
	}

	void OnTriggerExit2D(Collider2D c)
	{
		if(c.gameObject.CompareTag("Player"))
		{
			IsOnTrigger = false;
		}
	}

    public bool ATriggerIsTrue()
	{
		foreach(Transform t in GameObject.Find("Colliders").transform)
		{
			foreach(Component u in t.GetComponentsInChildren(typeof(ScriptTrigger),true))
			{
				if(u.GetComponent<ScriptTrigger>().IsOnTrigger)
				{
					return true;
				}
			}
		}
		return false;
	}
}
