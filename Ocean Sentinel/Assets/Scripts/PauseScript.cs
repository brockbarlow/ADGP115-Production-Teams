using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//Script created by Andrew Miller 
public class PauseScript : MonoBehaviour {
    //Bool variable that keeps track weather the game has benn paused or not 
    public bool paused;
    //Container for the "Pause" text 
    public Text pauseText;
    //Referes to the canvas that the pase statement will be placed at
    public Canvas canvas; 
	// Use this for initialization
	void Start () {

        //At Start paused will be disabled 
        paused = false;
        //Set the refrence to canvas at the start of the game 
        canvas = canvas.GetComponent<Canvas>();
	}
	
	// Update is called once per frame
	void Update () {
        PausedClicked();
        Paused();
	}
    void PausedClicked() {
        //Sets the Conditions for when the space bar has been preesed down
        if (Input.GetKeyDown(KeyCode.Space)) {
            //Set the bool oppisite to what the curret stat
            paused = !paused;
            //Set the text on the UI
            pauseText.text = "PAUSED";
        }
        
    }
    void Paused() {
        //Check if the paused button has been preesed 
        if (paused) {
            //Enables the canvas to appear on the screen
            canvas.enabled = true;
            //Pauses the in game time 
            Time.timeScale = 0;
        }
        //Check if the paused button 
        if (!paused) {
            //Set the Conves with a clear tex t
            pauseText.text = "";
            //Relinquishes time to normal state
            Time.timeScale = 1;
            //Disables the Convase that pauses the game
            canvas.enabled = false;
        }
    }
}
