using UnityEngine;
using System.Collections;


//https://forum.unity3d.com/threads/free-basic-tower-defence-spawn-system.183789/


public class SpawnSystem : MonoBehaviour {
	//Your enemy character prefab (Must have a character controller component)
	public GameObject enemyPrefab;
	//How high above the ground you want your enemy spawned (0 = ground level)
	public float spawnHeightOffset = 0.0f;
	//The minimum distance from the target your enemies will spawn
	public float spawnRadiusMin = 20.0f;
	//The maximum distance from the target your enemies will spawn
	public float spawnRadiusMax = 30.0f;
	//The amount of time between each spawn
	public float spawnDelay = 0.5f;
	//Are you using a terrain? Script uses this to calculate how high above the enemy needs to be placed on spawn
	public bool useTerrain = true;

	//How tall is your enemy character
	private float enemyHeight;
	//What is the current wave
	private int curWave = 1;
	//Is the spawn system currently spawning enemies
	private bool isSpawning = false;
	//The initial maximum number of enemies per wave
	private int maxEnemies = 5;
	//The current enemies in the scene
	private GameObject[] curEnemies;
	//The selected spawn point (Random angle and distance from target)
	private Vector3 spawnPoint;

	void Start () {
		//Find what the height of the enemy's CharacterContoller component is
		enemyHeight = enemyPrefab.GetComponent<CharacterController>().height;
		//Begin the first wave
		StartCoroutine(SpawnEnemy());
	}

	void Update () {
		//Check if the script is NOT spawning enemies
		if (!isSpawning) {
			//Check how many enemies are still in the scene
			curEnemies = GameObject.FindGameObjectsWithTag("Enemy");
			//When there are no more enemies left, increase the current wave
			if (curEnemies.Length <= 0) {
				IncreaseWave();
			}
		}
	}

	IEnumerator SpawnEnemy () {
		//Tell script that we are currently spawning enemies
		isSpawning = true;
		//Loop until script has spawned the maximum number of enemies for this round
		for (int i = 0; i < maxEnemies; i++) {
			//Delay between spawning
			yield return new WaitForSeconds(spawnDelay);
			//Find a random spawn point
			FindSpawnPoint(Random.Range(spawnRadiusMin, spawnRadiusMax), Random.Range(0, 359));
			//Spawn an enemy at the random spawn point
			Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
		}
		//Tell script that we are finished spawning enemies for this round
		isSpawning = false;
	}

	Vector3 FindSpawnPoint(float spawnRadius, int angleInDegrees) {
		//find a random point on the circumference of a circle, with random radius from target between specified min / max distance
		float pointX = (spawnRadius * Mathf.Cos(angleInDegrees * Mathf.PI / 180.0f)) + transform.position.x;
		float pointZ = (spawnRadius * Mathf.Sin(angleInDegrees * Mathf.PI / 180.0f)) + transform.position.z;
		//Set the spawn point into a Vector3
		spawnPoint = new Vector3(pointX, 0.0f, pointZ);
		//Are we using a terrain?
		if (useTerrain) {
			//Adjust the spawn points y value to account for terrain relief
			spawnPoint.y = Terrain.activeTerrain.SampleHeight(spawnPoint);
		}
		//Add half of the enemies height to the y value (So that his feet are on the ground, not waist deep)
		spawnPoint.y += (enemyHeight / 2) + spawnHeightOffset;
		//Return the final spawn point
		return spawnPoint;
	}

	void IncreaseWave () {
		//Increase the current wave by 1
		curWave++;
		//Increase the maximum number of enemies for this wave
		maxEnemies = curWave * 5;
		//Start the next wave
		StartCoroutine(SpawnEnemy());
	}

	void OnGUI () {
		//Display the wave number in the top left corner of screen
		GUI.Label(new Rect(5, 5, 100, 30), "Wave " + curWave.ToString());  
	}
}
