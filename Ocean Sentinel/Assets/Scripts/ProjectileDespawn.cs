///////////////
//Created by Eugene Hochenedel
//
//////////////
using UnityEngine;
using System.Collections;

//Destroys instantiations of the attached object on trigger detection
//And destroys marked objects that the trigger detected
//And increments a value named gold

public class ProjectileDespawn : MonoBehaviour
{
	//Empty value that's used for despawning the projectile
	float projectileTime;
	//An arbitrary value that's used when an enemy object is destroyed
	float enemyDrop = 20.0f;
	//Accesses the GameController script
	GameController GC;

	//Update is called once per frame
	void Update ()
	{
		//Adds the value of deltaTime to projectileTime
		projectileTime += Time.deltaTime;
		
		//Checks if the value of projectileTime is greater than or equal to 2.0
		if (projectileTime >= 2.0f)
		{
			//Destroys this game object
			Destroy(this.gameObject);	
		}
	}

	//Called when the Collider col enters this object's trigger
	void OnTriggerEnter(Collider col)
	{
		//Allows for access to all values in the GameController.cs script
		GC = FindObjectOfType<GameController>();

		//Checks if this game object collided with another that has the Enemy tag
		if(col.gameObject.tag == "Enemy")
		{
            GC.PlaySound(0, 0.75f, 1);
            //Makes an explosion at the enemy's position
            GameObject explosion = (GameObject)Instantiate(Resources.Load("Explosion", typeof(GameObject)));
            explosion.transform.position = col.transform.position;
            //Destroys this game object
            Destroy(gameObject);
			//Destroys the game object that this one collided with
			Destroy(col.gameObject);
			//Accesses a value named Gold in the GameController script and adds the value of enemyDrop to it
			GC.Gold += enemyDrop;
		}

		//Checks if the tag of the object the Collider is attached to is Projectile
		if (col.gameObject.tag == "Projectile")
		{
			GC.PlaySound(1, 0.5f, 1);
			Destroy(gameObject);
			//Destroys the object with the Projectile tag
			Destroy(col.gameObject);
		}
	}
}
