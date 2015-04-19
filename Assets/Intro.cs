using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Intro : MonoBehaviour {

	public List<Sprite> images;

	private int _currentImageIndex = 0;

	public void GoToNextImage()
	{
		_currentImageIndex++;

		if (_currentImageIndex > images.Count) {
			//TODO Go to start screen
		} else {
			var image = images[_currentImageIndex];
			this.gameObject.GetComponent<Image>().sprite = image;
		}

	}

	// Use this for initialization
	void Start () {
		if (this.images.Count > 0) {
			var image = images[0];
			this.gameObject.GetComponent<Image>().sprite = image;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
