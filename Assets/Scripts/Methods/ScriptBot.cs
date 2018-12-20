using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBot : MonoBehaviour, IBot
{
    public string Name { get; set; }
    public bool CanWalk { get; set; }
    public int WalkSpeed { get; set; }

    // METHODES 
    public void DeplacementAutomatique(int frames, ScriptTrigger trigger)
    {
        // Donner un nouveau random
        int random = Random.Range(60, 500);

        // S'arrêter
        if (((frames % random) - 100) == 0)
             CanWalk = false;

        // Rotationner puis marcher
        if (frames % random == 0 || trigger.TouchAWall)
        {
            Rotationner(gameObject, Random.Range(-180, 180));
            trigger.TouchAWall = false;
            CanWalk = true;
        }

        if (CanWalk)
        {
            Avancer(gameObject, WalkSpeed);
        }
    }

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
