using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IHuman : IPnj
{
    // PROPERTIES
    int Vie { get; set; }
    float Endurance { get; set; }
    float RunSpeed { get; set; }
    string InputFront { get; set; }
    string InputBack { get; set; }
    string InputLeft { get; set; }
    string InputRight { get; set; }
    string InputWalkSpeed { get; set; }
    float WalkSpeedSelect { get; set; }

    // METHODES
    void DecrementerEndurance(float value);
    void IncrementerEndurance(float value);
}
