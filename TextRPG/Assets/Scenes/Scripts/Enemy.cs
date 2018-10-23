using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextRPG;

public class Enemy : Character {

    public string Description;
    public string Name;

    public Player player;

    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount); //Equivalent of super call
    }

    public override void Death()
    {
        base.Death();
        Encounter.OnEnemyDeath();
    }

    public void Strike()
    {
        player.TakeDamage(this.Attack);
    }

    public void Strike(int damage)
    {
        player.TakeDamage(damage);
    }

}
