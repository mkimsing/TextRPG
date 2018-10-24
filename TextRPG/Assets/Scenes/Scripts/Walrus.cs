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
            Speed = 3;
            Name = "Walrus";
            Description = "a large walrus with sharp tusks";

            Inventory.Add("Walrus Tusk");
        }

        public override void Strike()
        {
            int enemyAttackDamage = (int)(Random.value * (Attack - SceneManager.Instance.player.Defence));
            GameJournal.Instance.Log(SceneManager.Instance.messages.BuildMessage(JournalMessages.MessageTypes.Retaliate, enemyAttackDamage.ToString()));
            SceneManager.Instance.player.TakeDamage(enemyAttackDamage);
        }

    }
}
