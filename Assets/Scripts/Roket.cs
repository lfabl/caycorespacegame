using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Roket : MonoBehaviour {
	float speed;
	GameObject kamera;
	void Start () {
		kamera = GameObject.Find("Kamera");
		speed = kamera.GetComponent<Global>().globalSpeed;
	}
	void Update () {
		this.transform.Translate(0,5*speed*Time.deltaTime,0);
		if (transform.position.y > 12) {
			Destroy(this.gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D other) {
		switch(other.gameObject.tag) {
			case "engel":
				kamera.GetComponent<Global>().score += 50;
				kamera.GetComponent<Global>().canEklemeSiniri += 50;
				kamera.GetComponent<Global>().updateTexts();
				Destroy(other.gameObject);
				Destroy(this.gameObject);
			break;
			case "yildiz":
				kamera.GetComponent<Global>().score -= 150;
				kamera.GetComponent<Global>().updateTexts();
				Destroy(other.gameObject);
				Destroy(this.gameObject);
			break;
		}
	}
}