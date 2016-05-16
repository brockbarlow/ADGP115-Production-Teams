using UnityEngine;
using System.Collections;

public class ProjectileDespawn : MonoBehaviour {

	float projectileTime;
	
	// Update is called once per frame
	void Update ()
	{
		projectileTime += Time.deltaTime;
		if(projectileTime >= 3.0f)
		{
			Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Enemy")
		{
			Destroy(gameObject);
			Destroy(col.gameObject);
		}
	}
}
