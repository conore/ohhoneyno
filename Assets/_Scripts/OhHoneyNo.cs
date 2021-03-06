﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class OhHoneyNo : MonoBehaviour {

	//sigleton
	public static OhHoneyNo S;

	public GroceryGeneric[] groceryTypes;
	public List<GroceryGeneric> groceries;

	public float spawnHeight = 4.0f;

	// UI Elements
	public Text costLabel;
	public Text itemLabel;
	public Text embarrassmentLabel;

	public bool containerBroke = false;


	// Use this for initialization
	void Awake () {
		S = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {

			GroceryGeneric grocery;
			grocery = SpawnGroceryItem();

			groceries.Add(grocery);

		}
 	}

	GroceryGeneric SpawnGroceryItem() {

		//determine spawn point (heiht above bag)
		Vector3 spawnPoint = new Vector3(0,0,0);
		GameObject bag = GameObject.FindGameObjectWithTag ("bag");
		
		if (bag != null) {
			spawnPoint = bag.transform.position;
			spawnPoint.y += spawnHeight;
			
			//add some randomness to the spawn point
			float rand = Random.Range(-.5f,.5f);
			
			spawnPoint.x -= rand;
			spawnPoint.z += rand;
			
		}

		//pick a product
		GroceryGeneric itemType = groceryTypes[Random.Range(0,groceryTypes.Length)];

		GroceryGeneric grocery;

		grocery = GroceryGeneric.Instantiate (itemType, spawnPoint, Quaternion.identity) as GroceryGeneric;

		AddCost (grocery.price);

		itemLabel.text = grocery.displayName;

		return grocery;

	}

	public void AddCost(float cost) {
		float currCost = float.Parse (costLabel.text);
		
		currCost += cost;
		
		costLabel.text = currCost.ToString();
	}

	public void AddEmbarrassment(float embarrassment) {

		float currEmbarrassment = float.Parse (embarrassmentLabel.text);
		
		currEmbarrassment += embarrassment;
		
		embarrassmentLabel.text = currEmbarrassment.ToString();
	}
}
