using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {
    //Sets the camera to a for reference 
    public GameObject camera;
    //Set the camera speed 
    public int speed = 1;
    //Time set for when the scene should transition to the next scene
    public float waitTime = 20;
    //Public refrence to what 
    public string level;

	// Update is called once per frame
    //On Update the the cam will travel throught the scene until Code routin accures
	void Update () {
        camera.transform.Translate(Vector3.down * Time.deltaTime * speed);
        StartCoroutine(waitFor());
        if (Input.GetAxisRaw("B") != 0)
            Application.LoadLevel(level); 

    }
    //Sets the pera,eter for the code routin
    IEnumerator waitFor() {
        yield return new WaitForSeconds(waitTime);
        Application.LoadLevel(level);
    }
    // Creats a a button so the user has the option to return to the previose menu on click 
    void OnGUI() {
        if (GUI.Button(new Rect(15, 15, 100, 50), "(B)ack"))
            Application.LoadLevel(level);
            }  
}
 