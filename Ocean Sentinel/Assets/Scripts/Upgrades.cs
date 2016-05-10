using UnityEngine;
using System.Collections;

public class Upgrades : MonoBehaviour {

    [SerializeField]
    private GameObject TheBase;
    [SerializeField]
    private GameObject PM;
	
	void Repair()
    {
        TheBase.GetComponent<Base>().HP += 200;
        if (TheBase.GetComponent<Base>().HP > TheBase.GetComponent<Base>().max_HP)
        {
            TheBase.GetComponent<Base>().HP = TheBase.GetComponent<Base>().max_HP;
        }
    }

    void Armor()
    {

    }

    void Speed()
    {
        PM.GetComponent<PlayerMovement>().MoveVelocity += 5;
    }

    void Rate()
    {

    }
}
