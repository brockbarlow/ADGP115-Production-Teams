using UnityEngine;
using System.Collections;

public class DamageDespawn : MonoBehaviour
{
	float bulletLife;
	Base Temp;
	float damage = 10.0f;

	// Update is called once per frame
	void Update()
	{
		bulletLife += Time.deltaTime;
		if (bulletLife >= 10.0f)
		{
			Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter(Collision col)
	{

		if (col.gameObject.tag == "Base")
		{
			Destroy(gameObject);
			Temp = col.gameObject.GetComponent<Base>();
			if (Temp.Armor >= 0)
			{
				Temp.Armor -= damage;
			}
			else if(Temp.Armor <= 0)
			{
				Temp.HP -= damage;
			}
		}
	}
}
