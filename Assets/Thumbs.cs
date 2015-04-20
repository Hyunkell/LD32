using UnityEngine;
using System.Collections;

public class Thumbs : MonoBehaviour
{
    public Sprite forcedSprite;
    void Start()
    {
        if( forcedSprite != null )
            GetComponent<SpriteRenderer>().sprite = forcedSprite;

        Destroy( gameObject, 0.7666666f );
    }
}
