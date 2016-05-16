using UnityEngine;
using System.Collections;

public class Upgrades : MonoBehaviour {

    [SerializeField]
    private GameObject GC;
    [SerializeField]
    private GameObject TheBase;
    [SerializeField]
    private GameObject PM;
	
	public void Repair()
    {
        if (GC.GetComponent<GameController>().Gold >= 30)
        {
            TheBase.GetComponent<Base>().HP += 200;
            if (TheBase.GetComponent<Base>().HP > TheBase.GetComponent<Base>().max_HP)
            {
                TheBase.GetComponent<Base>().HP = TheBase.GetComponent<Base>().max_HP;
            }
            GC.GetComponent<GameController>().Gold -= 30;
        }
    }

    public void Armor()
    {
        if (GC.GetComponent<GameController>().Gold >= 30)
        {
            TheBase.GetComponent<Base>().Armor += 150;
            if (TheBase.GetComponent<Base>().Armor > TheBase.GetComponent<Base>().max_Armor)
            {
                TheBase.GetComponent<Base>().Armor = TheBase.GetComponent<Base>().max_Armor;
            }
            GC.GetComponent<GameController>().Gold -= 30;
        }
    }

    public void Speed()
    {
        if (GC.GetComponent<GameController>().Gold >= 15)
        {
            PM.GetComponent<PlayerMovement>().MoveVelocity += 2;
            GC.GetComponent<GameController>().Gold -= 15;
        }
    }

    public void Rate()
    {

    }

    public void None()
    {
        GC.GetComponent<GameController>().spawnWave = true;
        GC.GetComponent<GameController>().StartCoroutine(GC.GetComponent<GameController>().SpawnWaves());
    }
}
