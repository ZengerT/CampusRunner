using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{

    //public variables
    public GameObject mainPanel;
    public GameObject lvlPanel;
    public GameObject optPanel;
    public Slider[] volumeSliders;
    public GameObject[] levelButtons;

    //private variables;
    private bool[] check = new bool[] { true, false, false, false, false };
    private int count = 0;

    // Use this for initialization
    void Start()
    {

        mainPanel = GameObject.FindGameObjectWithTag("MainPanel");
        lvlPanel = GameObject.FindGameObjectWithTag("LevelPanel");
        optPanel = GameObject.FindGameObjectWithTag("OptionsPanel");

        lvlPanel.SetActive(false);
        optPanel.SetActive(false);

        levelButtons[1].GetComponent<Button>().interactable = false;
        levelButtons[2].GetComponent<Button>().interactable = false;
        levelButtons[3].GetComponent<Button>().interactable = false;
        levelButtons[4].GetComponent<Button>().interactable = false;

        CheckHighscore(check);

    }

    // Update is called once per frame
    void Update()
    {

        CheckHighscore(check);
        SetLevelButtonActive(check);

    }

    public void GotoLvlSelection()
    {
        mainPanel.SetActive(false);
        lvlPanel.SetActive(true);
    }


    public void GotoShop()
    {
        SceneManager.LoadScene("Shop Menu");
    }

    public void GotoSettings()
    {
        mainPanel.SetActive(false);
        optPanel.SetActive(true);
    }

    public void GetBack()
    {
        if (lvlPanel.activeSelf == true)
        {
            lvlPanel.SetActive(false);
        }

        if (optPanel.activeSelf == true)
        {
            optPanel.SetActive(false);
        }

        mainPanel.SetActive(true);
    }

    public void SetMasterVolume(float val)
    {

    }

    public void SetSFXVolume(float val)
    {

    }

    public void Level1()
    {
        SceneManager.LoadScene("FirstLevel");
    }

    public void Level2()
    {
        SceneManager.LoadScene("SecondLevel");
    }

    public void Level3()
    {
        SceneManager.LoadScene("ThirdLevel");
    }

    public void Level4()
    {
        SceneManager.LoadScene("FourthLevel");
    }

    public void Level5()
    {
        SceneManager.LoadScene("FifthLevel");
    }

    private void Modify(int i)
    {

        for (int z = count; z == 0; z--)
        {
            check[i] = true;
        }

    }

    private void SetLevelButtonActive(bool[] toCheck)
    {
        if (toCheck[0] == true)
        {
            levelButtons[0].GetComponent<Button>().interactable = true;
        }

        if (toCheck[1] == true)
        {
            levelButtons[1].GetComponent<Button>().interactable = true;
        }

        if (toCheck[2] == true)
        {
            levelButtons[2].GetComponent<Button>().interactable = true;
        }

        if (toCheck[3] == true)
        {
            levelButtons[3].GetComponent<Button>().interactable = true;
        }

        if (toCheck[4] == true)
        {
            levelButtons[4].GetComponent<Button>().interactable = true;
        }
    }

    private void CheckHighscore(bool[] toCheck)
    {



        if (PlayerPrefs.GetFloat("CampusRunnerHighScoreFirstLevel") > 10.00)
        {
            toCheck[1] = true;

        }

        if (PlayerPrefs.GetFloat("CampusRunnerHighScoreSecondLevel") > 10.00)
        {
            toCheck[2] = true;

        }

        if (PlayerPrefs.GetFloat("CampusRunnerHighScoreThirdLevel") > 10.00)
        {
            toCheck[3] = true;

        }

        if (PlayerPrefs.GetFloat("CampusRunnerHighScoreFourthLevel") > 10.00)
        {
            toCheck[4] = true;
        }

    }

}
