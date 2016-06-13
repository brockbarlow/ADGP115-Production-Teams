////////////////////////////////////////////////////////////////
//Austin Morrell//
//May 31 2016//
//ADGP-115 Production Teams//
///////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

    void Start()
    {
        // Wait for half a second.....Kill myself
        Destroy(gameObject, 2f);
    }
}
