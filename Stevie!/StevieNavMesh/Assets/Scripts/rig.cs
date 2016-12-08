using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rig : MonoBehaviour {


	public float lastDamage;
	//public float TakeDamage;
	public float damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerStay(Collider other){
		lastDamage += Time.deltaTime;

		//if (lastDamage >= 2f){
		//	if (other.GetComponent<Collider>().gameObject.GetComponent<Actor>() /*&& Time.time >= lastDamage*/){
				//other.GetComponent<Collider>().gameObject.GetComponent<Actor>().TakeDamage(damage);
				//lastDamage = 0;
			//}
		//}

	}


}
