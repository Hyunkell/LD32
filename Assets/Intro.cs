using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Intro : MonoBehaviour {

	public List<Sprite> images;
    public List<float> delaySeconds;
    public AudioClip introSound;

	private int _currentImageIndex = 0;

	public GameObject sceneLoader;

	public void GoToNextImage()
	{
		_currentImageIndex++;

		if (_currentImageIndex >= images.Count) {
			//Go to start screen
			this.sceneLoader.SendMessage("LoadNextScene");
		} else {
			var image = images[_currentImageIndex];
			this.gameObject.GetComponent<Image>().sprite = image;

            // Nächstes Bild starten nach delay
            Invoke("GoToNextImage", delaySeconds[_currentImageIndex]);
		}
	}

	// Use this for initialization
	void Start () {
		if (this.images.Count > 0) {
			var image = images[0];
			this.gameObject.GetComponent<Image>().sprite = image;
            Audio.Play(introSound);
            Invoke("GoToNextImage", delaySeconds[_currentImageIndex]);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
