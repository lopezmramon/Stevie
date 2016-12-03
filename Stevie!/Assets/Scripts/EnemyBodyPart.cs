using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBodyPart : MonoBehaviour {

    public int damagePerShotReceived;

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
        {//Both kinds of arrows do the same effect right now, but they can be changed.
            case "Blue Arrow(Clone)":
                collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                transform.parent.GetComponent<Enemy>().ReduceHealth(damagePerShotReceived);
                break;
            case "Red Arrow(Clone)":
                collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                transform.parent.GetComponent<Enemy>().ReduceHealth(damagePerShotReceived);
                break;
    

        }
       
    }
}
