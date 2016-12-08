using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour {

	// The player's score.
	public static int score;

	// Reference to the Text component.
	Text text;

	// Use this for initialization
	void Awake () {
		
		// Set up the reference.
		text = GetComponent <Text> ();

		// Reset the score when starting level
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {

		// Set the displayed text to be the word "Score" followed by the score value.
		text.text = "Kills: " + score;
	}
}
