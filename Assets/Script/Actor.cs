using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Actor : MonoBehaviour
{
    public new string name;
    public SpeechBubble speechBubble;
    [Range( -50, 50 )]
    public float affinity;

    private HashSet<string> happenings = new HashSet<string>();

    public void Say( params string[] text )
    {
        speechBubble.ShowText( text );
    }

    public void ModifyAffinity( float val )
    {
        affinity += val;
    }

    internal bool HasHappend(string key)
    {
        return this.happenings.Contains(key);
    }

    public void Happens(string key)
    {
        this.happenings.Add(key);
    }
}