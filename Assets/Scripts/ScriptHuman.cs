using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptHuman : MonoBehaviour {

    // Variables utilitaires
    private float walkSpeedSelect;

    // Configuration divers
    public float walkSpeed;
    public float runSpeed;
    public bool canMove = true;

    // Paramètrage des touches sur base desquels les actions seront effectuées
    public string inputFront;
    public string inputBack;
    public string inputLeft;
    public string inputRight;
    public string inputWalkSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(canMove == true)
        {
        walkSpeedSelect = (Input.GetKey(inputWalkSpeed))? runSpeed:walkSpeed;

        if(Input.GetKey(inputFront) || Input.GetKey(inputLeft) || Input.GetKey(inputBack) || Input.GetKey(inputRight))
        {
            Walk();
        }
        // Avancer vers l'avant
        if (Input.GetKey(inputFront))
        {
            SetRotation(360);
        }

        // Avancer à droite (+ vers l'avant)
        if (Input.GetKey(inputRight))
        {
            if (Input.GetKey(inputFront))
            {
                SetRotation(-45);
            }
            else SetRotation(-90);
        }

        // Avancer à gauche
        if (Input.GetKey(inputLeft))
        {
            if (Input.GetKey(inputFront))
            {
                SetRotation(45);
            }
            else
                SetRotation(90);
        }

        // Avancer en bas (+ vers la gauche ou la droite)
        if (Input.GetKey(inputBack))
        {
            if (Input.GetKey(inputRight))
            {
                SetRotation(-135);
            }
            else if (Input.GetKey(inputLeft))
            {
                SetRotation(135);
            }
            else SetRotation(180);
        }
        }
    }

    private void SetRotation(float direction)
    {
        Vector3 rot = transform.rotation.eulerAngles;
        rot.z = direction;
        transform.rotation = Quaternion.Euler(rot); // Rotationer l'objet dans l'angle voulus
    }

    private void Walk()
    {
        transform.Translate(0, walkSpeedSelect * Time.deltaTime, 0); // Avancer
    }
}
