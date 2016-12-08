using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ontrigger : MonoBehaviour {




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		



	}

	void OnTriggerEnter(Collider col) {
		
		if(col.tag == "Enemy") {
			Debug.Log ("XXXXXXXXXXXXXXXXXXXXXXXXX");
		}

		if(col.tag == "Player") {
			Debug.Log ("HOoray");
		}
	}



}
