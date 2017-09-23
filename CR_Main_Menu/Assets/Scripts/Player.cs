using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public Text bookText;
    private int bookCounter = 0;

	// Use this for initialization
	void Start () {
        // lade bookCounter
        bookCounter = PlayerPrefs.GetInt("CampusRunnerItemCount");
        bookText.text = "Score: " + bookCounter.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Book") {
            bookCounter++;
            // Destroy(other.gameObject);
            other.gameObject.SetActive(false);

            bookText.text = "Score: " + bookCounter.ToString();

            // Anzahl speichern
            PlayerPrefs.SetInt("CampusRunnerItemCount", bookCounter);
        }
    }
}
