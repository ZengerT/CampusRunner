using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

// Save Load from (https://unity3d.com/de/learn/tutorials/topics/scripting/persistence-saving-and-loading-data?playlist=17117)
public class GameManager : MonoBehaviour {

    // Currency Variables
    int coins = 0;
    int cash = 0;
    int energys = 0;

    public UiManager ui;

	// Use this for initialization
	void Start () {

		// Makes the first GameManager persistent, destroy duplicates
			DontDestroyOnLoad (this.gameObject);
		
        // Loads the Users Currency and updates the Ui
        Load();
        UpdateCurrency();
	}

    // Function to Save the Money
    void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/playerCurrency.dat", FileMode.OpenOrCreate);

        CurrencyData data = new CurrencyData();
        data.cash = cash;
        data.coins = coins;
        data.energy = energys;

        bf.Serialize(file, data);
        file.Close();      
    }

    // Function to Load the Money
    void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerCurrency.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerCurrency.dat", FileMode.Open);
            CurrencyData data = (CurrencyData)bf.Deserialize(file);
            file.Close();

            cash = data.cash;
            coins = data.coins;
            energys = data.energy;
        }
    }

    // In future Updates this would be stored in a Database on an external Server
    // Updates the Ui and Saves the Currency in the playerCurrency.dat
    public void UpdateCurrency()
    {
        Save();
        ui.UpdateCurrencyText(cash, coins, energys);
    }

	// Use Energy
	void UseEnergy(){
		if(CheckEnergy(1)){
			RemoveEnergy (1);
			// Do smth
		}
	}

    /* 
        Cash Functions
    */

    // Adds the amount of Cash to the total Cash
    public void AddCash(int amount)
    {
        cash += amount;
    }

    //Removes the amount of Cash
    public void RemoveCash(int amount)
    {
        if (CheckCash(amount))
        {
            cash -= amount;
        }

    }

    // Checks if the Cash can be removed
    public bool CheckCash(int amount)
    {
        if (cash >= amount)
        {
            return true;
        }
        return false;
    }

    /* 
        Coin Functions
    */

    // Adds the amount of Coins to the total Coins
    public void AddCoins(int amount)
    {
        coins += amount;
    }

    //Removes the amount of Coins 
    public void RemoveCoins(int amount)
    {
        if (CheckCoins(amount))
        {
            coins -= amount;
        }
    }

    // Checks if the Coins can be removed
    public bool CheckCoins(int amount)
    {
        if (coins >= amount)
        {
            return true;
        }
        return false;
    }

    /* 
        Energy-Drink Functions
    */

    // Adds the amount of EnergyDrinks to the total amount of EnergyDrinks
    public void AddEnergy(int amount)
    {
        energys += amount;
    }

    //Removes the amount of Energys 
    public void RemoveEnergy(int amount)
    {
        energys -= amount;
    }

    // Checks if the Coins can be removed
    public bool CheckEnergy(int amount)
    {
        if (energys >= amount)
        {
            return true;
        }
        return false;
    }
}

// Container Class
[Serializable]
class CurrencyData
{
    public int cash;
    public int coins;
    public int energy;
}