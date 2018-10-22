﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{
    public class Bear : Enemy {

	    // Use this for initialization
	    void Start () {
            Health = 15;
            Attack = 5;
            Defence = 3;
            Gold = 20;
            Description = "This bear towers over you but it seems more curious than angry... for now";

            Inventory.Add("Bear Claw");
	    }
	
    }
}