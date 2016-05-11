using UnityEngine;
using System.Collections;

public class Projectiles : MonoBehaviour {

    GameObject @base;
    GameObject enemy;
    GameObject projectile;
    Base Health;
    int dmg = 25;

	// Use this for initialization
	void Start () {
        @base = GameObject.FindGameObjectWithTag("Base");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        projectile = GameObject.FindGameObjectWithTag("Projectile");
        Health = gameObject.GetComponent<Base>();
	}
	
    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject == @base)
            Health.HP -= dmg;
        if (collision.gameObject == enemy)
            Destroy(enemy, 0f);
        if (collision.gameObject == projectile)
            Destroy(projectile, 0f);
    }
	// Update is called once per frame
	void Update () {
	
	}

}
