using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public float MoveVelocity;
	public float newVelocity;
	public float projectileVelocity;
	public float projectileRate;
	public float newRate;
	private float nextProjectile = 0.0F;
	public GameController GC;

	void FireProjectile()
	{
		//Instantiates a game object by loading a prefab located in the Resources folder
		GameObject playerProjectile = (GameObject)Instantiate(Resources.Load("Projectile", typeof(GameObject)));

		//Places the new game object relative to the player object
		playerProjectile.transform.position = transform.position + transform.right;
		
		//Rotates the spawned projectile with the player object's movement.
		playerProjectile.transform.localRotation = transform.rotation;
		
		//Rotates the spawned object an additional ninety degrees on the Y-Axis
		playerProjectile.transform.Rotate(transform.rotation.z, transform.rotation.x, 90);
		
		//Applies a force to the game object that changes the magnitude and direction
		playerProjectile.GetComponent<Rigidbody>().AddForce(transform.right * projectileVelocity, ForceMode.Force);
	}

	void Start()
	{
		GC = FindObjectOfType<GameController>();
		newVelocity = 1.0f;
		newRate = 1.0f;
		MoveVelocity = newVelocity;
		projectileRate = newRate;
	}

	// Update is called once per frame
	void Update()
	{
		//All movement should be in a circular motion around a game object designated as the base
		//Allows for movement of the Player gameObject using 'A' & 'D' or the 'left' & 'right' arrow keys
		float Movement = Input.GetAxis("Horizontal") * MoveVelocity;

		float addDistance = Input.GetAxis("Vertical") * MoveVelocity;

		transform.RotateAround(GameObject.Find("Base").transform.position, Vector3.up, Movement * 4);

		//Vector3 Temp1 = new Vector3(transform.position.x + 2, 0, transform.position.z + 2);

		//Vector3 TempMotion = new Vector3(0, 0, addDistance);
		//TempMotion = transform.localRotation * TempMotion;

		//transform.position = Vector3.MoveTowards(transform.position, Vector3.up, Time.deltaTime);
		

		if (Input.GetButton("Fire1") && Time.time >= nextProjectile)
		{
			nextProjectile = Time.time + projectileRate;
			FireProjectile();
		}
		Debug.Log(transform.localRotation);
	}
}