using UnityEngine;
using System.Collections;
/// <summary>
/// Creater: William Montero
/// EnemyAI is a class made for the enemies movement 
/// It makes a few checks 
/// if base exists
/// if if the base hp is greater then 0 
/// Enemy well taht travel to said location 
/// </summary>
public class EnemyAI : MonoBehaviour
{

    // Players Transformer Will be used to track the players location 
    Transform @base;
    //Instance so i can reffer wether or not it has found the wall.
    public GameObject Prefab;
    //Refrence to the audio sorce 
    AudioSource sfx;
    //Sets the enemy speed sets to the players location 
	public float attackSpeed;
    //Time between projectile  
    public float time;
    //Time till next shot 
    private float timeCap;
    
    //Referres to the games naviagtion mesh 
    //GameObject wall;
    NavMeshAgent navMash;

    // Use this for initialization
    //Set Refrences
    void Start()
    {
        @base = GameObject.FindGameObjectWithTag("Base").transform;

        navMash = GetComponent<NavMeshAgent>();

        sfx = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        Locate();

		timeCap += Time.deltaTime;
		if (navMash.enabled == false && timeCap > time)
		{
			//timeCap = Time.time + time;
			timeCap = 0;
            sfx.Play(); 
			EnemyShot();
            
		}
		//Debug.Log("Time " + timeCap);
	}

    // Looks for base unless it exists or the health is greater then 0
    void Locate()
    {
		if (@base != null && navMash.enabled == true)
		{
			if (@base.GetComponent<Base>().HP > 0)
			{
				navMash.SetDestination(@base.position);
			}
		}
    }
    // Check for collider that the object comes in contact with 
    void OnTriggerEnter(Collider collision)
    {
		if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy")
		{
			navMash.enabled = false;
			gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
		}
    }

    //Instantiate the projectile if it meet
    //If the time meets the time cap it creats another projectile
	//
    void EnemyShot()
    {
		//Creats a new object instance from a prefab
		GameObject enemyProjectile = Instantiate(Prefab);
		//Creates a Vector3 for the direction of a force vector
		Vector3 Targeting = (@base.position - transform.position).normalized;
		//
		enemyProjectile.transform.position = transform.position + transform.forward;
		//
		enemyProjectile.transform.localRotation = transform.rotation;
		//
		enemyProjectile.transform.Rotate(90, transform.rotation.x, transform.rotation.y);
		//
		enemyProjectile.GetComponent<Rigidbody>().AddForce(Targeting * attackSpeed, ForceMode.Force);
	}
}