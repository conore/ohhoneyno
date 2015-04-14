using UnityEngine;
using System.Collections;

public class ScoreIndicator : MonoBehaviour {

	public float maxHeight = 10.0f;
	public float rotationSpeed = 5.0f;
	public float secondAlive = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Transform transform;
		transform = this.GetComponent<Transform>();


		if (transform.localScale.y < maxHeight) {
			Vector3 localScale = transform.localScale;

			localScale.y -= .5f;
			localScale.x += .5f;

			transform.localScale = localScale;
		} else {
			Destroy (this.gameObject);
		}
	}
}