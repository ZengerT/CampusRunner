#pragma strict
 import UnityEngine.SceneManagement;

// From Unity Documentation
public class ButtonBehaviourScript extends MonoBehaviour {

	// Declares the 4 buttons
	public var continueButton: Button;
	public var retryButton: Button;
	public var shopButton: Button;
	public var closeButton: Button;

	public var ui : UiScript;

	function Start() {
		// Continue Button
		var cbtn: Button = continueButton.GetComponent.<Button>();
		cbtn.onClick.AddListener(ContinueOnClick);

		// Retry Button
		var rbtn: Button = retryButton.GetComponent.<Button>();
		rbtn.onClick.AddListener(RetryOnClick);

		// Shop Button
		var sbtn: Button = shopButton.GetComponent.<Button>();
		sbtn.onClick.AddListener(ShopOnClick);

		// Close Button
		var clbtn: Button = closeButton.GetComponent.<Button>();
		clbtn.onClick.AddListener(CloseOnClick);

	}

	// Continue Button Function
	function ContinueOnClick(){
		ui.Continue();
	}

	// Retry Button Function
	function RetryOnClick(){
		SceneManager.LoadScene("Game");
	}

	// Shop Button Function
	function ShopOnClick(){
		ui.OpenShop();
	}

	// Close Button Function
	function CloseOnClick(){
		SceneManager.LoadScene("MainMenu");
	}

}

