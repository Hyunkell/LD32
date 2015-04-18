using UnityEngine;
using System.Collections;

public class SceneSelection : MonoBehaviour {
    public string startScene = "TheKitchen";

	// Use this for initialization
	void Start () 
    {
        LoadScene(startScene);
	}

    private void LoadScene(string sceneName)
    {
        var scene = GameObject.Find(sceneName);
        this.gameObject.transform.position = new Vector3(scene.transform.position.x, scene.transform.position.y, this.gameObject.transform.position.z);
    }
}
