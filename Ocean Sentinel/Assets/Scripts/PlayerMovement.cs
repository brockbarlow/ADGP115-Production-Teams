using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public float MoveVelocity;
	public float newVelocity;
	public float projectileVelocity;
	public float projectileRate;
	public float newRate;
	private float nextProjectile;
	Base Defend;
	
	
	void FireProjectile()
	{
		//Instantiates a game object by loading a prefab located in the Resources folder
		GameObject playerProjectile = (GameObject)Instantiate(Resources.Load("Projectile", typeof(GameObject)));
		AudioSource sfx = FindObjectOfType<AudioSource>();
		Rigidbody rbShot = FindObjectOfType<Rigidbody>();

		//Places the new game object relative to the player object
		playerProjectile.transform.position = transform.position + transform.right;
		
		//Rotates the spawned projectile with the player object's movement.
		playerProjectile.transform.localRotation = transform.rotation;
		
		//Rotates the spawned object an additional ninety degrees on the Y-Axis
		playerProjectile.transform.Rotate(transform.rotation.z, transform.rotation.x, 90);

		//Applies a force to the game object that changes the magnitude and direction
		rbShot.AddForce(transform.right * projectileVelocity, ForceMode.Force);

		//Plays an audio clip whenever a projectile is instantiated
		sfx.Play();
	}

	void Start()
	{
		newVelocity = 1.0f;
		newRate = 1.0f;
		MoveVelocity = newVelocity;
		projectileRate = newRate;
		Defend = FindObjectOfType<Base>();
	}

	// Update is called once per frame
	void Update()
	{
		if (projectileRate < 0.2)
		{
			projectileRate = 0.0625f;
		}
		//All movement should be in a circular motion around a game object designated as the base
		//Allows for movement of the Player gameObject using 'A' & 'D' or the 'left' & 'right' arrow keys
		float Movement = Input.GetAxis("Horizontal") * MoveVelocity;
		transform.RotateAround(Defend.transform.position, Vector3.up, Movement * 4);

		float adjustDistance = Input.GetAxis("Vertical") * MoveVelocity;

		Vector3 radialMotion = transform.localRotation * new Vector3(adjustDistance, 0, 0);
		CharacterController distanceControl = GetComponent<CharacterController>();

		if (Vector3.Distance(Defend.transform.position, transform.position) < 4 ||
			Vector3.Distance(Defend.transform.position, transform.position) > 4 &&
			Input.GetAxis("Vertical") < 0)
		{
			distanceControl.Move(radialMotion);
		}

		if (Input.GetButton("Fire1") && Time.time > nextProjectile)
		{
			nextProjectile =  Time.time + projectileRate;
			FireProjectile();
		}
		//Debug.Log("Time: " + Time.time);
		//Debug.Log("NP: " + nextProjectile);
	}
}