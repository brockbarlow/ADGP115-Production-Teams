///////////////
//Created by Eugene Hochenedel
//
//////////////
using UnityEngine;
using System.Collections;

//This script allows for objects to move along a vertical path
//This is based off of the SpawnMoverHorizontal.cs script

public class SpawnMoverVertical : MonoBehaviour
{
	private bool leave = false; //if the spawn points can move or not

	//Custom Lerp function by the project manager. The object's transform.position becomes a new Vector3 variable
	void Lerp(float a, float b, float c)
	{
		gameObject.transform.position = new Vector3(transform.position.x + a, transform.position.y + b, transform.position.z + c);
	}

	// Update is called once per frame
	void Update()
	{
		//Checks if the deltaTime is greater than 0
		if (Time.deltaTime > 0)
		{
			//If leave is true, the object's Z-Coordinate will increase
			if (leave == true)
			{
				Lerp(0, 0, 0.4f);
			}
			//If leave is false, the object's Z-Coordinate will decrease
			if (leave == false)
			{
				Lerp(0, 0, -0.4f);
			}
		}

		//If the object's Z-Coordinate, relative to its parent, is less than or equal to -10, set leave to true
		if (gameObject.transform.localPosition.z <= -60)
		{
			leave = true;
		}

		//If the object's Z-Coordinate, relative to its parent, is greater than or equal to 35, set leave to false
		if (gameObject.transform.localPosition.z >= 60)
		{
			leave = false;
		}
	}
}
