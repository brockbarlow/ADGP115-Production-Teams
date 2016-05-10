using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public float MoveVelocity;
	public GameObject Temp; 
	//float MaxValue = 1.55f;
	//float MinValue = -1.55f;


	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		//All movement should be in a circular motion around a game object designated as the base
		//Allows for movement of the Player gameObject using 'A' & 'D' or the 'left' & 'right' arrowkeys
		
		
		float Turn = Input.GetAxis("Horizontal") * MoveVelocity;
		transform.Rotate(0, Turn, 0);

		float Movement = Input.GetAxis("Horizontal") * MoveVelocity;
		//transform.localRotation = Quaternion.Euler(Movement + 1, 0, 0);
		//transform.Rotate(0, Movement, 0);
		CharacterController playerMotion = GetComponent<CharacterController>();
		
		Vector3 speed = new Vector3(Movement, 0, 0);
		//Vector3 Limitation = new Vector3(1.6f, 0, 1.6f);
		//Bounds Stopping = new Bounds(Vector3.zero, Limitation);

		speed = transform.localRotation * speed;
		
		playerMotion.Move(speed);
		//playerMotion.center = transform.position;
		
		if(Temp.transform.position.x > 1.55f || Temp.transform.position.x < -1.55f)
		{
			playerMotion.detectCollisions = true;
		}
		else
		{
			playerMotion.detectCollisions = false;
		}

		Debug.Log(playerMotion.detectCollisions);
	}
}