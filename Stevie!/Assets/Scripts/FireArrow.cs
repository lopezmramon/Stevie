using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArrow : MonoBehaviour
{
    ///Variables. We have:
    ///1. 2 game objects, which are the arrows
    ///2. A position Transform (which is an empty game object in the Scene) where arrows spawn
    ///3. A Vector 3 which is the force with which the arrows are shot, you can adjust this before you fire at any time in-inspector
    ///4. Cooldown for the arrows to not be fired 60 times per second (it can be 0 to achieve this effect)
    ///5. Storage for the original cooldown
    ///6. An enumerator to choose which arrow to fire before it's fired in-inspector
    ///7. The rigidbody of the arrow fired, in order to push it forward initially. Gravity is Simulated in-engine.
    public GameObject blueArrow, redArrow;
    public Transform arrowSpawner;
    public Vector3 launchForce;
    public float arrowCooldown;
    float arrowCooldownOriginal;

    public enum ArrowType { blueArrow, redArrow }

    public ArrowType whichArrow;

    Rigidbody arrowRigidbody;

    void Start()
    {

        arrowCooldownOriginal = arrowCooldown;
    }

    void Update()
    {
        arrowCooldown -= Time.deltaTime;
        if(arrowCooldown < 0 & Input.GetKeyDown(KeyCode.Space))
        {

            ShootArrow();
        }


    }


    void ShootArrow()
    {
        GameObject newArrow = null;

        switch (whichArrow)
        {
            case ArrowType.blueArrow:
                newArrow = Instantiate(blueArrow, arrowSpawner.position, transform.rotation);
               
                break;

            case ArrowType.redArrow:
                newArrow = Instantiate(redArrow, arrowSpawner.position, transform.rotation);
              
                break;
        }

        newArrow.GetComponent<Rigidbody>().AddForce(launchForce * Time.deltaTime);
        arrowCooldown = arrowCooldownOriginal;
    }
}
