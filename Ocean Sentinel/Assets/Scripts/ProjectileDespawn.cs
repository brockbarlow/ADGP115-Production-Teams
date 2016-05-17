using UnityEngine;
using System.Collections;

public class ProjectileDespawn : MonoBehaviour
{
	float projectileTime;
	//GameController Drops;
	float enemyDrop = 15.0f;
	
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
	void OnCollisionEnter(Collision col)
	{
		
		if(col.gameObject.tag == "Enemy")
		{
			
			Destroy(gameObject);
			Destroy(col.gameObject);
			//Drops = GameObject.FindGameObjectWithTag("GameController")
			GameObject.Find("GameController").GetComponent<GameController>().Gold += enemyDrop;
		}
	}
}
