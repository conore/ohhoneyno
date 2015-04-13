using UnityEngine;
using System.Collections;

public class Bag : MonoBehaviour {

	public float moveSpeed = 200.0f;
	public float bounceMultiplier = 2.0f;
	public AudioClip ohno;
	public AudioClip item_drop;
	public AudioClip item_move;

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
		
		if (col.relativeVelocity.magnitude > 4) {
			AudioSource.PlayClipAtPoint (item_drop, gameObject.transform.position);
		} else {
			AudioSource.PlayClipAtPoint (item_move, gameObject.transform.position);
		}
		
	}
}
