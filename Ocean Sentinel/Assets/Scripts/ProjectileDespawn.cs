///////////////
//Created by Eugene Hochenedel
//
//////////////
using UnityEngine;
using System.Collections;

public class ProjectileDespawn : MonoBehaviour
{
	//
	float projectileTime;
	//
	float enemyDrop = 20.0f;
	//Accesses the GameController script
	GameController GC;
	
	// Update is called once per frame
	void Update ()
	{
		//
		projectileTime += Time.deltaTime;
		
		//
		if (projectileTime >= 2.0f)
		{
			//Destroys this game object
			Destroy(this.gameObject);
			Debug.Log("Projectile despawned. " + projectileTime);
		}
	}

	//Called when the Collider col enters this object's trigger
	void OnTriggerEnter(Collider col)
	{
		//
		GC = FindObjectOfType<GameController>();

		//Checks if this game object collided with another that has the Enemy tag
		if(col.gameObject.tag == "Enemy")
		{
			//Destroys this game object
			Destroy(gameObject);
			//Destroys the game object that this one collided with
			Destroy(col.gameObject);
			//Accesses a value named Gold in the GameController script and adds the value of enemyDrop to it
			GC.Gold += enemyDrop;
		}
		if (col.gameObject.tag == "Projectile")
		{
			//Destroys this instance of the object
			Destroy(gameObject);
			//Destroys the object with the Projectile tag
			Destroy(col.gameObject);
			Debug.Log("Both Destroyed");
		}
	}
}
