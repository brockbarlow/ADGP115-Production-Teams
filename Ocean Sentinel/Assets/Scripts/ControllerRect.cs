////////////////////////////////////////////////////////////////
//Austin Morrell//
//May 31 2016//
//ADGP-115 Production Teams//
///////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControllerRect : MonoBehaviour {

    // All the buttons traversable in the scene.
    [SerializeField]
    private GameObject[] Buttons;
    // Just a number used for counting. :]
    [SerializeField]
    private int Counter;
    // Stops if the player is holding down the input.
    private bool Hold;

    // This is used for initialization.
    void Start ()
    {
        Counter = 0;
	}

	void Update ()
    {
        // Incraments the Counter when the player presses up or down.
	    if (Input.GetAxis("RightJoystickY") != 0 && Hold)
        {
            //-----------------------------------------------
            if (Input.GetAxis("RightJoystickY") > 0)
            {
                Counter--;
            }
            else
            {
                Counter++;
            }
            if (Counter > Buttons.Length) { Counter = 0; }
            if (Counter < 0) { Counter = 0; }
            // -----------------------------------------------

            // Shows the currently selected button.
            Buttons[Counter].GetComponent<Button>().Select();
            // Sets hold to false, implying the player is holding the stick down.
            Hold = false;
        }

        // Returns the hold to true when the player stops holding the joystick down.
        if (Input.GetAxis("RightJoystickY") == 0)
        {
            Hold = true;
        }

        // Presses the currently selected button.
        if (Input.GetButtonDown("A"))
        {
			//Buttons[Counter].GetComponent<Button>().onClick.Invoke();
			Buttons[Counter].GetComponent<Button>().Select();
        }
	}
}
