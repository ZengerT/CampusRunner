using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBehaviour : MonoBehaviour {

    /*              //
    //  Variables   //
    */              //

    public Button energyDrink;
    public Image cooldownTimer;
    public GameManager manager;

    public float currentCooldown = 10;

    /*              //
    //  Constants   //
    */              //

    // EnergyDrink Cooldown
    const float ENERGY_COOLDOWN = 10;

    // Slow effect of the EnergyDrink
    const float ENERGY_SLOWDOWN = 0.7f;
   
    // Use this for initialization
    void Start () {
        Button btn = energyDrink.GetComponent<Button>();
        btn.onClick.AddListener(UseEnergy);

        if (!manager.CheckEnergy(1))
        {
            cooldownTimer.fillAmount = 0;
            
        }
    }
	
	// Update is called once per frame
	void Update () {
        // Checks if the Item is stil on Cooldown
        if (!CheckCooldown() && manager.CheckEnergy(1))
        {
            // if on cooldown increase the cooldown timer and fill up more of the cooldown circle
            currentCooldown += Time.deltaTime;
            cooldownTimer.fillAmount = currentCooldown / ENERGY_COOLDOWN;
        }
        // If no Cooldown and Energy Available display that energy
        else if(manager.CheckEnergy(1))
        {
            cooldownTimer.fillAmount = 1;
        }
        // Else display no energy
        else
        {
            cooldownTimer.fillAmount = 0;
            currentCooldown += Time.deltaTime;
        }
	}

    // Uses an EnergyDrink and resets the Timer
    void UseEnergy()
    {
        // If the Item is off Cooldown
        if (CheckCooldown())
        {
            if (manager.CheckEnergy(1))
            {
                // Set the Item on Cooldown
                currentCooldown = 0;

                // Remove one Energy drink
                manager.RemoveEnergy(1);

                // Slow down the level
                 Obstacle.speedMultiplier = ENERGY_SLOWDOWN;
            }
        }


    }

    // Checks if the Cooldown is reached
    private bool CheckCooldown()
    {
        if (currentCooldown >= ENERGY_COOLDOWN)
        {
            Obstacle.speedMultiplier = 1;
            return true;
        }
        return false;
    }

}
