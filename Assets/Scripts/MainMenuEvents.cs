using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenuEvents : MonoBehaviour {

	//private Text authStatus;

	public void Start() {
		// Create client configuration
		PlayGamesClientConfiguration config = new 
			PlayGamesClientConfiguration.Builder()
			.Build();

		// Enable debugging output (recommended)
		PlayGamesPlatform.DebugLogEnabled = true;

		// Initialize and activate the platform
		PlayGamesPlatform.InitializeInstance(config);
		PlayGamesPlatform.Activate();
		// END THE CODE TO PASTE INTO START

		// try silent sign-in
		PlayGamesPlatform.Instance.Authenticate(SignInCallback, false);
	}

	public void SignInCallback(bool success) {
		if (success) {
			Debug.Log("(CampusRunner) Signed in!");
		} else {
			Debug.Log("(CampusRunner) Sign-in failed...");
		}
	}

	public void ShowLeaderboards() {
		if (PlayGamesPlatform.Instance.localUser.authenticated) {
			PlayGamesPlatform.Instance.ShowLeaderboardUI();
		}
		else {
			Debug.Log("Cannot show leaderboard: not authenticated");
		}
	}
}