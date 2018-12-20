using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IDeplacement
{
    // PROPERTIES
    bool CanWalk { get; set; }
    int WalkSpeed { get; set; }

    // METHODES
    void Avancer(GameObject gameObject, float vitesse);
    void Rotationner(GameObject gameObject, int direction);
}
