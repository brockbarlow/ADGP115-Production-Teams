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
		transform.RotateAround(GameObject.Find("Base").transform.position, Vector3.up, Movement * 4);

		float addDistance = Input.GetAxis("Vertical") * MoveVelocity;

		Vector3 TempMotion = new Vector3(addDistance, 0, 0);
		TempMotion = transform.localRotation * TempMotion;
		CharacterController TempControl = GetComponent<CharacterController>();

		if (Mathf.Abs(GameObject.Find("Base").transform.position.x - transform.position.x) > 0 &&
			Mathf.Abs(GameObject.Find("Base").transform.position.x - transform.position.x) < 4 &&
			Mathf.Abs(GameObject.Find("Base").transform.position.z - transform.position.z) > 0 &&
			Mathf.Abs(GameObject.Find("Base").transform.position.z - transform.position.z) < 4)
		{
			TempControl.Move(TempMotion);
		}

		if (Mathf.Abs(GameObject.Find("Base").transform.position.x - transform.position.x) > 4 ||
			Mathf.Abs(GameObject.Find("Base").transform.position.z - transform.position.z) > 4)
		{
			if (Input.GetAxis("Vertical") > 0)
			{
				addDistance = 0;
			}
			else
			{
				TempControl.Move(TempMotion);
			}
		}

		if (Input.GetButton("Fire1") && Time.time >= nextProjectile)
		{
			nextProjectile = Time.time + projectileRate;
			FireProjectile();
		}
	}
}