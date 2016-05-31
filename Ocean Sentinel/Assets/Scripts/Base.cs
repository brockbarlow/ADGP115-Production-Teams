////////////////////////////////////////////////////////////////
//Austin Morrell//
//May 31 2016//
//ADGP-115 Production Teams//
///////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour {

    // The max amount of HP the base can have.
    public float max_HP;
    // The amount of HP the base has.
    public float HP;
    // The max amount of Armor the base can have.
    public float max_Armor;
    // The amount of armor the base has.
    public float Armor;
    // The GameController.
    public GameController GC;

    // This is used for initialization.
    void Start () {
        GC = FindObjectOfType<GameController>();
        max_HP = 300;
        max_Armor = 200;
        HP = max_HP;
        Armor = max_Armor;
	}

    // Is called every frame.
    void Update()
    {
        // Makes sure armor can never be negative.
        if (Armor <= 0)
        {
            Armor = 0;
        }

        // If the base has no HP left you lose.
        if (HP <= 0)
        {
            HP = 0;
            GC.GameOver();
        }
    }
}
