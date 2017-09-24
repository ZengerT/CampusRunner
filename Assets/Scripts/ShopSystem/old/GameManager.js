#pragma strict
import UnityEngine.UI;
import System;
import System.IO;
import System.Collections;
import System.Runtime.Serialization.Formatters.Binary;

// Variables
var coins : int = 0;
var cash : int = 0;
var energys : int = 0;

public var cashText : Text;
public var cashShopText : Text;
public var coinText : Text;

public class GameManager extends MonoBehaviour {
function Start () {
	// DontDestroyOnLoad(gameObject);

	// Load the Users Currency and update the Ui
	Load();
	UpdateCurrency();
}

function Update () {

}

// Save Load from (https://unity3d.com/de/learn/tutorials/topics/scripting/persistence-saving-and-loading-data?playlist=17117)
public function Save(){
	var bf : BinaryFormatter = new BinaryFormatter();
	var file : FileStream = File.Open(Application.persistentDataPath + "/playerCurrency.dat", FileMode.OpenOrCreate);

	var data : CurrencyData = new CurrencyData();
	data.cash = cash;
	data.coins = coins;
	data.energy = energys;

	bf.Serialize(file, data);
	file.Close();
}

public function Load(){
	if(File.Exists(Application.persistentDataPath + "/playerCurrency.dat")){
		var bf : BinaryFormatter = new BinaryFormatter();
		var file : FileStream  = File.Open(Application.persistentDataPath + "/playerCurrency.dat", FileMode.Open);
		var data : CurrencyData = bf.Deserialize(file);
		file.Close();

		cash = data.cash;
		coins = data.coins;
		energys = data.energy;
	}

}

// In future Updates this would be stored in a Database on an external Server
// Updates the Ui and Saves the Currency in the playerCurrency.dat
public function UpdateCurrency (){

	cashText.text = cash.ToString();
	coinText.text = coins.ToString();
	cashShopText.text = cash.ToString();

	Save();
}

// Adds the amount of Cash to the total Cash
public function AddCash(amount : int){
	cash += amount;
}

//Removes the amount of Cash
public function RemoveCash(amount : int){
	if(CheckCash(amount)){
		cash -= amount;
	}

}

// Checks if the Cash can be removed
public function CheckCash(amount : int){
	if(cash >= amount){
		return true;
	}
	return false;
}

// Adds the amount of Coins to the total Coins
public function AddCoins(amount : int){
	coins += amount;
}

//Removes the amount of Coins 
public function RemoveCoins(amount : int){
	if(CheckCoins(amount)){
		coins -= amount;
	}
}

// Checks if the Coins can be removed
public function CheckCoins(amount : int){
	if(coins >= amount){
		return true;
	}
	return false;
}

/* 
	Energy-Drink Functions
*/

// Adds the amount of EnergyDrinks to the total amount of EnergyDrinks
public function AddEnergy(amount : int){
	energys += amount;
}

//Removes the amount of Energys 
public function RemoveEnergy(amount : int){
		energys -= amount;
}

// Checks if the Coins can be removed
public function CheckEnergy(amount : int){
	if(energys >= amount){
		return true;
	}
	return false;
}
}

// Container Class
class CurrencyData
{
	public var cash;
	public var coins;
	public var energy;
}