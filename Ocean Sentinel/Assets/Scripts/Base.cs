using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour
{

    public float max_HP;
    public float HP;
    public float max_Armor;
    public float Armor;
    public GameController GC;
    //referes to a game audio sorce with a clip in the gameopbject
    AudioSource hitAudio;


    void Start()
    {
        GC = FindObjectOfType<GameController>();
        hitAudio = gameObject.GetComponent<AudioSource>();
        max_HP = 300;
        max_Armor = 200;
        HP = max_HP;
        Armor = max_Armor;
    }

    void Update()
    {
        if (Armor <= 0)
        {
            Armor = 0;
        }

        if (HP <= 0)
        {
            HP = 0;
            GC.GameOver();
        }



    }
    //Looks for in comming collider with sposific tag then does STUFF
    void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.tag == "Projectile")
            hitAudio.Play();
    }
}