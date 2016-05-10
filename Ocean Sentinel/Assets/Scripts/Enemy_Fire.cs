using UnityEngine;
using System.Collections;

public class Enemy_Fire : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Base")
        {
            other.gameObject.GetComponent<Base>().HP -= 25;
        }
    }
}
