using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCashShopScript : MonoBehaviour {

    /*				//
    //  Variables	//
    */              //

    // Cash Buttons
    public Button cashButton;
    public Button cashBundleButton;
    public Button cashSafeButton;

    // Back Button
    public Button backButton;

    // Texts
    public Text cashValueText;
    public Text cashPriceText;

    public Text cashBundleValueText;
    public Text cashBundlePriceText;

    public Text cashSafeValueText;
    public Text cashSafePriceText;

    public MenuManager manager;
    public MenuUi ui;
	public MenuPurchaser purchaser;

    /*				//
    //  Constants	//
    */              //

    // Cash Shop Prices
    const double CASH_PRICE = 0.99;
    const double CASH_BUNDLE_PRICE = 2.99;
    const double CASH_SAFE_PRICE = 15.99;

    const int CASH_RATE = 8;
    const int CASH_BUNDLE_RATE = 43;
    const int CASH_SAFE_RATE = 233;

    // Use this for initialization
    void Start()
    {

        // Back Button
        Button btn = backButton.GetComponent<Button>();
        btn.onClick.AddListener(BackOnClick);

        // Cash Buy Buttons
        Button cashb = cashButton.GetComponent<Button>();
        Button cashbb = cashBundleButton.GetComponent<Button>();
        Button cashsb = cashSafeButton.GetComponent<Button>();

		cashb.onClick.AddListener(BuyCash);
		cashbb.onClick.AddListener(BuyCashBundle);
		cashsb.onClick.AddListener(BuyCashSafe);

        // Inserts the Prices and Values into the Ui
        cashPriceText.text = CASH_PRICE.ToString() + "€";
        cashValueText.text = CASH_RATE.ToString() + " Cash";
        cashBundlePriceText.text = CASH_BUNDLE_PRICE.ToString() + "€";
        cashBundleValueText.text = CASH_BUNDLE_RATE.ToString() + " Cash";
        cashSafePriceText.text = CASH_SAFE_PRICE.ToString() + "€";
        cashSafeValueText.text = CASH_SAFE_RATE.ToString() + " Cash";
    }

    // User clicks on a Cash Button
    public void BuyCash()
    {
        purchaser.BuyCash();
        // checks if purchase was successfull
        if (MenuPurchaser.purchaseSuccess)
        {

            manager.AddCash(CASH_RATE);
            manager.UpdateCurrency();
            MenuPurchaser.purchaseSuccess = false;
        }
    }

    public void BuyCashBundle()
    {
        purchaser.BuyCashBundle();
        // checks if purchase was successfull
        if (MenuPurchaser.purchaseSuccess)
        {
            manager.AddCash(CASH_BUNDLE_RATE);
            manager.UpdateCurrency();
            MenuPurchaser.purchaseSuccess = false;
        }
    }

    public void BuyCashSafe()
    {
        purchaser.BuyCashSafe();
        // checks if purchase was successfull
        if (MenuPurchaser.purchaseSuccess)
        {
            manager.AddCash(CASH_SAFE_RATE);
            manager.UpdateCurrency();
            MenuPurchaser.purchaseSuccess = false;
        }
    }

    // Closes the Shop Ui
    void BackOnClick()
    {
        ui.CloseCashShop();
    }
}
