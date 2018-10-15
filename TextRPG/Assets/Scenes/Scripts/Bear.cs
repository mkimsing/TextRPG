using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{
    public class Bear : Enemy {

	    // Use this for initialization
	    void Start () {
            Health = 10;
            Attack = 5;
            Defence = 3;
            Gold = 20;

            Inventory.Add("Bear Claw");
	    }
	
    }
}