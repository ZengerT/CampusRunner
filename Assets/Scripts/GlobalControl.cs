using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour {

    public static GlobalControl Instance;
    

    

    void Awake()
    {
        GameObject AudioSource = GameObject.Find("AudioSource");
        if (Instance == null)
        {
            DontDestroyOnLoad(AudioSource);
            Instance = this;
            Debug.Log("Its this Instance!");
        }
        else
        {
            DestroyImmediate(GameObject.Find("AudioSource"));
            Debug.Log("FML, Singlton is one piece of crap eh");

        }
        
    }


    private void Start()
    {
        



    }


    void Update()
    {

      
        
    }



}
