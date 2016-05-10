using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "(Clone)")
        {
            FindObjectOfType<GameController>().Gold += 5;
            Destroy(gameObject);
        }
    }
}
