using UnityEngine;
using System.Collections;

public class BaseHPScript : MonoBehaviour {
    //Static variables so that they can be accesed by other classes 
    int startingHP  = 500;
    public int baseCurrentHP;
    
    public GameObject @base;
	// Use this for initialization
	void Start () {
        baseCurrentHP = startingHP;
        @base = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	}

    // Public function thats takes in a int that will be subtracted from the baseCurrentHP variable
    public void TakeDamage(int amount) {
        baseCurrentHP -= amount;
    }

}
