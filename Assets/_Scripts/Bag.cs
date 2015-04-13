using UnityEngine;
using System.Collections;

public class Bag : MonoBehaviour {

	public float moveSpeed = 200.0f;
	public float bounceMultiplier = 2.0f;
	public AudioClip ohno;
	public AudioClip item_move;
	public AudioClip[] bagNoises;

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
			AudioSource.PlayClipAtPoint (ohno, this.gameObject.transform.position);
			GameObject.Destroy (this.gameObject);
		}
	}

	void OnCollisionEnter (Collision col) {

		AudioClip loudSound = bagNoises[ Random.Range(0, bagNoises.Length)];

		AudioClip bagSound = (col.relativeVelocity.magnitude > 4) ? loudSound : item_move;

		AudioSource.PlayClipAtPoint (bagSound, gameObject.transform.position);
	}
}
