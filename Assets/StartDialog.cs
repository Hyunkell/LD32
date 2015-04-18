using UnityEngine;
using System.Collections;

public class StartDialog : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		var gameObject = other.gameObject;
		gameObject.GetComponent<Movement> ().enabled = false;

        var dialogue = GetComponent<Dialogue>();
        dialogue.BeginDialogue();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
