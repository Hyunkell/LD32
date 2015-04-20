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
    public GameObject thumbsSpawnLocation;

    private HashSet<string> happenings = new HashSet<string>();

    public bool hasCharismaAbility = true;
    public bool hasIntimidateAbility = true;
    public bool hasIntelligenceAbility = true;
    public bool hasChatAbility = true;

    public void Say( params string[] text )
    {
        speechBubble.ShowText( text );
    }

    public void ModifyAffinity( float val )
    {
        Debug.Log( "Affinity: " + val.ToString() );
        affinity += val;

        if( val > 0.0f )
        {
            Prefab.CreateInstance( "ThumbsUp", thumbsSpawnLocation.transform.position );
        }
        else if( val < 0.0f )
        {
            Prefab.CreateInstance( "ThumbsDown", thumbsSpawnLocation.transform.position );
            //instance.GetComponent<SpriteRenderer>().sprite = 
        }
    }

    internal bool HasHappend( string key )
    {
        return this.happenings.Contains( key );
    }

    public void Happens( string key )
    {
        this.happenings.Add( key );
    }

    public void Reset()
    {
        happenings.Clear();
        affinity = 0;
    }
}