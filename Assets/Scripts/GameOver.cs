using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public LevelManager levelManager;

    private void Start() {
        levelManager = FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Collector") {
            // Zeit speichern
            if (levelManager.highscore > PlayerPrefs.GetFloat("CampusRunnerHighScore" + levelManager.levelName)) {
                PlayerPrefs.SetFloat("CampusRunnerHighScore" + levelManager.levelName, levelManager.highscore);
            }

            // neustarten oder kleines Menü anzeigen
            RestartGame ();
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
        // Kollision mit Gegner
		//if (other.gameObject.tag == "Gegner") {
		//	// Spiel ist zu Ende
		//	RestartGame();
		//}
	}

	void RestartGame() {
		// Spiel ist zu Ende
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}



}
