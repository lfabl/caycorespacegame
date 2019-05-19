using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngelOlusturucu : MonoBehaviour {
	public GameObject[] engeller;
	public float olusturmaSuresi;
	void Start () {
		StartCoroutine(EngelOlustur(olusturmaSuresi));
	}
	IEnumerator EngelOlustur(float sure) {
		int randomEngelSecici = Random.Range(0,engeller.Length);
		Instantiate(engeller[randomEngelSecici], new Vector3(Random.Range(-4.5f,4.5f),11,0), Quaternion.identity);
		yield return new WaitForSeconds(sure);
		StartCoroutine(EngelOlustur(olusturmaSuresi));
	}
}
