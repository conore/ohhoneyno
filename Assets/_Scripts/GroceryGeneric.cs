using UnityEngine;
using System.Collections;

public class GroceryGeneric : MonoBehaviour {

	//audio clips
	public AudioClip hitSound;
	public AudioClip breakSound;


	//protected parameter interface
	protected float _price;
	protected string _displayName;
	protected float _mass;


	//properties
	public string displayName { 
		get {
			return _displayName;
		}
	}

	public float  price { 
		get {
			return _price;
		}
	}

	public float  mass { 
		get {
			return _mass;
		}
	}

	public void Start() {
	}

	//initialization
	protected void InitializeGroceryItem() {
		Rigidbody rigidbody = this.GetComponent<Rigidbody> ();
		if (rigidbody != null) {
			print ("Setting mass to "+mass);
			rigidbody.mass = mass;
		} else {
			print ("WARNING: The grocery object does not have a rigidbody");
		}
	}


	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col) {

		AudioClip bottleSound = (col.relativeVelocity.magnitude > 4) ? hitSound : breakSound;

		AudioSource.PlayClipAtPoint (bottleSound, gameObject.transform.position);
		
	}
}