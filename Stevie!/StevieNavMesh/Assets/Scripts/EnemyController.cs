using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public int health = 5;
	
    public void Damage(int dmg)
    {
        health -= dmg;
        if(health <= 0)
        {
            health = 0;
			transform.GetComponent<Renderer> ().material.color = Color.blue;
            OnDeath();
        }
    }

    void OnDeath()
    {
        Debug.Log("Enemy is dead. [Double Click to Edit Action Code]");
        Destroy(gameObject);
        // Death Code
    }
}
