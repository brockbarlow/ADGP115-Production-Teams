////////////////////////////////////////////////////////////////
//Austin Morrell//
//May 31 2016//
//ADGP-115 Production Teams//
///////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class MovingImage : MonoBehaviour {

    // A list of 2d images in the sprite format.
    [SerializeField]
    private Sprite[] Image;
    // The speed the Images are looped at.
    [SerializeField]
    private float Speed;
    private float Count = 0;
    private int i = 0;
	
    // Loops through all the Images in the Image list at a speed.
	void Update ()
    {
	    if (Count % Speed == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Image[i];
            i++;
            if (i > (Image.Length - 1))
            {
                i = 0;
            }
        }
        Count++;
	}
}
