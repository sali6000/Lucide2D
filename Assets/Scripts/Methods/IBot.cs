using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IBot : IPnj
{
    // METHODES
    void DeplacementAutomatique(int frames, ScriptTrigger trigger);
}
