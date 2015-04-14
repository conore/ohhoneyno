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
	public AudioClip[] curse;
	
	//properties
	private bool soundPlaying = false;
	private bool itemDropped = false;

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

	protected void CurseIfDropped () {

		if (!itemDropped) {

			Rigidbody rigidbody = this.GetComponent<Rigidbody> ();
			GameObject bag = GameObject.FindGameObjectWithTag ("bag");
			Vector3 groceryPosition = new Vector3 (0, 0, 0);

			if (GetComponent<Rigidbody> () != null) {

				groceryPosition = rigidbody.transform.position;

				if (bag != null && groceryPosition.y < 0) {
					itemDropped = true;
					AudioSource.PlayClipAtPoint (curse [Random.Range (0, curse.Length)], groceryPosition);
				}
			}
		}
	}

	IEnumerator OnCollisionEnter (Collision col) {

		if (col.gameObject.tag == "floor") {
			//TODO - implement a cool score idicator
			//ScoreIndicator si = Instantiate(scoreAnim, this.transform.position, Quaternion.Euler(180,0,0)) as ScoreIndicator;
		}

		if (!soundPlaying && col.relativeVelocity.magnitude > 1) {
			
			soundPlaying = true;

			AudioClip itemSound = (col.relativeVelocity.magnitude > 4) ? dropSound : moveSound;

			AudioSource.PlayClipAtPoint (itemSound, gameObject.transform.position);

			yield return new WaitForSeconds(0.5F);
			soundPlaying = false;
		}


		
	}
}