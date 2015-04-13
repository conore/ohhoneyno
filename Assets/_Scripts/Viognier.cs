using UnityEngine;
using System.Collections;

public class Viognier : GroceryGeneric {

	// Use this for initialization
	void Start () {
		_displayName = "A gamey Viognier";
		_price = 20.0f;
		_mass = .4f;
		InitializeGroceryItem ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
