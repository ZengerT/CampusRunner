using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// used: https://www.sitepoint.com/adding-pause-main-menu-and-game-over-screens-in-unity/
public class UiManager : MonoBehaviour {

    // Ui Elements
    GameObject[] pauseObjects;
    GameObject[] shopObjects;
    GameObject[] cashObjects;
    GameObject[] pauseHiddenObjects;
    GameObject[] books;

    // Buttons
    public Button pauseButton;
    public Button cashButton;

    // Currency Text
    public Text cashText;
    public Text cashShopText;
    public Text coinText;
    public Text coinScoreText;

    public GameManager manager;

	// Use this for initialization
	void Start () {

          
        // Declares the pause and shop Objects
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        shopObjects = GameObject.FindGameObjectsWithTag("ShowOnShop");
        cashObjects = GameObject.FindGameObjectsWithTag("ShowOnCash");
        pauseHiddenObjects = GameObject.FindGameObjectsWithTag("HideOnPause");
        books = GameObject.FindGameObjectsWithTag("Book");

        // Start settings
        hidePause();
        hideShop();
        hideCashShop();
        Time.timeScale = 1;

        // Pause Button Click Listener
        Button btn = pauseButton.GetComponent<Button>();
        btn.onClick.AddListener(PauseOnClick);

        // Cash Button Listener
        Button cbtn = cashButton.GetComponent<Button>();
        cbtn.onClick.AddListener(OpenCashShop);
    }
    void Awake()
    {
        FindObjectOfType(typeof(Text));
    }
    // Shows the Pause Menu
    void showPause()
    {
        foreach(GameObject element in pauseObjects)
        {
            element.SetActive(true);
        }
        foreach(GameObject element in pauseHiddenObjects)
        {
            element.SetActive(false);
        }
        foreach (GameObject element in books)
        {
            element.SetActive(false);
        }
    }

    // Hides the Pause Menu
    void hidePause()
    {
        foreach (GameObject element in pauseObjects)
        {
            element.SetActive(false);
        }
    }

    // Shows the shop
    void showShop()
    {
        foreach (GameObject element in shopObjects)
        {
            element.SetActive(true);
        }
    }

    // Hides the shop
    void hideShop()
    {
        foreach (GameObject element in shopObjects)
        {
            element.SetActive(false);
        }
    }

    // Shows the Cash shop
    void showCashShop()
    {
        foreach (GameObject element in cashObjects)
        {
            element.SetActive(true);
        }
    }

    // Hides the Cash SHop
    void hideCashShop()
    {
        foreach (GameObject element in cashObjects)
        {
            element.SetActive(false);
        }
    }

    // Game gets paused and Pause Menu gets shown
    void PauseOnClick()
    {
        showPause();
        Time.timeScale = 0;

        // Hides the Pause Button
        pauseButton.gameObject.SetActive(false);
    }

    // Continues the Game and hides the Pause Menu
    public void Continue()
    {
        Time.timeScale = 1;
        hidePause();

        // Sets the Deactivated GameObjects back to Active
        foreach (GameObject element in pauseHiddenObjects)
        {
            element.SetActive(true);
        }

        // Shows the Pause Button
        pauseButton.gameObject.SetActive(true);
    }


    // Opens the Shop and Closes the Pause Menu
    public void OpenShop()
    {
        showShop();
        hidePause();
    }

    // Closes the Shop and Opens the Pause Menu
    public void CloseShop()
    {
        showPause();
        hideShop();
    }

    // Opens the Cash Shop
    public void OpenCashShop()
    {
        hideShop();
        showCashShop();
    }

    //Closes the Cash Shop
    public void CloseCashShop()
    {
        hideCashShop();
        showShop();
    }

    // Updates the Currency Text in the Ui
    public void UpdateCurrencyText(int cash, int coin, int energy)
    {

        cashText.text = cash.ToString();
        coinText.text = coin.ToString();
        cashShopText.text = cash.ToString();
        coinScoreText.text = coin.ToString();

    }

}
