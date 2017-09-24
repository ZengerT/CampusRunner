#pragma strict

// used: https://www.sitepoint.com/adding-pause-main-menu-and-game-over-screens-in-unity/
public class UiScript extends MonoBehaviour {

	// Variables
	var pauseObjects : GameObject[];
	var shopObjects : GameObject[];
	var cashObjects : GameObject[];
	public var pauseButton : Button;
	public var cashButton : Button;
	public var manager : GameManager;

	function Start () {


		// Declares the pause and shop Objects
		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
		shopObjects = GameObject.FindGameObjectsWithTag("ShowOnShop");
		cashObjects = GameObject.FindGameObjectsWithTag("ShowOnCash");

		// Start Settings
		hidePaused();
		hideShop();
		hideCashShop();
		Time.timeScale = 1;

		// Pause Button Click Listener
		var btn : Button = pauseButton.GetComponent.<Button>();
		btn.onClick.AddListener(PauseOnClick);

		// Cash Button Listener
		var cbtn : Button = cashButton.GetComponent.<Button>();
		cbtn.onClick.AddListener(OpenCashShop);
	}

	function Update () {
		
	}

	// Game gets paused and Pause Menu gets shown
	function PauseOnClick(){
		showPaused();
		Time.timeScale = 0;

		// Hides the Pause Button
		pauseButton.gameObject.SetActive(false);
	}

	// Shows the Pause Menu
	function showPaused(){
		for(var n : GameObject in pauseObjects){
			n.SetActive(true);
		}

	}

	// Hides the Pause Menu
	function hidePaused(){
		for(var n : GameObject in pauseObjects){
			n.SetActive(false);
		}
	}

	// Shows the shop
	function showShop(){
		for(var n : GameObject in shopObjects){
			n.SetActive(true);
		}	
	}

	// Hides the shop
	function hideShop(){
		for(var n : GameObject in shopObjects){
			n.SetActive(false);
		}
	}

	// Shows the Cash shop
	function showCashShop(){
		for(var n : GameObject in cashObjects){
			n.SetActive(true);
		}	
	}

	// Hides the Cash SHop
	function hideCashShop(){
		for(var n : GameObject in cashObjects){
			n.SetActive(false);
		}
	}

	// Continues the Game and hides the Pause Menu
	public function Continue(){
		Time.timeScale = 1;
		hidePaused();

		// Shows the Pause Button
		pauseButton.gameObject.SetActive(true);
	}



	// Opens the Shop and Closes the Pause Menu
	public function OpenShop(){
		showShop();
		hidePaused();
		manager.UpdateCurrency();
	}

	// Closes the Shop and Opens the Pause Menu
	public function CloseShop(){
		showPaused();
		hideShop();
		manager.UpdateCurrency();
	}

	// Opens the Cash Shop
	public function OpenCashShop(){
		hideShop();
		showCashShop();
		manager.UpdateCurrency();
	}

	//Closes the Cash Shop
	public function CloseCashShop(){
		hideCashShop();
		showShop();
		manager.UpdateCurrency();
	}
}