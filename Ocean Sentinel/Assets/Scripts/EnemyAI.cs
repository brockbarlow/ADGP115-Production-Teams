using UnityEngine;
using System.Collections;
/// <summary>
/// EnemyAI is a class made for the enemies movement 
/// It makes a few checks 
/// if base exists
/// if if the base hp is greater then 0 
/// Enemy well taht travel to said location 
/// </summary>
public class EnemyAI : MonoBehaviour {

    // Players Transformer Will be used to track the players location 
    Transform @base;
    //Instance so i can reffer wether or not it has found the wall.
    GameObject wall;
    NavMeshAgent navMash;
     
	// Use this for initialization
	void Start () {
        @base = GameObject.FindGameObjectWithTag("Base").transform;

        wall = GameObject.FindGameObjectWithTag("Wall");

        navMash = GetComponent<NavMeshAgent>();

	}
	
	// Update is called once per frame
	void Update () {
        Locate();
	}

    // Looks for base unless it exists or the health is greater then 0
    void Locate()
    {
        if(@base != null)
            if(@base.GetComponent<BaseHPScript>().baseCurrentHP  > 0)
                navMash.SetDestination(@base.position); 
        
    }
    // Check for collider that the object comes in contact with 
    void OnTriggerEnter(Collider collision) {
        if (collision.gameObject == wall)
            navMash.enabled = false;
        else
            navMash.enabled = true;
    }
}
