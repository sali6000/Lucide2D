using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDeplacement : MonoBehaviour {

	// PROPRIETES
	[Header("Can walk")]
	public int walkSpeed;
	protected bool canWalk;

	// METHODES
	public void Avancer(GameObject gameObject, float vitesse)
	{
		gameObject.transform.Translate(0, vitesse * Time.deltaTime, 0);	
	}
	
	public void Rotationner(GameObject gameObject, int direction)
	{
			// Selectionner les axes de rotations 
			Vector3 rot = transform.rotation.eulerAngles;

			// Changer la rotation de l'axe Z sur l'axe voulu
        	rot.z = direction;
			
			// Rotationer l'objet dans l'angle voulus
			gameObject.transform.rotation = Quaternion.Euler(rot); 
	}
}
