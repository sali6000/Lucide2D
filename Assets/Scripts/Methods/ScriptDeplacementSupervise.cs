using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDeplacementSupervise : ScriptDeplacement {

    // PARAMETRES
    [Header("Can run")]
    public float runSpeed;
    
    [Header("Can move")]
	public string inputFront;
    public string inputBack;
    public string inputLeft;
    public string inputRight;

    [Header("Change walk/run")]
    public string inputWalkSpeed;

    // CONDITIONS
	public float WalkSpeedSelect {get; set;}
	public bool CanMove {get; set;}

    public void Deplacer(ScriptShowDialogue panelConversation, ScriptPnjProperties pnjProperties)
    {
        // CONDITIONS (APPLICATION)
		if(CanMove && !panelConversation.isOpen)
        {
            WalkSpeedSelect = (Input.GetKey(inputWalkSpeed))? runSpeed:base.walkSpeed;

            if(Input.GetKey(inputFront) || Input.GetKey(inputLeft) || Input.GetKey(inputBack) || Input.GetKey(inputRight))
            {
                base.Avancer(gameObject, WalkSpeedSelect);
                if(WalkSpeedSelect.Equals(runSpeed) && !(pnjProperties.endurance < 0))
                {
                    pnjProperties.DecrementerEndurance(1);
                    
                }
                else
                {
                    pnjProperties.IncrementerEndurance(0.5f);
                }
            }
            else
            {
                pnjProperties.IncrementerEndurance(1);
            }
            
            // Avancer vers l'avant
            if (Input.GetKey(inputFront))
            {
                base.Rotationner(gameObject,360);
            }

            // Avancer à droite (+ vers l'avant)
            if (Input.GetKey(inputRight))
            {
                if (Input.GetKey(inputFront))
                {
                    base.Rotationner(gameObject,-45);
                }
                else base.Rotationner(gameObject,-90);
            }

            // Avancer à gauche
            if (Input.GetKey(inputLeft))
            {
                if (Input.GetKey(inputFront))
                {
                    base.Rotationner(gameObject,45);
                }
                else
                    base.Rotationner(gameObject,90);
            }

            // Avancer en bas (+ vers la gauche ou la droite)
            if (Input.GetKey(inputBack))
            {
                if (Input.GetKey(inputRight))
                {
                    base.Rotationner(gameObject,-135);
                }
                else if (Input.GetKey(inputLeft))
                {
                    base.Rotationner(gameObject,135);
                }
                else base.Rotationner(gameObject,180);
            }
        }	
    }
}
