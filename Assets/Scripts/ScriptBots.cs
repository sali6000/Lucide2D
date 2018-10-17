using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBots : MonoBehaviour {

	private int walkSpeed = 3;
	public string nameBot;
	private int frames = 0;
	private int random = 10;
	private bool canWalk = true;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		frames++;
		BotOnMouvement(frames);
	}

	private void SetRotation(float direction)
    {
        Vector3 rot = transform.rotation.eulerAngles;
        rot.z = direction;
		transform.rotation = Quaternion.Euler(rot); // Rotationer l'objet dans l'angle voulus
    }

	private void Walk()
    {
        transform.Translate(0, walkSpeed * Time.deltaTime, 0); // Avancer
    }

	private void BotOnMouvement(int frames)
	{
		if((frames%random)-100 == 0)
		{
			canWalk = false;
		}
		if(frames%random == 0)
		{
			SetRotation(Random.Range(-180,180));
			random = Random.Range(60,500);
			canWalk = true;
		}
		else if (canWalk)
		{
			Walk();
		}	
	}
}
