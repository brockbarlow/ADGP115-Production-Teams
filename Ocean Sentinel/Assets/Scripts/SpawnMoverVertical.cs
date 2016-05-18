using UnityEngine;
using System.Collections;

//this script will give the enemy spawn points the ability to move

public class SpawnMoverVertical : MonoBehaviour
{

    //public float speed; //how fast the spawn points will move
    private bool down, up = false; //if the spawn points can move or not

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
        if (up == true)
        {
            Lerp(0, 0, 5 * Time.deltaTime /** speed*/);
        }

        if (down == true)
        {
            Lerp(0, 0, -5 * Time.deltaTime /** speed*/);
        }

        if (gameObject.transform.position.z <= -12)
        {
            up = true;
            down = false;
        }

        if (gameObject.transform.position.z >= 35)
        {
            up = false;
            down = true;
        }
    }
}