using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//I need to add this using for UI element manipulation.
using UnityEngine.UI;


public class Enemy : MonoBehaviour {


	public AudioClip woodHit;
	//AudioSource audio;
    public int health;
    private Text HealthText;

	//create the explosion at the grenades position
	public GameObject woodExplode;

	public Vector3 deathScale;

	//private UnityEngine.AI.NavMeshAgent agent;
	UnityEngine.AI.NavMeshAgent agent;

	//scoreWorthPerDeath
	public int scoreValue = 1;


    void Start () {
		//getAudio
		//GetComponent<AudioSource>() = GetComponent<AudioSource>();

		if (health == 0) health = 2;
        //HealthText.text = "Enemy Health: " + health;

		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

	}
	
	void Update () {
		
	}
    /// <summary>
    /// Function used to deal damage through direct health reduction
    /// </summary>
    /// <param name="amount">How much damage is dealt?</param>
    public void ReduceHealth(int amount)
    {
		GetComponent<AudioSource>().clip = woodHit;
		//GetComponent<AudioSource>().Play();

		GetComponent<AudioSource>().PlayOneShot(woodHit, 0.7F);
        health -= amount;

        //I'm gonna update the UI text here. This could be done through a separate function called here..... Almost same result, 
        //But it'd depend on how much text you're updating at the same time, yadda yadda.
        //HealthText.text = "Enemy Health: " + health;

        if (health <= 0)
        {
			//stop Enemy
			agent.speed = 0;

			//score
			scoreManager.score += scoreValue;

			//Scale up by deathScale amount - Lerp currently not working
			transform.localScale = Vector3.Lerp(transform.localScale, deathScale,  Time.deltaTime);

			//Change Shader
			//transform.GetComponent<Renderer> ().material.color = Color.black;

			//Instantiate death particles
			Instantiate(woodExplode, gameObject.transform.position, Quaternion.identity);


			//I'm trying to destroy the enemy <--- I'm going to comment this out. I'll tell you more on the reddit message.
			//Destroy(gameObject, 0);

            //Print DeathCry!
			Debug.Log("Enemy is dead!!");

            //Since you already have this check, I'm going to extend it. If the enemy dies while IN THE FINISH LINE, they'll stop being counted and disappear.
            //You can adjust this if you'd like!
            FinishLine.instance.removeEnemyFromList(this.gameObject);
            this.gameObject.SetActive(false); //What I do with this is only deactivate the enemy, not destroy it. This way, you can reuse it. More on the reddit message.
            

        }

    }
}
