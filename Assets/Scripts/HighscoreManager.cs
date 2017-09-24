using UnityEngine;
using UnityEngine.UI;

public class HighscoreManager : MonoBehaviour {

    public Text firstLevelText;
    public Text secondLevelText;
    public Text thirdLevelText;
    public Text fourthLevelText;
    public Text fifthLevelText;

    // Use this for initialization
    void Start () {
        firstLevelText.text = PlayerPrefs.GetFloat("CampusRunnerHighScoreFirstLevel").ToString("0.000") + " s";
        secondLevelText.text = PlayerPrefs.GetFloat("CampusRunnerHighScoreSecondLevel").ToString("0.000") + " s";
        thirdLevelText.text = PlayerPrefs.GetFloat("CampusRunnerHighScoreThirdLevel").ToString("0.000") + " s";
        fourthLevelText.text = PlayerPrefs.GetFloat("CampusRunnerHighScoreFourthLevel").ToString("0.000") + " s";
        fifthLevelText.text = PlayerPrefs.GetFloat("CampusRunnerHighScoreFifthLevel").ToString("0.000") + " s";
    }
}
