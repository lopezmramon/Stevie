using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour {

	public float goalHealth = 100;
	float timer = 0;
	// set this up in the inspector!
	public float damageTime = 2;
	public float damageAmount = 15;



	void OnTriggerStay(Collider hit)
	{
		if(hit.gameObject.tag == "Enemy")
		{
			// Damage the player every 'damageTime'
			if(timer >= damageTime)
			{
				timer -= damageTime;

				goalHealth -= damageAmount;
				/*// use the generic version of GetComponent, because it's faster
				playerHealth hp = hit.GetComponent<playerHealth>();

				//references the function 'AdjustCurrentHealth', minusing damageAmount, in the script 'PlayerHealth'
				hp.AdjustCurrentHealth(-damageAmount);*/
			}
			timer += Time.deltaTime;
		}
	}
	void OnTriggerExit(){

		timer = 0;
	}
	/*{
		if(hit.gameObject.tag == "Enemy")
		{
			// Reset the damage timer
			timer = 0;
		}
	}*/

}