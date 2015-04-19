using UnityEngine;
using System.Collections;

public class HBMStandUp : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        var gameObject = other.gameObject;
        gameObject.GetComponentInChildren<Animator>().Play("RollChair");
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
