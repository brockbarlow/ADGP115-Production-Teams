﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public float MoveVelocity;
	public GameObject Temp;
	public GameObject Attack_Prefab;
	public float projectileVelocity;
	public float projectileRate;
	private float nextProjectile = 0.0F;
	
	void FireProjectile()
	{
		//Spawns a cloned game object that's instantiated from a prefab
		GameObject playerProjectile = Instantiate(Attack_Prefab);
		
		//Places the new game object relative to the player object in relation to the base object
		playerProjectile.transform.position = transform.position + transform.right;
		
		//Rotates the spawned projectile with the player objects movement.
		playerProjectile.transform.localRotation = transform.rotation;
		
		//Rotates the spawned object an additional ninty degrees on the Y-Axis
		playerProjectile.transform.Rotate(transform.rotation.z, transform.rotation.x, 90);
		
		//Applies a force to the game object and changes the magnitude
		playerProjectile.GetComponent<Rigidbody>().AddForce(transform.right * projectileVelocity, ForceMode.Force);
	}

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		//All movement should be in a circular motion around a game object designated as the base
		//Allows for movement of the Player gameObject using 'A' & 'D' or the 'left' & 'right' arrowkeys
		float Movement = Input.GetAxis("Horizontal") * MoveVelocity;
		transform.RotateAround(Temp.transform.position, Vector3.up, Movement * 4);
		
		if(Input.GetButton("Fire1") && Time.time > nextProjectile)
		{
			nextProjectile = Time.time + projectileRate;
			FireProjectile();
		}
	}
}