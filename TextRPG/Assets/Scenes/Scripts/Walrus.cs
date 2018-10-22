using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{
    public class Walrus : Enemy
    {

        // Use this for initialization
        void Start()
        {
            Health = 20;
            Attack = 2;
            Defence = 3;
            Gold = 35;
            Description = "A large walrus with sharp tusks";

            Inventory.Add("Walrus Tusk");
        }

    }
}
