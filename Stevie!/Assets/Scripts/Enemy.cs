using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//I need to add this using for UI element manipulation.
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public int health;
    public Text HealthText;
    void Start () {
        if (health == 0) health = 5;

        HealthText.text = "Enemy Health: " + health;
	}
	
	void Update () {
		
	}
    /// <summary>
    /// Function used to deal damage through direct health reduction
    /// </summary>
    /// <param name="amount">How much damage is dealt?</param>
    public void ReduceHealth(int amount)
    {

        health -= amount;

        //I'm gonna update the UI text here. This could be done through a separate function called here..... Almost same result, 
        //But it'd depend on how much text you're updating at the same time, yadda yadda.
        HealthText.text = "Enemy Health: " + health;


        if (health <= 0)
        {

            //whatever we want
        }

    }
}
