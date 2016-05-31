///////////////
//Created by Eugene Hochenedel
//
//////////////
using UnityEngine;
using System.Collections;

public class SpawnMoverVertical : MonoBehaviour
{
	private bool up, down = false; //if the spawn points can move or not

	// Use this for initialization
	void Start()
	{

	}

	void Lerp(float a, float b, float c)
	{
		gameObject.transform.position = new Vector3(transform.position.x + a, transform.position.y + b, transform.position.z + c);
	}

	// Update is called once per frame
	void Update()
	{
		if (up == true)
		{
			Lerp(0, 0, 0.4f);
		}

		if (down == true)
		{
			Lerp(0, 0, -0.4f);
		}

		if (gameObject.transform.localPosition.z <= -10)
		{
			up = true;
			down = false;
			Debug.Log("Up");
		}

		if (gameObject.transform.localPosition.z >= 35)
		{
			up = false;
			down = true;
			Debug.Log("Down");
		}
	}
}
