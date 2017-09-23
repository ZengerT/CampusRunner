using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCoinShopScript : MonoBehaviour {

    /*				//
    //  Variables	//
    */              //

    // Buy Buttons
    public Button coinButton;
    public Button energyButton;
    //Button 3. item

    // Back Button
    public Button backButton;

    // Texts
    public Text coinValueText;
    public Text coinPriceText;
    public Text energyValueText;
    public Text energyPriceText;
    // Text 3. item

    public MenuManager manager;
    public MenuUi ui;

    /*				//
    //  Constants	//
    */              //

    // Price of the Products
    const int COIN_PRICE = 5;
    const int ENERGY_PRICE = 50;

    // Value of the Products
    const int CASH_TO_COIN_RATE = 125;
    const int COIN_TO_ENERGY_RATE = 1;

    // Use this for initialization
    void Start () {

        // Back Button
        Button btn = backButton.GetComponent<Button>();
        btn.onClick.AddListener(BackOnClick);

        // Coin Buy Button
        Button cbtn = coinButton.GetComponent<Button>();
        cbtn.onClick.AddListener(CoinOnClick);

        // Energy Buy Button
        Button ebtn = energyButton.GetComponent<Button>();
        ebtn.onClick.AddListener(EnergyOnClick);

        // Inserts the Prices and Values into the Ui
        coinValueText.text = CASH_TO_COIN_RATE.ToString() + " Coins";
        coinPriceText.text = COIN_PRICE.ToString();

        energyValueText.text = COIN_TO_ENERGY_RATE.ToString() + " Energy";
        energyPriceText.text = ENERGY_PRICE.ToString();
    }
	
    // User clicks Coin Buy Button
    void CoinOnClick(){

        // Checks if the User has enough Cash
        if (manager.CheckCash(COIN_PRICE))
        {
            // Removes the Cash from the User and adds the Coins
            manager.AddCoins(CASH_TO_COIN_RATE);
            manager.RemoveCash(COIN_PRICE);
        }

        // Last the Currency gets Updated
        manager.UpdateCurrency();
    }

    // User clicks Energy Buy Button
    void EnergyOnClick(){

        // Checks if User has enough Coins
        if (manager.CheckCoins(ENERGY_PRICE))
        {
            // Removes the Coins from the User and adds the Energys
            manager.RemoveCoins(ENERGY_PRICE);
            manager.AddEnergy(COIN_TO_ENERGY_RATE);
        }

        //Last the Currency gets Updated
        manager.UpdateCurrency();
    }

    // Closes the Shop Ui
    void BackOnClick()
    {
        ui.CloseShop();
    }
}
