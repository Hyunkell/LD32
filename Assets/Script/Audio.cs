using UnityEngine;
using System.Collections;

public static class Audio
{
    public static void Play( AudioClip clip )
    {
        if( clip != null )
        {
            var audio = Camera.main.GetComponent<AudioSource>();
            audio.PlayOneShot( clip );
        }
    }

    public static void Stop()
    {
        var audio = Camera.main.GetComponent<AudioSource>();
        audio.Stop();
    }
}
