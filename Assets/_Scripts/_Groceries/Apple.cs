using UnityEngine;
using System.Collections;

public class Apple : GroceryGeneric {

	// Use this for initialization
	void Start () {
		_displayName = "A mealy apple";
		_price = 5.0f;
		_mass = .2f;
		InitializeGroceryItem ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
