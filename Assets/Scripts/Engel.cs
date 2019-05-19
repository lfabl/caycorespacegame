using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engel : MonoBehaviour {
	float speed;
	GameObject kamera;
	public float rotationSpeed;
	void Start() {
		kamera = GameObject.Find("Kamera");
		speed = kamera.GetComponent<Global>().globalSpeed;
	}
	void Update () {
		transform.Translate(0,-1*speed*Time.deltaTime,0, Space.World);
		transform.Rotate(0,0,rotationSpeed * Time.deltaTime);
		if(transform.position.y < -4) {
			kamera.GetComponent<Global>().score -= 50;
			kamera.GetComponent<Global>().updateTexts();
			Destroy(this.gameObject);
		}
	}
}