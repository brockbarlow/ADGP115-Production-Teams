///////////////
//Created by Eugene Hochenedel
//
//////////////
using UnityEngine;
using System.Collections;

public class DamageDespawn : MonoBehaviour
{
	//
	//float bulletLife;
	//Accesses the Base and creates an object from it
	Base Objective;
	//
	float damage = 10.0f;

	//
	void OnTriggerEnter(Collider col)
	{
		//
		Objective = FindObjectOfType<Base>();
		//
		if (col.gameObject.tag == "Base")
		{
			//
			Destroy(gameObject);
			
			//
			if (Objective.Armor > 0)
			{
				//
				Objective.Armor -= damage;
				Objective.HP -= 1;
			}
			//
			else if (Objective.Armor <= 0)
			{
				//
				Objective.HP -= damage;
			}
		}

		//
		else if (col.gameObject.tag == "Player")
		{
			Destroy(gameObject);
		}
	}
}
