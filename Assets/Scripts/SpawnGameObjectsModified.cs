using UnityEngine;
using System.Collections;

public class SpawnGameObjectsModified : MonoBehaviour
{
	// public variables
	public float secondsBetweenSpawning = 0.1f;
	public float xMinRange = -25.0f;
	public float xMaxRange = 25.0f;
	public float yMinRange = 8.0f;
	public float yMaxRange = 25.0f;
	public float zMinRange = -25.0f;
	public float zMaxRange = 25.0f;
	public GameObject[] spawnObjects; // what prefabs to spawn 




	private float nextSpawnTime;

	// Use this for initialization
	void Start ()
	{
		// determine when to spawn the next object
		nextSpawnTime = Time.time+secondsBetweenSpawning;

	
	}
	
	// Update is called once per frame
	void Update ()
	{
		// exit if there is a game manager and the game is over
		if (GameManager.gm) {
			if (GameManager.gm.gameIsOver)
				return;
		}

		// if time to spawn a new game object
		if (Time.time  >= nextSpawnTime) {
			// Spawn the game object through function below
			MakeThingToSpawn ();

			// determine the next time to spawn the object
			nextSpawnTime = Time.time+secondsBetweenSpawning;


		}	
	}

	void MakeThingToSpawn ()
	{
		Vector3 spawnPosition;
		Vector3 gameObjectPosition = gameObject.transform.position;

		// get a random position between the specified ranges
		spawnPosition.x = gameObjectPosition.x + Random.Range (xMinRange, xMaxRange);
		spawnPosition.y = gameObjectPosition.y + Random.Range (yMinRange, yMaxRange);
		spawnPosition.z = gameObjectPosition.z + Random.Range (zMinRange, zMaxRange);

		int objectToSpawn = Random.Range (0, spawnObjects.Length);


		TargetMover keepItAboveGround = spawnObjects[objectToSpawn].GetComponent<TargetMover> ();
		string b = keepItAboveGround.motionState.ToString ();


		if (b == "Vertical" || b == "Horizontal") {

			Vector3 objectYPosition = spawnPosition;
			objectYPosition.y += 5;
			GameObject spawnedObject = Instantiate (spawnObjects [objectToSpawn], objectYPosition, transform.rotation) as GameObject;
			spawnedObject.transform.parent = gameObject.transform;

		} else {
		

				GameObject spawnedObject = Instantiate (spawnObjects [objectToSpawn], spawnPosition, transform.rotation) as GameObject;
				spawnedObject.transform.parent = gameObject.transform;
				
				
			}

		}



	}
		
