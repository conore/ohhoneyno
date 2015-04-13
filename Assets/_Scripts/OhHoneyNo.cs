using UnityEngine;
using System.Collections;

public class OhHoneyNo : MonoBehaviour {

	public GameObject itemPrefab;
	public float spawnHeight = 4.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//determine spawn point (heiht above bag)
		Vector3 spawnPoint;
		GameObject bag = GameObject.FindGameObjectWithTag ("bag");

		if (bag != null) {
			spawnPoint = bag.transform.position;
			spawnPoint.y += spawnHeight;

			//add some randomness to the spawn point
			float rand = Random.Range(-.5f,.5f);

			spawnPoint.x -= rand;
			spawnPoint.z += rand;

			if (Input.GetKeyDown ("space")) {
				GameObject.Instantiate (itemPrefab, spawnPoint, Quaternion.identity);
			}
		}
	}
}
