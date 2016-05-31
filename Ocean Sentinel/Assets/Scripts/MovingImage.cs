using UnityEngine;
using System.Collections;

public class MovingImage : MonoBehaviour {

    [SerializeField]
    private Sprite[] Image;
    [SerializeField]
    private float Speed;
    private float Count = 0;
    private int i = 0;
	
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
