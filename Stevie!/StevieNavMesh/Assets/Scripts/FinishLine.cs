using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Using UI part of Unity again
using UnityEngine.UI;

public class FinishLine : MonoBehaviour {

    public int healthPoints, maxHealthPoints;
    public float healthRemovalTimer, healthRemovalTimerOriginal;
    public Text finishLineHealthText;
    public List<GameObject> enemyList = new List<GameObject>();

    //I'm making this a singleton, assuming you'll have 1 finish line in each level. If this is not true, what we need
    //to do is adjust code a little bit everywhere else.
    public static FinishLine instance;

	void Start () {

        if (maxHealthPoints == 0)
        {
            maxHealthPoints = 5;
        }
        healthPoints = maxHealthPoints;

        finishLineHealthText.text = maxHealthPoints.ToString();
        
        //If the timer hasn't been set on the inspector, or it's 0, make it 1 
        if (healthRemovalTimerOriginal ==0)
        {
            healthRemovalTimerOriginal = 1;
        }

        //We make the timer we use equal to the starting timer we set so we can start playing with it
        healthRemovalTimer = healthRemovalTimerOriginal;

        if (instance == null)
        {
            instance = this;
        }else
        {
            Debug.Log("You have 2 finish lines, is this intended?");
        }
	}
	
	void Update () {
        //So, we have a list with a specific number of enemies. This number can be 0, of course. What we do is remove health based on a timer.
        //We have the timer's value on the Inspector, but I'll assume it's 1 second as per your message.

        //Reducing the timer's value! Deltatime in Unity is set by the coders. It's 0.022 I believe, which times 60 (fps) becomes 1 per second.
        //This is a very standard practice, albeit not the best, it's the simplest, fastest, while being clean.
        healthRemovalTimer -= Time.deltaTime;
        if (healthRemovalTimer < 0)
        {
            //Using the Remove Health function with the amount of enemies present on the list.
            removeHealth(enemyList.Count);
            healthRemovalTimer = healthRemovalTimerOriginal;


        }


    }

    private void FixedUpdate()
    {


       

    }




    //We're defining what happens in here. I'm gonna add a Box Collider to the Finish Line GameObject, which you can adapt.
    //Then, what's going to happen is, each time an enemy enters that area, they get added to a List of enemies (so they don't 
    //get counted twice), then for each one, 1 damage will be dealt per second. This whole thing will be a separate function though.
    //You'll see down here!
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyToList(other.gameObject);
        }
    }

    //If an enemy leaves the trigger, they'll be removed from the list. They have to leave by actually moving, not by disappearing.
    //Which leads me to going to the Enemy Script and creating a function that removes them from the list!
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            removeEnemyFromList(other.gameObject);
        }
    }

    void EnemyToList(GameObject enemy)
    {
        //If the enemy list doesn't contain the enemy that is entering the trigger
        if (!enemyList.Contains(enemy))
        {
            enemyList.Add(enemy);

        }
        
    }

    public void removeEnemyFromList(GameObject enemy)
    {
        if (enemyList.Contains(enemy))
        {
            enemyList.Remove(enemy);
        }
    }
    /// <summary>
    /// Public function that damages the finishline. This is in case you'd like some arrow shooting enemy to be able to do this. 
    /// </summary>
    /// <param name="amount"></param>
    public void removeHealth(int amount)
    {
        healthPoints -= amount;
        UpdateUIText();
    }
    /// <summary>
    /// Adding this in case you'd like to heal the finish line from other code. If you do, you just call FinishLine.instance.AddHealth(###) and boom, healed!
    /// </summary>
    /// <param name="amount"></param>
    public void AddHealth(int amount)
    {
        healthPoints += amount;
        UpdateUIText();
    }

    /// <summary>
    /// This function helps me not repeat code. DRY.
    /// </summary>
    void UpdateUIText()
    {
        finishLineHealthText.text = healthPoints.ToString();


    }
}
