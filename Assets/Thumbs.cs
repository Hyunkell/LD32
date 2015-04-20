using UnityEngine;
using System.Collections;

public class Thumbs : MonoBehaviour
{
    public Sprite forcedSprite;
    void Start()
    {
        Destroy( gameObject, 0.7666666f );
    }

    void Update()
    {
        if( forcedSprite != null )
            GetComponent<SpriteRenderer>().sprite = forcedSprite;
    }
}
