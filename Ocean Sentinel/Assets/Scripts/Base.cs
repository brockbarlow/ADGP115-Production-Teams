using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour {

    public float max_HP;
    public float HP;
    public GameController GC;

	void Start () {
        GC = FindObjectOfType<GameController>();
        max_HP = 500;
        HP = max_HP;
	}

    void Update()
    {
        if (HP <= 0)
        {
            GC.GameOver();
        }
    }
}
