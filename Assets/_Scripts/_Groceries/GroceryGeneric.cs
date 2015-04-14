using UnityEngine;
using System.Collections;

public class GroceryGeneric : MonoBehaviour {

	//audio clips
	public AudioClip dropSound;
	public AudioClip moveSound;
	public ScoreIndicator scoreAnim;

	//protected parameter interface
	protected float _price;
	protected string _displayName;
	protected float _mass;


	//properties
	private bool soundPlaying = false;

	public string displayName { 
		get {
			return _displayName;
		}
	}

	public float price { 
		get {
			return _price;
		}
	}

	public float  mass { 
		get {
			return _mass;
		}
	}

	//initialization
	protected void InitializeGroceryItem() {
		Rigidbody rigidbody = this.GetComponent<Rigidbody> ();
		if (rigidbody != null) {
			rigidbody.mass = mass;
		} else {
			print ("WARNING: The grocery object does not have a rigidbody");
		}
	}


	
	// Update is called once per frame
	void Update () {
	
	}

	void ShowScoreSprite(int score) {



	}

	IEnumerator OnCollisionEnter (Collision col) {

		if (col.gameObject.tag == "floor") {
			//TODO - implement a cool score idicator
			//ScoreIndicator si = Instantiate(scoreAnim, this.transform.position, Quaternion.Euler(180,0,0)) as ScoreIndicator;
		}

		if (!soundPlaying) {
			
			soundPlaying = true;

			AudioClip itemSound = (col.relativeVelocity.magnitude > 4) ? dropSound : moveSound;

			AudioSource.PlayClipAtPoint (itemSound, gameObject.transform.position);

			yield return new WaitForSeconds(0.5F);
			soundPlaying = false;
		}


		
	}
}