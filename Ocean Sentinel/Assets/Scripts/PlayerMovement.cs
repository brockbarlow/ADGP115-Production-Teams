using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public float MoveVelocity;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		//All movement should be in a circular motion around a game object designated as the base
		//Allows for movement of the Player gameObject using 'A' & 'D' or the 'left' & 'right' arrowkeys
		

		float TravelArc = Mathf.LerpAngle(0, 359, 0);
		//transform.eulerAngles = new Vector3(0, TravelArc, 0);
		float Movement = Input.GetAxis("Horizontal") * MoveVelocity;
		Vector3 speed = new Vector3(Movement + TravelArc, 0, 0);
		//speed = TravelArc * speed;

		CharacterController playerMotion = GetComponent<CharacterController>();
		playerMotion.Move(speed);
	}
}