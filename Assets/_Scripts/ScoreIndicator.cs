using UnityEngine;
using System.Collections;

public class ScoreIndicator : MonoBehaviour {

	float maxHeight = 30.0f;
	public float rotationSpeed = 5.0f;
	public float secondAlive = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Transform transform;
		transform = this.GetComponent<Transform>();

		//print (transform.localPosition.y);

		if (transform.position.y < maxHeight) {
			Vector3 position = transform.position;

			print (position.y);

			position.y += .5f;

			transform.position = position;
		} else {
			Destroy (this.gameObject);
		}
	}
}