using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Intro : MonoBehaviour
{
    public AudioClip introSound;
    public SceneSelection sceneSelection;

    void Start()
    {
        Play();
    }

    public void Play()
    {
        Audio.PlaySound( introSound );
        // This resets the intro animation
        GetComponent<Animator>().Play( "PlayIntro", -1, 0.0f );
    }
}
