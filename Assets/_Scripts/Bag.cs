using UnityEngine;
using System.Collections;

public class Bag : MonoBehaviour {

	public float moveSpeed = 200.0f;
	public float bounceMultiplier = 2.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate() {

		Vector3 vel = new Vector3 ();
		
		if (Input.GetAxis ("Horizontal") != 0) {
			vel.x = (Input.GetAxis ("Horizontal")*Time.deltaTime*moveSpeed);
		}

		GetComponent<Rigidbody>().velocity = vel;

		if (Input.GetKeyDown ("return")) {
			vel = new Vector3();
			vel.y = (bounceMultiplier*Time.deltaTime*moveSpeed);
			GetComponent<Rigidbody>().velocity = vel;

			GameObject.Destroy (this.gameObject);
		}
	}
}
