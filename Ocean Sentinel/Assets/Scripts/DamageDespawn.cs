using UnityEngine;
using System.Collections;

public class DamageDespawn : MonoBehaviour
{
	float bulletLife;
	//Accesses Base.cs and creates an object from it
	Base Objective;
	float damage = 10.0f;

	// Update is called once per frame
	void Update()
	{
		if (Time.deltaTime >= 7.0f)
		{
			Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter(Collision col)
	{

		if (col.gameObject.tag == "Base")
		{
			Destroy(gameObject);
			Objective = col.gameObject.GetComponent<Base>();
			if (Objective.Armor > 0)
			{
				Objective.Armor -= damage;
			}
			else if (Objective.Armor <= 0)
			{
				Objective.HP -= damage;
			}
		}
		else if (col.gameObject.tag == "Player")
		{
			Destroy(gameObject);
		}
	}
}
