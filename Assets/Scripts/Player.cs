using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public GameManager manager;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Book") {
            manager.AddCoins(1);

            // Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            manager.UpdateCurrency();
        }
    }
}
