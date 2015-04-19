using UnityEngine;
using System.Collections;

public class HBMStartMovement : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		var animator = this.gameObject.GetComponentInChildren<Animator> ();
		animator.SetBool ("standUp", true);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
