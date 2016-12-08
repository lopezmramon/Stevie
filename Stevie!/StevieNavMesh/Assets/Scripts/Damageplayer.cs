using UnityEngine; 
using System.Collections; 



public class Damageplayer : MonoBehaviour { 

	public int playerHealth=1000; 
	int damage=1; 


	void Start(){ 

		print (playerHealth);
	
	} 

	//this works if enemy has rigidbody, and not if its a trigger
	void OnCollisionEnter(Collision collision){ 

		if (collision.gameObject.tag=="Enemy"){ 

			playerHealth -= damage; print ("Owwwww!!!!"+ playerHealth); 
		
		
		} 
	
	
	} 


}