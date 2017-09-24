using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

    // Declaration of all 4 Menu Buttons
    public Button continueButton;
    public Button retryButton;
    public Button shopButton;
    public Button closeButton;

    public UiManager ui;

	// Use this for initialization
	void Start () {
        // Continue Button
        Button cbtn = continueButton.GetComponent<Button>();
        cbtn.onClick.AddListener(ContinueOnClick);

        // Retry Button
        Button rbtn = retryButton.GetComponent<Button>();
        rbtn.onClick.AddListener(RetryOnClick);

        // Shop Button
        Button sbtn = shopButton.GetComponent<Button>();
        sbtn.onClick.AddListener(ShopOnClick);

        // Close Button
        Button clbtn = closeButton.GetComponent<Button>();
        clbtn.onClick.AddListener(CloseOnClick);
    }
	
    // Continue Button Function
    void ContinueOnClick()
    {
        // Closes the Pause Menu and returns to the Game
        ui.Continue();
    }

    // Retry Button Function
    void RetryOnClick()
    {
        // Reloads the GameScene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Shop Button Function
    void ShopOnClick()
    {
        // Makes the Shop Visible
        ui.OpenShop();
    }

    // Close Button Function
    void CloseOnClick()
    {
        // Loads the Meain Menu Scene
        SceneManager.LoadScene("Main_Menu");
    }
}
