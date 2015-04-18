using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Actor : MonoBehaviour
{
    public new string name;
    public SpeechBubble speechBubble;
    public float affinity;

    public void Say( params string[] text )
    {
        speechBubble.ShowText( text );
    }

    public void ModifyAffinity( float val )
    {
        affinity += val;
    }
}