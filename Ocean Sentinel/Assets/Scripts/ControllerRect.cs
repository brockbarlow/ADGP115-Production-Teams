using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControllerRect : MonoBehaviour {

    [SerializeField]
    private GameObject[] Buttons;
    [SerializeField]
    private int Counter;
    private bool Hold;

	void Start ()
    {
        Counter = 0;
	}

	void Update ()
    {
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

            Buttons[Counter].GetComponent<Button>().Select();
            Hold = false;
        }

        if (Input.GetAxis("RightJoystickY") == 0)
        {
            Hold = true;
        }

        if (Input.GetButtonDown("A"))
        {
            Buttons[Counter].GetComponent<Button>().onClick.Invoke();
        }
	}
}
