using UnityEngine;
using System.Collections;

//this script will give the enemy spawn points the ability to move

public class SpawnMoverHorizontal : MonoBehaviour
{

    //public float speed; //how fast the spawn points will move
    private bool back, forth = false; //if the spawn points can move or not

    // Use this for initialization
    void Start()
    {

    }

    void Lerp(float a, float b, float c)
    {
        gameObject.transform.position = new Vector3(transform.position.x + a, transform.position.y + b, transform.position.z + c);
    }

    // Update is called once per frame
    void Update()
    {
        if (forth == true)
        {
            Lerp(0.2f, 0, 0 * Time.deltaTime /** speed*/);
        }

        if (back == true)
        {
            Lerp(-0.2f, 0, 0 * Time.deltaTime /** speed*/);
        }

        if (gameObject.transform.position.x <= -29)
        {
            forth = true;
            back = false;
        }

        if (gameObject.transform.position.x >= 29)
        {
            forth = false;
            back = true;
        }
    }
}