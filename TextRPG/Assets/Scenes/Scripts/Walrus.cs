using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Walrus : Enemy {

	// Use this for initialization
	void Start () {
        Health = 20;
        Attack = 2;
        Defence = 3;
        Gold = 35;

        Inventory.Add("Walrus Tusk");
	}
	
}
