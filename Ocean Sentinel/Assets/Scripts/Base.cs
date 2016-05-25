using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour {

    public float max_HP;
    public float HP;
    public float max_Armor;
    public float Armor;
    public GameController GC;

	void Start () {
        GC = FindObjectOfType<GameController>();
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
}
