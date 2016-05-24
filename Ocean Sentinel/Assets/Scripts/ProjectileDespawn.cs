using UnityEngine;
using System.Collections;

public class ProjectileDespawn : MonoBehaviour
{
	float projectileTime;
	float enemyDrop = 10.0f;
	
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
		
		if(col.gameObject.tag == "Enemy")
		{
			Destroy(gameObject);
			Destroy(col.gameObject);
			GameObject.Find("GameController").GetComponent<GameController>().Gold += enemyDrop;
		}
		if (col.gameObject.tag == "Projectile")
		{
			Destroy(gameObject);
			Destroy(col.gameObject);
		}
		if (col.gameObject.tag == "Player")
		{
			Destroy(gameObject);
		}
	}
}
