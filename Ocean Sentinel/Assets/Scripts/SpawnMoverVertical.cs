using UnityEngine;
using System.Collections;

//this script will give the enemy spawn points the ability to move

public class SpawnMoverVertical : MonoBehaviour
{
    private bool down = false; //if the spawn points can move or not
    private bool up = true;

    // Use this for initialization
    void Start()
    {
        
    }

    void Lerp(float a, float b, float c)
    {
        gameObject.transform.position = new Vector3(transform.position.x + a, transform.position.y + b, transform.position.z + c);
    }

    //void OnTriggerEnter(Collider collision)
    //{
    //    //check the collision between the pojectile and the bass
    //    if (collision.gameObject.tag == "Base")
    //    {
    //        Health.HP -= dmg;
    //        Destroy(gameObject);
    //    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "SpawnWall")
        {
            up = true;
            down = false;
        }

        if (collision.gameObject.tag == "SpawnWall2")
        {
            up = false;
            down = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (up == true)
        {
            Lerp(0, 0, 8 * Time.deltaTime /** speed*/);
        }

        if (down == true)
        {
            Lerp(0, 0, -8 * Time.deltaTime /** speed*/);
        }

        //if (gameObject.transform.position.z <= -12)
        //{
        //    up = true;
        //    down = false;
        //}

        //if (gameObject.transform.position.z >= 35)
        //{
        //    up = false;
        //    down = true;
        //}
    }
}