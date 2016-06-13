///////////////
//Created by Eugene Hochenedel
//
//////////////
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private EventSystem ES;
	//The speed at which the player will move
	public float MoveVelocity;
	//A constant value that's used as the base speed for the player to move
	public float newVelocity;
	//The speed of projectiles that the player instantiates
	public float projectileVelocity;
	//A value that determines the amount of time inbetween each projectile
	public float projectileRate;
	//A constant value that's used as the base time inbetween each projectile
	public float newRate;
	//A changing value that will be used to check if a projectile can be instantiated
	private float nextProjectile;
	//Accesses the Base class
	Base Defend;
	//Used for accessing a child of this game object
	GameObject Ship;
	//Provides access to the Game Controller script
	GameController GC;

	//Function that's used to instantiate a projectile object with a velocity 
	void FireProjectile()
	{
		//Instantiates a game object by loading a prefab located in the Resources folder
		GameObject playerProjectile = (GameObject)Instantiate(Resources.Load("Projectile", typeof(GameObject)));
		
		//Performs the PlaySound function from the GameController script on instantiation
		GC.PlaySound(2, 0.45f, 1.5f);
		
		//
		Rigidbody rbShot = FindObjectOfType<Rigidbody>();

		//Places the new game object relative to the player object
		playerProjectile.transform.position = transform.position + transform.right;
		
		//Rotates the spawned projectile with the player object's movement.
		playerProjectile.transform.localRotation = transform.rotation;
		
		//Rotates the spawned object an additional ninety degrees on the Y-Axis
		playerProjectile.transform.Rotate(transform.rotation.z, transform.rotation.x, 90);

		//Applies a force to the game object that changes the magnitude and direction
		rbShot.AddForce(transform.right * projectileVelocity, ForceMode.Force);
	}

	void Start()
	{
		GC = FindObjectOfType<GameController>();
		newVelocity = 1.0f;
		newRate = 1.0f;
		MoveVelocity = newVelocity;
		projectileRate = newRate;
		Defend = FindObjectOfType<Base>();
        ES = FindObjectOfType<EventSystem>();
		Ship = GameObject.Find("ShipGRP");
	}

	// Update is called once per frame
	void Update()
	{
		//Limits the projectile rate to avoid projectiles
		if (projectileRate < 0.2)
		{
			projectileRate = 0.0625f;
		}



		//All movement should be in a circular motion around a game object designated as the base
		//Allows for movement of the Player gameObject using 'A' & 'D' or the 'left' & 'right' arrow keys

		float Movement = Input.GetAxis("Horizontal") * MoveVelocity;
		
		//Sets up movent to allow for a limited distance the player can move away from the base
		//Allows for movement of the Player gameObject using 'W' & 'S' or the 'up' & 'down' arrow keys
		float adjustDistance = Input.GetAxis("Vertical") * MoveVelocity;
		
		//Float that's used to determine the amount of time inbetween each shot.
		nextProjectile += Time.deltaTime;

		if (Time.deltaTime != 0)
		{
			//Cirularizes the player's movement to be around the base game object
			transform.RotateAround(Defend.transform.position, Vector3.up, Movement * 4);

			//Connects how the player will move with vertical input to their rotation
			Vector3 radialMotion = transform.localRotation * new Vector3(adjustDistance, 0, 0);
			CharacterController distanceControl = GetComponent<CharacterController>();

			//Checks the distance between the player and the base
			//If the distance is less than four then the player can move with vertical input
			//But if the distance is greater than four then the player can only move towards the base
			if (Vector3.Distance(Defend.transform.position, transform.position) < 6 ||
				Vector3.Distance(Defend.transform.position, transform.position) > 6 &&
				Input.GetAxis("Vertical") < 0)
			{
				distanceControl.Move(radialMotion);
			}
			if (Input.GetButton("Fire1") && nextProjectile > projectileRate && ES.currentSelectedGameObject == null)
			{
				nextProjectile = 0;
				FireProjectile();
			}
		}
		//Changes the Ship object's localRotation about the Y-axis to 180
		if (Input.GetAxis("Horizontal") > 0 && Ship.transform.rotation.y < 1)
		{
			Ship.transform.localRotation = Quaternion.Euler(0, 180, 0);
		}

		//Changes the Ship object's localRotation about the Y-axis to 0
		if(Input.GetAxis("Horizontal") < 0 && Ship.transform.rotation.y > -1)
		{
			Ship.transform.localRotation = Quaternion.Euler(0, 0, 0);
		}
	}
}