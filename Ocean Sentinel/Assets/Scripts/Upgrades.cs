using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour {

    [SerializeField]
    private GameObject GC;
    [SerializeField]
    private GameObject TheBase;
    [SerializeField]
    private GameObject PM;
    [SerializeField]
    private GameObject costText;
    private float cost1, cost2, cost3, cost4;
    private float a, b, c, d;
    public bool Doit;
    public bool Active;
	
    void Start()
    {
        cost1 = 30;
        cost2 = 30;
        cost3 = 15;
        cost4 = 15;
        a = cost1;
        b = cost2;
        c = cost3;
        d = cost4;
        Doit = true;
        costText.SetActive(false);
        Active = false;
    }

    void Update()
    {
        if (Active && Doit)
        {
            a = cost1;
            b = cost2;
            c = cost3;
            d = cost4;
            Doit = false;
            costText.SetActive(true);
        }
        costText.GetComponent<Text>().text =  "Cost: " + a + "     Cost: " + b + "     Cost: " + c + "     Cost: " + d;
    }

	public void Repair()
    {
        if ((GC.GetComponent<GameController>().Gold >= a) && (TheBase.GetComponent<Base>().HP < TheBase.GetComponent<Base>().max_HP))
        {
            TheBase.GetComponent<Base>().HP += 200;
            if (TheBase.GetComponent<Base>().HP > TheBase.GetComponent<Base>().max_HP)
            {
                TheBase.GetComponent<Base>().HP = TheBase.GetComponent<Base>().max_HP;
            }
            GC.GetComponent<GameController>().Gold -= a;
            a *= 2;
        }
    }

    public void Armor()
    {
        if ((GC.GetComponent<GameController>().Gold >= b) && (TheBase.GetComponent<Base>().Armor < TheBase.GetComponent<Base>().max_Armor))
        {
            TheBase.GetComponent<Base>().Armor += 150;
            if (TheBase.GetComponent<Base>().Armor > TheBase.GetComponent<Base>().max_Armor)
            {
                TheBase.GetComponent<Base>().Armor = TheBase.GetComponent<Base>().max_Armor;
            }
            GC.GetComponent<GameController>().Gold -= b;
            b *= 2;
        }
    }

    public void Speed()
    {
        if (GC.GetComponent<GameController>().Gold >= c)
        {
            PM.GetComponent<PlayerMovement>().MoveVelocity += 2;
            GC.GetComponent<GameController>().Gold -= c;
            c *= 2;
        }
    }

    public void Rate()
    {
        if (GC.GetComponent<GameController>().Gold >= d)
        {
            PM.GetComponent<PlayerMovement>().projectileRate -= .2f;
            GC.GetComponent<GameController>().Gold -= d;
            d *= 2;
        }
    }

    public void None()
    {
        GC.GetComponent<GameController>().spawnWave = true;
        GC.GetComponent<GameController>().StartCoroutine(GC.GetComponent<GameController>().SpawnWaves());
        GC.GetComponent<GameController>().Doit = true;
        costText.SetActive(false);
        Doit = true;
    }
}
