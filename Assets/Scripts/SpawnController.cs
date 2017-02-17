using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {
	//Object to be spawned
	public GameObject hardlePrefab;

	//Interval to be spawned
	public float rateSpawn;
	public float currentTime;
	private int position;
	private float y;

	// Use this for initialization
	void Start () {
		currentTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;

		if(currentTime >= rateSpawn){
			currentTime = 0;
			position = Random.Range (1, 100);

			if (position > 50) {
				y = 0.03f;
			} else {
				y = 0.65f;
			}

			GameObject tempPrefab = Instantiate (hardlePrefab) as GameObject;
			//Create the object on position of handlePrefab
			tempPrefab.transform.position = new Vector3 (transform.position.x, y, tempPrefab.transform.position.z);
				
		}
		
	}
}
