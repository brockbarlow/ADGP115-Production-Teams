///////////////
//Created by Eugene Hochenedel
//
//////////////
using UnityEngine;
using System.Collections;

//This script is used for despawning the connected object
//It performs trigger checks to destroy it and decrement values associated with the Base class

public class DamageDespawn : MonoBehaviour
{
	//Accesses the Base and creates an object from it
	Base Objective;
	//Accesses an object with the GameController script attached to it
	public GameController GC;
	//An arbitrary value that's used for certain triggers
	float damage = 10.0f;

	//Called when the object's collider trigger enters another collider 
	void OnTriggerEnter(Collider col)
	{
		GC = FindObjectOfType<GameController>();
		//Allows for access to all values in the the Base.cs script
		Objective = FindObjectOfType<Base>();
		//Checks the tag of the object the Collider is attached to
		if (col.gameObject.tag == "Base")
		{
			GC.PlaySound(1, 0.8f, 1);
			//Destroys this instance of the object
			Destroy(gameObject);
			
			//Checks if the value of Armor on the Base class is greater than zero
			if (Objective.Armor > 0)
			{
				//Decrements the value of Armor by the damage value
				Objective.Armor -= damage;
				Objective.HP -= 1;
			}

			//Checks if the Armor value is less than or equal to zero
			else if (Objective.Armor <= 0 && Objective.HP > 0)
			{
				//Decrements the value of HP by damage
				Objective.HP -= damage;
			}
		}

		//Checks if the Collider is attached to a gameobject with the player tag
		else if (col.gameObject.tag == "Player")
		{
			Destroy(gameObject);
		}
	}
}
