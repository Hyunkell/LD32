using UnityEngine;
using System.Collections;

public class SceneSelection : MonoBehaviour {

	public GameObject character;

    private string[] scenes = new string[] { "TitleScreen","TheFathersOffice", "TheKitchen", "TheChefOffice", "EmptyTestScene" };
    private int sceneIndex = 0;

	// Use this for initialization
	void Start () 
    {
        LoadCurrentScene();
	}

    private void LoadCurrentScene()
    {
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
        this.gameObject.transform.position = new Vector3(scene.transform.position.x, scene.transform.position.y, this.gameObject.transform.position.z);
		var spriteRenderers = scene.GetComponentsInChildren<SpriteRenderer> ();
		foreach (var renderer in spriteRenderers) {
			if(renderer.gameObject.name == "SpawnPoint"){
				character.transform.position = renderer.gameObject.transform.position;
                character.GetComponent<Movement>().enabled = true;
                character.GetComponentInChildren<SpeechBubble>().Hide();
				return;
			}
		}
    }

	public void QuitApp()
	{
		Application.Quit ();
	}
}
