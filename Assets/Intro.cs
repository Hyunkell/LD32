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
    }
}
