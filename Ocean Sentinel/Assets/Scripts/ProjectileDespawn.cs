///////////////
//Created by Eugene Hochenedel
//
//////////////
using UnityEngine;
using System.Collections;

public class ProjectileDespawn : MonoBehaviour
{
	//Empty value that's used for despawning the projectile
	float projectileTime;
	//
	float enemyDrop = 20.0f;
	//Accesses the GameController script
	GameController GC;
	
	// Update is called once per frame
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
		//Outputs the current value of projectileTime to the Unity Console
			Debug.Log("Projectile despawned. " + projectileTime);
	}

	//Called when the Collider col enters this object's trigger
	void OnTriggerEnter(Collider col)
	{
		//Alloows for access to all values in the GameController.cs script
		GC = FindObjectOfType<GameController>();

		//Checks if this game object collided with another that has the Enemy tag
		if(col.gameObject.tag == "Enemy")
		{
            GC.PlaySound();
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

			Destroy(gameObject);
			//Destroys the object with the Projectile tag
			Destroy(col.gameObject);
			//Outputs to the Unity Console if triggered
			Debug.Log("Both Destroyed");
		}
	}
}
