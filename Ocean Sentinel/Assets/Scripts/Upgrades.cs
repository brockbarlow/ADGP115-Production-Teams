////////////////////////////////////////////////////////////////
//Austin Morrell//
//May 31 2016//
//ADGP-115 Production Teams//
///////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Upgrades : MonoBehaviour {

    [SerializeField]
    private EventSystem ES;
    // The game controller.
    [SerializeField]
    private GameObject GC;
    // The base.
    [SerializeField]
    private GameObject TheBase;
    // The Player.
    [SerializeField]
    private GameObject PM;
    [SerializeField]
    private GameObject costText;
    private float cost1, cost2, cost3, cost4;
    private float a, b, c, d;
    public bool Doit;
    public bool Active;

    // This is used for initialization.
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
        ES = FindObjectOfType<EventSystem>();
    }

    void Update()
    {
        // Resets the cost to the original cost.
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

    // Gives HP back to the base.
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
            GetComponent<AudioSource>().Play();
        }
    }

    // Gives Armor back to the base.
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
            GetComponent<AudioSource>().Play();
        }
    }

    // Increase the player's movement speed.
    public void Speed()
    {
        if (GC.GetComponent<GameController>().Gold >= c)
        {
            PM.GetComponent<PlayerMovement>().MoveVelocity += .5f;
            GC.GetComponent<GameController>().Gold -= c;
            c *= 2;
            GetComponent<AudioSource>().Play();
        }
    }

    // Increases the player's rate of fire.
    public void Rate()
    {
        if (GC.GetComponent<GameController>().Gold >= d)
        {
            PM.GetComponent<PlayerMovement>().projectileRate -= .2f;
            GC.GetComponent<GameController>().Gold -= d;
            d *= 2;
            GetComponent<AudioSource>().Play();
        }
    }

    // Proceeds to the next wave.
    public void None()
    {
        GetComponent<AudioSource>().Play();
        GC.GetComponent<GameController>().spawnWave = true;
        GC.GetComponent<GameController>().StartCoroutine(GC.GetComponent<GameController>().SpawnWaves());
        GC.GetComponent<GameController>().Doit = true;
        costText.SetActive(false);
        ES.SetSelectedGameObject(null);
        Doit = true;
    }
}
