#pragma strict
import UnityEngine.UI;

public class ShopScript extends MonoBehaviour {

	/*				//
	//  Variables	//
	*/				//

	public var coinButton : Button;
	public var energyButton : Button;
	public var manager : GameManager;
	public var ui : UiScript;

	// Cash Buttons
	public var cashButton : Button;
	public var cashBundleButton : Button;
	public var cashSafeButton : Button;

	// Back Button
	public var backButton : Button;
	public var cashBackButton : Button;

	// Coin Texts
	public var coinValueText : Text;
	public var coinPriceText : Text;

	// Energy Texts
	public var energyValueText : Text;
	public var energyPriceText : Text;

	// Cash Texts
	public var cashPriceText : Text;
	public var cashValueText : Text;

	public var cashBundlePriceText : Text;
	public var cashBundleValueText : Text;

	public var cashSafePriceText : Text;
	public var cashSafeValueText : Text;

	/*											//
	//   Constants (Unity has no const for js)	//
	*/											//

	// Price of the Products
	var COIN_PRICE = 5;
	var ENERGY_PRICE = 50;

	// Value of the Products
	var CASH_TO_COIN_RATE = 125;
	var COIN_TO_ENERGY_RATE = 1;

	// Cash Shop
	var CASH_PRICE = 0.99;
	var CASH_BUNDLE_PRICE = 2.99;
	var CASH_SAFE_PRICE = 15.99;

	var CASH_RATE = 80;
	var CASH_BUNDLE_RATE = 223;
	var CASH_SAFE_RATE = 135;

	function Start() {
		// Back Button
		var btn : Button = backButton.GetComponent.<Button>();
		btn.onClick.AddListener(BackOnClick);

		var cbbtn : Button = cashBackButton.GetComponent.<Button>();
		cbbtn.onClick.AddListener(ShopOnClick);

		// Coin Buy Button
		var cbtn : Button = coinButton.GetComponent.<Button>();
		cbtn.onClick.AddListener(CoinOnClick);

		// Energy Buy Button
		var ebtn : Button = energyButton.GetComponent.<Button>();
		ebtn.onClick.AddListener(EnergyOnClick);

		// Cash Buy Buttons
		var cashb : Button = cashButton.GetComponent.<Button>();
		var cashbb : Button = cashBundleButton.GetComponent.<Button>();
		var cashsb : Button = cashSafeButton.GetComponent.<Button>();

		cashb.onClick.AddListener(BuyCashOnClick);
		cashbb.onClick.AddListener(BuyCashBundleOnClick);
		cashsb.onClick.AddListener(BuyCashSafeOnClick);


		// Inserts the Prices and Values into the Ui
		coinValueText.text =  CASH_TO_COIN_RATE.ToString() + " Coins";
		coinPriceText.text = COIN_PRICE.ToString();

		energyValueText.text = COIN_TO_ENERGY_RATE.ToString() + " Energy";
		energyPriceText.text = ENERGY_PRICE.ToString();

		// Inserts the Cash Prices and Values into the Ui
		cashPriceText.text = CASH_PRICE.ToString() + "€";
		cashValueText.text = CASH_RATE.ToString() + " Cash";
		cashBundlePriceText.text = CASH_BUNDLE_PRICE.ToString() + "€";
		cashBundleValueText.text = CASH_BUNDLE_RATE.ToString() + " Cash";
		cashSafePriceText.text = CASH_SAFE_PRICE.ToString() + "€";
		cashSafeValueText.text = CASH_SAFE_RATE.ToString() + " Cash";
	}

	function Update(){

	}

	// User clicks Coin Buy Button
	function CoinOnClick(){

		// Checks if User has enough Cash
		if(manager.CheckCash(COIN_PRICE)){

			// Removes the Cash from the user and adds the Coins
			manager.AddCoins(CASH_TO_COIN_RATE);
			manager.RemoveCash(COIN_PRICE);
		}

		// Finaly the Currency gets Updated
		manager.UpdateCurrency();
	}

	// User clicks Energy Buy Button
	function EnergyOnClick(){

		// Checks if User has enough Coins
		if(manager.CheckCoins(ENERGY_PRICE)){

			// Removes the Coins from the User and adds the Energys
			manager.RemoveCoins(ENERGY_PRICE);
			manager.AddEnergy(COIN_TO_ENERGY_RATE);
		}

		// Finaly the Currency gets Updated
		manager.UpdateCurrency();
	}

	// User clicks on a Cash Button
	function BuyCashOnClick(){
		UserPay(CASH_PRICE);
		manager.AddCash(CASH_RATE);
		manager.UpdateCurrency();
	}

	function BuyCashBundleOnClick(){
		UserPay(CASH_BUNDLE_PRICE);
		manager.AddCash(CASH_BUNDLE_RATE);
		manager.UpdateCurrency();
	}

	function BuyCashSafeOnClick(){
		UserPay(CASH_SAFE_PRICE);
		manager.AddCash(CASH_SAFE_RATE);
		manager.UpdateCurrency();
	}

	// Gets the money from the user
	function UserPay(price){
		// todo 
	}

	// Closes the Shop Ui
	function BackOnClick(){
		ui.CloseShop();
	}

	function ShopOnClick(){
		ui.CloseCashShop();
	}
}