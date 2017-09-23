using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// used: https://www.sitepoint.com/adding-pause-main-menu-and-game-over-screens-in-unity/
public class MenuUi : MonoBehaviour
{

    // Ui Elements
    GameObject[] shopObjects;
    GameObject[] cashObjects;

    // Buttons
    public Button cashButton;

    // Currency Text
    public Text cashText;
    public Text cashShopText;
    public Text coinText;

    public MenuManager manager;

    // Use this for initialization
    void Start()
    {

        // Declares the pause and shop Objects
        shopObjects = GameObject.FindGameObjectsWithTag("ShowOnShop");
        cashObjects = GameObject.FindGameObjectsWithTag("ShowOnCash");

        // Start settings
        hideShop();
        hideCashShop();

        // Cash Button Listener
        Button cbtn = cashButton.GetComponent<Button>();
        cbtn.onClick.AddListener(OpenCashShop);
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

    // returns to the menu
    public void CloseShop()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    // Opens the Cash Shop
    public void OpenCashShop()
    {
        hideShop();
        showCashShop();
        manager.UpdateCurrency();
    }

    //Closes the Cash Shop
    public void CloseCashShop()
    {
        hideCashShop();
        showShop();
        manager.UpdateCurrency();
    }

    // Updates the Currency Text in the Ui
    public void UpdateCurrencyText(int cash, int coin, int energy)
    {
        cashText.text = cash.ToString();
        coinText.text = coin.ToString();
        cashShopText.text = cash.ToString();
    }
}
