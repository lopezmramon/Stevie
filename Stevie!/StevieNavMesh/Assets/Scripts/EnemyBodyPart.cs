using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBodyPart : MonoBehaviour {

    public int damagePerShotReceived;
	//public static GameObject FindParentWithTag("Enemy");



	void Start () {
		
	}
		



	void Update () {
		
	}

    //So what's this? This is the method that says "If I am collided by something, on the FRAME the collision starts, do something.
    private void OnCollisionEnter(Collision collision)
    {
		

        ///This function talks to the arrow (the function checks which arrow it is)
        ///And tells them "Hey, freeze when you hit me", which translates to them being Kinematic.
        ///Then, we know our parent (the base Enemy, which contains the base Enemy class), we tell them to activate the Reduce Health Function with
        ///The damage amount THIS object has on it. So each body part decides ITSELF how much damage is dealt.
        switch (collision.gameObject.name)
        {
		case "Blue Arrow(Clone)":


			//Destroy (GetComponent<Rigidbody>());
			collision.gameObject.GetComponent<Rigidbody> ().isKinematic = true;

			//the object this script is attached to is the enemy
			//collision.gameObject is the arrow

			//Destroy (collision.gameObject.GetComponent<BoxCollider>());

			//WORKING destroy arrow rigidbody
			//Destroy (collision.gameObject.GetComponent<Rigidbody>());

			//WORKING - destroy enemy rigidboy
			//Destroy (GetComponent<Rigidbody>());

			//WORKING - destroy Enemy RigidBody
			//transform.parent.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

			//WORKING Freeze constraints
			collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;




			collision.transform.parent = transform;

			//Reverse order
			//transform.parent = collision.transform;

			//Destroy (GetComponent<Collider>());
			//transform.GetComponent<Enemy> ().ReduceHealth (damagePerShotReceived);

			//Destroy after 5 seconds
			Destroy (collision.gameObject, 2);

			//WORKING change color
			//transform.GetComponent<Renderer> ().material.color = Color.blue;

			//destroy arrow
			//Destroy (collision.gameObject, 0);

			//wait 5 seconds and run function 'functionname'
			//Invoke("functionName", 5.0f);

			//parents arrow to objects with name "Enemy"
			//collision.transform.parent = GameObject.Find("Enemy").transform;

	
			//Destroy (Instantiate(GreenArrow, EnemyLocation.position, EnemyLocation.rotation), 2);
			//yield return new WaitForSeconds(3);
			//Destroy(gameObject);
			//transform.parent = collision.transform;



           		break;

        case "Red Arrow(Clone)":
                collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
			transform.parent.GetComponent<Enemy>().ReduceHealth(damagePerShotReceived);
				transform.GetComponent<Renderer> ().material.color = Color.red;
			collision.transform.parent = transform;
                
				break;
    
		case "Green Arrow(Clone)":
				collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
			transform.parent.GetComponent<Enemy>().ReduceHealth(damagePerShotReceived);
				//transform.GetComponent<Renderer> ().material.color = Color.green;
				break;
        }
       
    }







}
