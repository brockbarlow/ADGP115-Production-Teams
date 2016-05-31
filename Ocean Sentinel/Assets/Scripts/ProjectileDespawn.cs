using UnityEngine;
using System.Collections;

public class ProjectileDespawn : MonoBehaviour
{
	float projectileTime;
	float enemyDrop = 20.0f;
	GameController GC;
	
	// Update is called once per frame
	void Update ()
	{
		projectileTime += Time.deltaTime;
		if(projectileTime >= 10.0f)
		{
			Destroy(this.gameObject);
		}
	}

	//
	void OnTriggerEnter(Collider col)
	{
		GC = FindObjectOfType<GameController>();
		if(col.gameObject.tag == "Enemy")
		{
            GC.PlaySound();
			Destroy(gameObject);
			Destroy(col.gameObject);
			GC.Gold += enemyDrop;
		}
		if (col.gameObject.tag == "Projectile")
		{
			//Destroys this instance of the object
			Destroy(gameObject);
			//Destroys the object with the Projectile tag
			Destroy(col.gameObject);
		}
		if (col.gameObject.tag == "Player")
		{
			Destroy(gameObject);
		}
	}
}
