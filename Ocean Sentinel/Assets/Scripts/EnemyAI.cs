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
    public GameObject Prefab;
    //Sets the location of the wanted projectile 
    public GameObject spawnPoint;
    //Time between projectile  
    public float time; 
    //Time till next shot 
    public float  timeCap = 5;
    //Checks when the enemy collides with the wall 
    bool trigger = false;
    //Referres to the games naviagtion mesh 
    NavMeshAgent navMash;
	//Use this for initialization
	void Start () {
        @base = GameObject.FindGameObjectWithTag("Base").transform;

        navMash = GetComponent<NavMeshAgent>();
	}

	// Update is called once per frame
	void Update () {
        Locate();
        if (trigger)
            EnemyShot();
	}

    // Looks for base unless it exists or the health is greater then 0
    void Locate() {
        if(@base != null)
            if(@base.GetComponent<Base>().HP  > 0)
                navMash.SetDestination(@base.position); 
        
    }
    // Check for collider that the object comes in contact with 
    void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.tag == "Wall") {
            navMash.enabled = false;
            trigger = true;   
        }
        else
            navMash.enabled = true;
    }

    //Instantiate the projectile if it meet 
    //If the time meets the time cap it creats another projectile 
    void EnemyShot() {

        if (time > timeCap){
            //Creats a new object/sets the location pined by the user
            Instantiate(Prefab);
            Prefab.transform.position = spawnPoint.transform.position + spawnPoint.transform.right;
            Prefab.transform.localRotation = spawnPoint.transform.rotation;
            Prefab.transform.Rotate(spawnPoint.transform.rotation.z, spawnPoint.transform.rotation.x, 90);
            time = 0;
        }
        //Calculates the time between shots 
        time += 3 * Time.deltaTime;  
    }
}
