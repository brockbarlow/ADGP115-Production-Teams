using UnityEngine;
//using System.Collections;

//script created by Brock Barlow
//this script will give the enemy spawn points the ability to move

public class SpawnMoverHorizontal : MonoBehaviour
{
    private bool back, forth = false; //if the spawn points can move or not. starts off false.

    // Use this for initialization
    void Start()
    {

    }

    void Lerp(float a, float b, float c) //custom lerp function. gameObject's transfrom position becomes a new vector3 variable.
    {
        gameObject.transform.position = new Vector3(transform.position.x + a, transform.position.y + b, transform.position.z + c);
    }

    // Update is called once per frame
    void Update()
    {
        if (forth == true && Time.deltaTime > 0) //if the forth variable is equal to true, the game objects's x position will become positive over
        {                  //time
            Lerp(0.4f, 0, 0);
        }		// x,  y,  z

        if (back == true && Time.deltaTime > 0) //if the back variable is equal to true, the game object's x position will become negative over time.
        {
            Lerp(-0.4f, 0, 0);
        }		// x,  y,  z

        if (gameObject.transform.localPosition.x <= -60) //if the game object's x position is less than or equal to -29, set the 
        {                                           //forth variable to true and set the back variable to false.
            forth = true;
            back = false;
        }

        if (gameObject.transform.localPosition.x >= 60) //if the game objects's x position is greater than or equal to 29, set the 
        {                                          //forth variable to false and set the back variable to true.
            forth = false;
            back = true;
        }
    }
}