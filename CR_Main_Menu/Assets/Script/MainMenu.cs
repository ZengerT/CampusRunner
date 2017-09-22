using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour {

    //public variables
    public GameObject mainPanel;
    public GameObject lvlPanel;
    public GameObject optPanel;
    public Slider[] volumeSliders;

	// Use this for initialization
	void Start () {
        mainPanel = GameObject.FindGameObjectWithTag("MainPanel");
        lvlPanel = GameObject.FindGameObjectWithTag("LevelPanel");
        optPanel = GameObject.FindGameObjectWithTag("OptionsPanel");

        lvlPanel.SetActive(false);
        optPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        //Debug.Log(Input.touchCount);

        //if (Input.touchCount > 0)
       // {
            //touch controls

            //Debug.Log(Input.GetTouch(0).position);

            /*foreach(Touch touch in Input.touches)
            {
                Debug.Log(touch.position);
            
            }
            

            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Debug.Log("Began");
            }

            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Debug.Log("Move");
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                Debug.Log("End");
            }
            */
       // }

        

    }

    public void GotoLvlSelection()
    {
        mainPanel.SetActive(false);
        lvlPanel.SetActive(true);
    }


    public void GotoShop()
    {
        //Go to Shop
        Debug.Log("Go To Shop");
    }

    public void GotoSettings()
    {
        mainPanel.SetActive(false);
        optPanel.SetActive(true);
    }

    public void GetBack()
    {
        if(lvlPanel.activeSelf == true)
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

    public void Level1 ()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void Level4()
    {
        SceneManager.LoadScene("Level4");
    }

    public void Level5()
    {
        SceneManager.LoadScene("Level5");
    }
}
