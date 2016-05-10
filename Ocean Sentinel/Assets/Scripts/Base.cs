using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour {

    public float HP;
    public GameController GC;

	void Start () {
        GC = FindObjectOfType<GameController>();
        HP = 500;
	}

    void Update()
    {
        if (HP <= 0)
        {
            GC.GameOver();
        }
    }
}
