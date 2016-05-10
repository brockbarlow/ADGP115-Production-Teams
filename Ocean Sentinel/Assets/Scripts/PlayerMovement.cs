using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public float MoveVelocity;
	//public GameObject Temp;

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
		transform.Rotate(0, Movement, 0);

		Vector3 speed = new Vector3(Movement, 0, 0);
		transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, -1.6f, 1.6f) * Movement, 0, 0);
		
		//transform.localRotation = Quaternion.Euler(0, Movement, 0);

		speed = transform.rotation * speed;

		CharacterController playerMotion = GetComponent<CharacterController>();
		playerMotion.Move(speed);

		if (transform.position.x > 1.55f || transform.position.x < -1.55f)
		{
			playerMotion.detectCollisions = true;
		}
		else
		{
			playerMotion.detectCollisions = false;
		}

		Debug.Log(transform.position);
	}
}