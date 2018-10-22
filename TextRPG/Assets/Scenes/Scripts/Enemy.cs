using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextRPG;

public class Enemy : Character {

    public string Description;

    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount); //Equivalent of super call
    }

    public override void Death()
    {
        base.Death();
    }

}
