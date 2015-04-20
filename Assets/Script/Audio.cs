using UnityEngine;
using System.Collections;

public static class Audio
{
    public static void PlaySound( AudioClip clip )
    {
        if( clip != null )
        {
            var audio = Camera.main.GetComponent<AudioSource>();
            audio.Stop();
            audio.PlayOneShot( clip );
        }
        else
            Debug.LogWarning( "Audio.PlaySound(null)" );
    }

    public static void StopSound()
    {
        var audio = Camera.main.GetComponent<AudioSource>();
        audio.Stop();
    }

    public static void EnableBGM()
    {
        Camera.main.transform.FindChild( "BGM" ).gameObject.SetActive( true );
    }

    public static void DisableBGM()
    {
        Camera.main.transform.FindChild( "BGM" ).gameObject.SetActive( false );
    }
}
