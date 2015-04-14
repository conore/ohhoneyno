using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour {

	public AudioClip floorCollide;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col) {
		if (col.relativeVelocity.magnitude > 4) {
			AudioSource.PlayClipAtPoint (floorCollide, gameObject.transform.position);
		}
	}
}
