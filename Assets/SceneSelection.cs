using UnityEngine;
using System.Collections;

public class SceneSelection : MonoBehaviour {

    public string mainCharacter = "GameObject";

	private GameObject _character;

    private string[] scenes = new string[] {"TheKitchen", "TheOffice" };
    private int sceneIndex = 0;

	// Use this for initialization
	void Start () 
    {
		LoadCharacter (mainCharacter);
        LoadCurrentScene();
	}

    private void LoadCurrentScene()
    {
        LoadScene(scenes[sceneIndex]);
    }

	private void LoadCharacter(string characterName)
	{
		var character = GameObject.Find(characterName);
		this._character = character;
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
				_character.transform.position = renderer.gameObject.transform.position;
				_character.GetComponentInChildren<SpriteRenderer>().sortingOrder = renderer.sortingOrder;
				return;
			}
		}
    }
}
