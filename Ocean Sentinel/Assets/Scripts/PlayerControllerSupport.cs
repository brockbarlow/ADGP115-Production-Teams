using UnityEngine;
using System.Collections;

public class PlayerControllerSupport : MonoBehaviour
{
	public float MoveVelocity;
	private float Movement;
	public float projectileVelocity;
	public float projectileRate;
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
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		GameObject Center = GameObject.Find("Base");

		if(Input.GetButton("A") && Time.time >= nextProjectile)
		{
			nextProjectile = Time.time + projectileRate;
			ControllerFire();
		}

		if(Input.GetAxis("LeftJoystickX") == 0.0f)
		{
			Movement = 0.0f;
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
	}
}
