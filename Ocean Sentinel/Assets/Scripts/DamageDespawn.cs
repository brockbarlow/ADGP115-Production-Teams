///////////////
//Created by Eugene Hochenedel
//
//////////////
using UnityEngine;
using System.Collections;

public class DamageDespawn : MonoBehaviour
{
	//Accesses the Base and creates an object from it
	Base Objective;
	//
	float damage = 10.0f;

	//Called when the object's collider trigger enters another collider 
	void OnTriggerEnter(Collider col)
	{
		//Allows for access to all values in the the Base.cs script
		Objective = FindObjectOfType<Base>();
		//Checks the tag of the object the Collider is attached to
		if (col.gameObject.tag == "Base")
		{
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
			else if (Objective.Armor <= 0)
			{
				//Decrements the value of HP by damage
				Objective.HP -= damage;
			}
		}

		//Checks if the Collider is attached to a game object with the player tag
		else if (col.gameObject.tag == "Player")
		{
			Destroy(gameObject);
		}
	}
}
