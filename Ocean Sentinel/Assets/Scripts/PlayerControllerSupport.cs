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
	public GameController GC;

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
		GC = FindObjectOfType<GameController>();
		newVelocity = 1.0f;
		newRate = 1.0f;
		MoveVelocity = newVelocity;
		projectileRate = newRate;
	}
	
	// Update is called once per frame
	void Update ()
	{
		GameObject Center = GameObject.Find("Base");
		float Movement;
		float adjustDistance;
		CharacterController controllerControl = GetComponent<CharacterController>();

		if(Input.GetButton("A") && Time.time >= nextProjectile)
		{
			nextProjectile = Time.time + projectileRate;
			ControllerFire();
		}

		if(Input.GetAxis("LeftJoystickX") == 0.0f || Input.GetAxis("LeftJoystickY") == 0.0f)
		{
			MoveVelocity = 0.0f;
		}

		else if (Input.GetAxis("LeftJoystickX") <= 0.5f && Input.GetAxis("LeftJoystickX") > 0 ||
			Input.GetAxis("LeftJoystickX") >= -0.5f && Input.GetAxis("LeftJoystickX") < 0)
		{
			Movement = Input.GetAxis("LeftJoystickX") * MoveVelocity;
			transform.RotateAround(Center.transform.position, Vector3.up, Movement * 2);
		}

		else if(Input.GetAxis("LeftJoystickX") > 0.5f && Input.GetAxis("LeftJoystickX") <= 1 || 
				Input.GetAxis("LeftJoystickX") < -0.5f && Input.GetAxis("LeftJoystickX") >= -1)
		{
			Movement = Input.GetAxis("LeftJoystickX") * MoveVelocity;
			transform.RotateAround(Center.transform.position, Vector3.up, Movement * 4);
		}
		
		else if (Input.GetAxis("LeftJoystickY") <= 0.5f && Input.GetAxis("LeftJoystickY") > 0 ||
			Input.GetAxis("LeftJoystickY") >= -0.5f && Input.GetAxis("LeftJoystickY") < 0)
		{
			adjustDistance = Input.GetAxis("LeftJoystickY") * MoveVelocity;
			Vector3 changeDist = new Vector3(adjustDistance * 0.5f, 0, 0);
			changeDist = transform.localRotation * changeDist;
			controllerControl.Move(changeDist);
		}

		else if (Input.GetAxis("LeftJoystickY") > 0.5f && Input.GetAxis("LeftJoystickY") <= 1 ||
				Input.GetAxis("LeftJoystickY") < -0.5f && Input.GetAxis("LeftJoystickY") >= -1)
		{
			adjustDistance = Input.GetAxis("LeftJoystickY") * MoveVelocity;
			Vector3 changeDist = new Vector3(adjustDistance, 0, 0);
			changeDist = transform.localRotation * changeDist;
			controllerControl.Move(changeDist);
		}
	}
}
