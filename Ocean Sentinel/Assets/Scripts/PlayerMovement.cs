using UnityEngine;
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
		GameObject playerProjectile = (GameObject)Instantiate(Attack_Prefab, transform.position + transform.right, transform.rotation);
		playerProjectile.GetComponent<Rigidbody>().AddForce(transform.right * projectileVelocity, ForceMode.Force);
		Destroy(playerProjectile, 4.0f);
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
		//transform.Rotate(0, Movement * 4, 0);
		transform.RotateAround(Temp.transform.position, Vector3.up, Movement * 4);

		if(Input.GetButton("Fire1") && Time.time > nextProjectile)
		{
			nextProjectile = Time.time + projectileRate;
			FireProjectile();
		}
		//Vector3 speed = new Vector3(Movement, 0, 0);

		//speed = transform.rotation * speed;

		//CharacterController playerMotion = GetComponent<CharacterController>();
		//playerMotion.Move(speed);

		//transform.RotateAround(Temp.transform.position, Vector3.up, speed.x);

		Debug.Log(transform.localPosition);
	}
}