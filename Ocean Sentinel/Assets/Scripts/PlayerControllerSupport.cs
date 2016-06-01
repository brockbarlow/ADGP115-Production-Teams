///////////////
//Created by Eugene Hochenedel
//
//////////////
using UnityEngine;
using System.Collections;

//This script is heavily based off of the PlayerMovement.cs script for consistency

public class PlayerControllerSupport : MonoBehaviour
{
	public float MoveVelocity;
	public float newVelocity;
	public float projectileVelocity;
	public float projectileRate;
	public float newRate;
	private float nextProjectile;
	Base Defend;
	public AudioClip ProjectileShoot;
	AudioSource sfx;

	void ControllerFire()
	{
		GameObject controllerProjectile = (GameObject)Instantiate(Resources.Load("Projectile", typeof(GameObject)));

		sfx.clip = ProjectileShoot;
		
		Rigidbody rbShot = FindObjectOfType<Rigidbody>();

		controllerProjectile.transform.position = transform.position + transform.right;
		
		controllerProjectile.transform.localRotation = transform.rotation;
		
		controllerProjectile.transform.Rotate(transform.rotation.z, transform.rotation.x, 90);
		
		rbShot.AddForce(transform.right * projectileVelocity, ForceMode.Force);
		
		sfx.Play();
	}

	// Use this for initialization
	void Start ()
	{
		newVelocity = 1.0f;
		newRate = 1.0f;
		MoveVelocity = newVelocity;
		projectileRate = newRate;
		Defend = FindObjectOfType<Base>();
		sfx = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (projectileRate < 0.2)
		{
			projectileRate = 0.0625f;
		}

		float Movement = Input.GetAxis("LeftJoystickX") * MoveVelocity;
		float adjustDistance = Input.GetAxis("LeftJoystickY") * MoveVelocity;
		
		CharacterController distanceControl = GetComponent<CharacterController>();
		Vector3 radialMotion = new Vector3(adjustDistance, 0, 0);

		if (Input.GetButton("A") && Time.time >= nextProjectile)
		{
			nextProjectile = Time.time + projectileRate;
			ControllerFire();
		}

		//
		if (Input.GetAxis("LeftJoystickX") <= 0.5f && Input.GetAxis("LeftJoystickX") > 0 ||
			Input.GetAxis("LeftJoystickX") >= -0.5f && Input.GetAxis("LeftJoystickX") < 0)
		{
			transform.RotateAround(Defend.transform.position, Vector3.up, Movement * 2);
		}

		//
		else if(Input.GetAxis("LeftJoystickX") > 0.5f && Input.GetAxis("LeftJoystickX") <= 1 || 
				Input.GetAxis("LeftJoystickX") < -0.5f && Input.GetAxis("LeftJoystickX") >= -1)
		{
			transform.RotateAround(Defend.transform.position, Vector3.up, Movement * 4);
		}

		//
		if (Vector3.Distance(Defend.transform.position, transform.position) < 4 ||
			Vector3.Distance(Defend.transform.position, transform.position) > 4 &&
			Input.GetAxis("LeftJoystickY") < 0)
		{
			//
			if (Input.GetAxis("LeftJoystickY") <= 0.5f && Input.GetAxis("LeftJoystickY") > 0 ||
			Input.GetAxis("LeftJoystickY") >= -0.5f && Input.GetAxis("LeftJoystickY") < 0)
			{
				radialMotion = transform.localRotation * (radialMotion * 0.5f);
				distanceControl.Move(radialMotion);
			}
			//
			else if (Input.GetAxis("LeftJoystickY") > 0.5f && Input.GetAxis("LeftJoystickY") <= 1 ||
					Input.GetAxis("LeftJoystickY") < -0.5f && Input.GetAxis("LeftJoystickY") >= -1)
			{
				radialMotion = transform.localRotation * radialMotion;
				distanceControl.Move(radialMotion);
			}
		}
	}
}
