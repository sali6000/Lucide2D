using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDeplacementAutomatique : ScriptDeplacement {

	// Conditions permettant le déplacement automatique
	public void Deplacer(int frames, ScriptTrigger trigger)
	{
		// Donner un nouveau random
		int random = Random.Range(60,500);
		
		// S'arrêter
		if(((frames%random) - 100) == 0)
		base.canWalk = false;
 
		// Rotationner puis marcher
		if(frames%random == 0 || trigger.TouchAWall)
		{
			base.Rotationner(gameObject, Random.Range(-180,180));
            trigger.TouchAWall = false;
			base.canWalk = true;
		}

		if(base.canWalk)
		{
			base.Avancer(gameObject, base.walkSpeed);
		}
	}
}
