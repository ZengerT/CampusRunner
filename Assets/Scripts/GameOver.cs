using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class GameOver : MonoBehaviour {

    public LevelManager levelManager;

    UiManager uiManager;

    private void Start() {
        levelManager = FindObjectOfType<LevelManager>();
        uiManager = FindObjectOfType<UiManager>();
    }

    void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Collector") {
			// Zeit anhalten
			Time.timeScale = 0;

            // Zeit speichern
            if (levelManager.highscore > PlayerPrefs.GetFloat("CampusRunnerHighScore" + levelManager.levelName)) {
                PlayerPrefs.SetFloat("CampusRunnerHighScore" + levelManager.levelName, levelManager.highscore);
            }

			// Submit leaderboard scores, if authenticated
			if (PlayGamesPlatform.Instance.localUser.authenticated) {
				Debug.Log ("(CampusRunner) Submit score, user authenticated");
				string lbLvlName = GPGSIds.leaderboard_highscore_level_1;

				// Level-Auswahl
				switch (levelManager.levelName) {
				case "FirstLevel":
					lbLvlName = GPGSIds.leaderboard_highscore_level_1;
					break;
				case "SecondLevel":
					lbLvlName = GPGSIds.leaderboard_highscore_level_2;
					break;
				case "ThirdLevel":
					lbLvlName = GPGSIds.leaderboard_highscore_level_3;
					break;
				case "FourthLevel":
					lbLvlName = GPGSIds.leaderboard_highscore_level_4;
					break;
				case "FifthLevel":
					lbLvlName = GPGSIds.leaderboard_highscore_level_5;
					break;
				}

					PlayGamesPlatform.Instance.ReportScore ((long)levelManager.highscore, 
						lbLvlName,
						(bool success) => {
							Debug.Log ("(CampusRunner) Leaderboard update success: " + success);
						});
			}

            // kleines Menü anzeigen
			showGameOverMenu();
		}
	}

	void showGameOverMenu() {
        // Spiel ist zu Ende
        // Zeit anhalten
        Time.timeScale = 0;

        // GameOver-Anzeige anzeigen
        uiManager.showFinished(levelManager.highscore);
	}



}
