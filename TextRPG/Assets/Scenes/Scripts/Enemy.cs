using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{
    public abstract class Enemy : Character
    {

        public string Description;
        public string Name;
        public string EncounterText;

        public override void TakeDamage(int amount)
        {
            base.TakeDamage(amount); //Equivalent of super call
            UIController.OnEnemyUpdate();
        }

        public override void Death()
        {
            base.Death();
            Encounter.OnEnemyDeath();
        }

        public abstract void Strike();
    }
}
