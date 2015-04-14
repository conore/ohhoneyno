using UnityEngine;
using System.Collections;

public class Jager : GroceryGeneric {
	
	// Use this for initialization
	void Awake () {
		_displayName = "Disgusting Eurpoean Liquor!";
		_price = 35.0f;
		_mass = 2.0f;
		InitializeGroceryItem ();
	}
	
	// Update is called once per frame
	void Update () {
		CurseIfDropped ();
	}
}