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
		transform.Rotate(0, Movement * 4, 0);

		transform.localPosition = new Vector3(Mathf.Clamp(transform.position.x, -1.5f, 1.5f) * Movement, 0, Movement);
		Vector3 speed = new Vector3(Movement, 0, 0);
		
		//transform.position = transform.parent.position;
		//transform.localRotation = Quaternion.Euler(0, Movement, 0);

		speed = transform.localRotation * speed;

		CharacterController playerMotion = GetComponent<CharacterController>();
		playerMotion.Move(speed);

		Debug.Log(transform.position);
	}
}