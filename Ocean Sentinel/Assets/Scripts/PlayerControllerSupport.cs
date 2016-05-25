using UnityEngine;
using System.Collections;

public class PlayerControllerSupport : MonoBehaviour
{
	public float MoveVelocity;
	public float newVelocity;
	public float projectileVelocity;
	public float projectileRate;
	public float newRate;
	private float nextProjectile = 0.0f;

	void ControllerFire()
	{
		GameObject controllerProjectile = (GameObject)Instantiate(Resources.Load("Projectile", typeof(GameObject)));

		controllerProjectile.transform.position = transform.position + transform.right;
		controllerProjectile.transform.localRotation = transform.rotation;
		controllerProjectile.transform.Rotate(transform.rotation.z, transform.rotation.x, 90);
		controllerProjectile.GetComponent<Rigidbody>().AddForce(transform.right * projectileVelocity, ForceMode.Force);
	}

	// Use this for initialization
	void Start ()
	{
		newVelocity = 1.0f;
		newRate = 1.0f;
		MoveVelocity = newVelocity;
		projectileRate = newRate;
	}
	
	// Update is called once per frame
	void Update ()
	{
		GameObject Center = GameObject.Find("Base");
		float Movement = Input.GetAxis("LeftJoystickX") * MoveVelocity;
		float adjustDistance = Input.GetAxis("LeftJoystickY") * MoveVelocity;
		CharacterController controllerControl = GetComponent<CharacterController>();

		Vector3 changeDist = new Vector3(adjustDistance, 0, 0);

		if (Input.GetButton("A") && Time.time >= nextProjectile)
		{
			nextProjectile = Time.time + projectileRate;
			ControllerFire();
		}

		if (Input.GetAxis("LeftJoystickX") <= 0.5f && Input.GetAxis("LeftJoystickX") > 0 ||
			Input.GetAxis("LeftJoystickX") >= -0.5f && Input.GetAxis("LeftJoystickX") < 0)
		{
			transform.RotateAround(Center.transform.position, Vector3.up, Movement * 2);
		}

		else if(Input.GetAxis("LeftJoystickX") > 0.5f && Input.GetAxis("LeftJoystickX") <= 1 || 
				Input.GetAxis("LeftJoystickX") < -0.5f && Input.GetAxis("LeftJoystickX") >= -1)
		{
			transform.RotateAround(Center.transform.position, Vector3.up, Movement * 4);
		}

		if (Mathf.Abs(GameObject.Find("Base").transform.position.x - transform.position.x) > 0 &&
			Mathf.Abs(GameObject.Find("Base").transform.position.x - transform.position.x) < 4 &&
			Mathf.Abs(GameObject.Find("Base").transform.position.z - transform.position.z) > 0 &&
			Mathf.Abs(GameObject.Find("Base").transform.position.z - transform.position.z) < 4)
		{
			if (Input.GetAxis("LeftJoystickY") <= 0.5f && Input.GetAxis("LeftJoystickY") > 0 ||
			Input.GetAxis("LeftJoystickY") >= -0.5f && Input.GetAxis("LeftJoystickY") < 0)
			{
				changeDist = transform.localRotation * (changeDist * 0.5f);
				controllerControl.Move(changeDist);
			}

			else if (Input.GetAxis("LeftJoystickY") > 0.5f && Input.GetAxis("LeftJoystickY") <= 1 ||
					Input.GetAxis("LeftJoystickY") < -0.5f && Input.GetAxis("LeftJoystickY") >= -1)
			{
				changeDist = transform.localRotation * changeDist;
				controllerControl.Move(changeDist);
			}
		}

		if (Mathf.Abs(GameObject.Find("Base").transform.position.x - transform.position.x) > 4 ||
			Mathf.Abs(GameObject.Find("Base").transform.position.z - transform.position.z) > 4)
		{
			if (Input.GetAxis("Vertical") > 0)
			{
				adjustDistance = 0;
			}
			else
			{
				controllerControl.Move(changeDist);
			}
		}
	}
}
