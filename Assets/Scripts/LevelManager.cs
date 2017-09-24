using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    // Levelbezeichnung
    public String levelName;

    // Timer
    public Text timerText;
    public float roundTimer;

    // Highscore
    public Text highscoreText;
    public float highscore;

	// Use this for initialization
	void Start () {
        highscore = PlayerPrefs.GetFloat("CampusRunnerHighScore" + levelName);
        highscoreText.text = "Highscore: " + highscore.ToString("0.000");
	}
	
	// Update is called once per frame
	void Update () {
        // Timer aktualisieren
        roundTimer += Time.deltaTime;
        timerText.text = roundTimer.ToString();

        // Highscore aktualisieren
        if (roundTimer > highscore) {
            highscoreText.text = "Highscore: " + roundTimer.ToString("0.000");
            highscore = roundTimer;
        }
    }
}