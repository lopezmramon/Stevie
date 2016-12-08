using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrip : MonoBehaviour {

	public int curShipHealth = 50;

	void Start(){
		StartCoroutine(addHealth());
	}

	void Update(){


	}


	IEnumerator addHealth(){


			if (curShipHealth < 100){ // if health < 100...
				curShipHealth += 1; // increase health and wait the specified time
				yield return new WaitForSeconds(1);
			} else { // if health >= 100, just yield 
				yield return null;
			}


		}



	}


