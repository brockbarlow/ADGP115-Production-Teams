using UnityEngine;
using System.Collections;

public class Projectiles : MonoBehaviour {
    //Referes to the Base Health Script (Base) 
    Base Health;

    public float lifeSpan = 3;
    public float speed = 1f;
    public float count;
    int dmg = 25;

	// Use this for initialization
	void Start () {

        Health = gameObject.GetComponent<Base>();
	}
	//Makes the check with each possiable collision in the game
    void OnTriggerEnter(Collider collision)
    {
        //check the collision between the pojectile and the bass 
        if (collision.gameObject.tag == "Base")
        {
            Health.HP -= dmg;
            Destroy(gameObject);
        }
        // checks the collision with the projectile and the Enemy 
        if (collision.gameObject.tag == "Enemy")
            Destroy(collision.gameObject, 0f);
        //Checks the collision with the projectile and itself 
        if (collision.gameObject.tag == "Projectile")
            Destroy(collision.gameObject, 0f);
    }
	// Update is called once per frame
	void Update () {
        //Set the Projectile movement 
        transform.Translate(0f,speed * Time.deltaTime, 0f);
    }

   
}
