using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UzayGemisi : MonoBehaviour {
	public float speedY;
	public float speedX;
	public GameObject roket;
	public Transform instateLoc;
	public float roketAtmaSuresi;
	bool fireable = false;
	GameObject kamera;
	void Start () {
		roketAtmaSuresi = 0.5f;
		fireable = true;
		kamera = GameObject.Find("Kamera");
	}
	IEnumerator FireableControl(float roketAtmaSuresi) {
		yield return new WaitForSeconds(roketAtmaSuresi);
		fireable = true;
	}
	void Update () {
		speedY = (((20 - this.gameObject.transform.position.y * 4) / 2) + 1);
		this.gameObject.transform.Translate(
			new Vector3(
				Input.GetAxis("Horizontal")*speedX*Time.deltaTime,
				Input.GetAxis("Vertical")*speedY*Time.deltaTime,
				0
			)
		);
		this.gameObject.transform.position = new Vector3(Mathf.Clamp(transform.position.x, -4.5f, 4.5f),Mathf.Clamp(transform.position.y, 0.0f, 4.5f),0);
		if (Input.GetKey(KeyCode.Space) && fireable) {
			Instantiate(roket, new Vector3(instateLoc.transform.position.x, instateLoc.transform.position.y, instateLoc.transform.position.z), Quaternion.identity);
			fireable = false;
			StartCoroutine(FireableControl(roketAtmaSuresi));
		}
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "engel") {
			kamera.GetComponent<Global>().can -= 1;
			kamera.GetComponent<Global>().score -= 250;
			kamera.GetComponent<Global>().canEklemeSiniri = 0;
			kamera.GetComponent<Global>().updateTexts();
			Destroy(other.gameObject);
		}
		if (other.gameObject.tag == "yildiz") {
			kamera.GetComponent<Global>().score += 100;
			kamera.GetComponent<Global>().updateTexts();
			Destroy(other.gameObject);
		}
	}
}