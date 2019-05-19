using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Global : MonoBehaviour {
	public float globalSpeed = 1.0f;
	public int can = 3;
	public int score = 0;
	public Text canText;
	public Text scoreText;
	public int canEklemeSiniri;
	public Text gameOverText;
	public Button gameOverButton;

	void Start() {
		Time.timeScale = 1;
		updateTexts();
	}

	void Update() {
		if(canEklemeSiniri >= 2000) {
			can += 1;
			canEklemeSiniri = 0;
		}
		if(can < 1) {
			gameOverText.gameObject.SetActive(true);
			gameOverButton.gameObject.SetActive(true);
			Time.timeScale = 0;
		}
		globalSpeed = 5.0f + (score / 2000);
		if(Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}

	public void restartGame() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void updateTexts () {
		canText.text = "Can : " + can;
		scoreText.text = "Skor : " + score;
	}
}