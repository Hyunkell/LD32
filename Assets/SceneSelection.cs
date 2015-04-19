using UnityEngine;
using System.Collections;
using System;

public class SceneSelection : MonoBehaviour {

	public GameObject character;

    private string[] scenes = new string[] { "Intro", "TitleScreen", "TheFathersOffice", "TheKitchen", "TheChefOffice", "EmptyTestScene" };
    public GameObject gameOverScene;
    private int sceneIndex = 0;

	// Use this for initialization
	void Start () 
    {
        LoadCurrentScene();
	}

    public void ResetGame()
    {
        Debug.LogWarning( "TODO: Define game over screen" );
        Application.LoadLevel( Application.loadedLevel );
    }

    public void LoadCurrentScene()
    {
        Audio.Stop();

        if (sceneIndex >= 0 && sceneIndex < scenes.Length)
        {
            LoadScene(scenes[sceneIndex]);
        }
    }


    public void LoadNextScene()
    {
        this.sceneIndex++;
        LoadCurrentScene();
    }

    public void LoadPrevScene()
    {
        this.sceneIndex--;
        LoadCurrentScene();
    }

    private void LoadScene(string sceneName)
    {
        var scene = GameObject.Find(sceneName);

        //Dirty but works
        if (sceneName == "TheChefOffice")
        {
            var animator = scene.GetComponentInChildren<Animator>();
            animator.SetBool("standUp", true);
            animator.Play("Sitting");
        }

        LoadScene(scene);
    }

    private void LoadScene(GameObject scene)
    {
        this.gameObject.transform.position = new Vector3(scene.transform.position.x, scene.transform.position.y, this.gameObject.transform.position.z);
		var spriteRenderers = scene.GetComponentsInChildren<SpriteRenderer> ();
		foreach (var renderer in spriteRenderers) {
			if(renderer.gameObject.name == "SpawnPoint"){
				character.transform.position = renderer.gameObject.transform.position;
                character.GetComponent<Movement>().enabled = true;
                //character.GetComponentInChildren<SpeechBubble>().Hide();
				var speechbubbles = scene.GetComponentsInChildren<SpeechBubble>();

				foreach(var bubble in speechbubbles)
				{
					bubble.Hide();
				}
				return;
			}
		}
    }

	public void QuitApp()
	{
		Application.Quit ();
	}

    public void LoadGameOverPage()
    {
        this.LoadScene(gameOverScene);
    }
}
