using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Manages logic for actions when encountering objects/items/enemies in the dungeon */
namespace TextRPG
{ 
    public class Encounter : MonoBehaviour {

        public Enemy enemy { get; set; }
        [SerializeField]
        Player player;

        [SerializeField]
        Button[] dynamicControls;

        //Disable all controls
        public void ResetControls()
        {
            foreach (Button button in dynamicControls)
            {
                button.interactable = false;
            }
        }

        //Enable combat related controls
        public void CombatControls()
        {
            this.enemy = player.Room.Enemy;
            dynamicControls[0].interactable = true;
            dynamicControls[1].interactable = true;
        }

        //Enable chest/item related controls
        public void ChestControls()
        {
            dynamicControls[2].interactable = true;
        }

        //Enable exit floor controls
        public void ExitControls()
        {
            dynamicControls[3].interactable = true;
        }

        public void Attack()
        {
            int playerAttackDamage = (int)(Random.value * (player.Attack - enemy.Defence));
            int enemyAttackDamage = (int)(Random.value * (enemy.Attack - player.Defence));
            enemy.TakeDamage(playerAttackDamage);
            GameJournal.Instance.Log(JournalMessages.Attack + playerAttackDamage + JournalMessages.Damage);
            //TODO if dmg kills enemy, do not allow the enemy to retaliate
            player.TakeDamage(enemyAttackDamage);
            GameJournal.Instance.Log("<color = #cc3300>" + JournalMessages.Retaliate + enemyAttackDamage + JournalMessages.Damage + "</color>");

            GameJournal.Instance.Log("<color=#59ffa1>The enemy retaliated, dealing <b>" + enemyAttackDamage + "</b> damage!</color>");
        }

        public void Flee()
        {
            int enemyAttackDamage = (int)(Random.value * (enemy.Attack - player.Defence));
            float playerRoll = Random.value;
            float enemyRoll = Random.value;

            GameJournal.Instance.Log("<color = #660066>" + JournalMessages.FleeAttempt + "</color>");
            //GameJournal.Instance.Log(JournalMessages.Instance.ColorMessage()

            if (player.Speed * playerRoll > enemyRoll * enemy.Speed) //Successful escape
            {
                GameJournal.Instance.Log("<color = #666699>" + JournalMessages.FleeSuccess + enemyAttackDamage + JournalMessages.Damage + "</color>" );
                player.Room.Enemy = null; // Remove the enemy
                GameJournal.Instance.Log(JournalMessages.FleeFlavor);
            }
            else // Failed escape
            {
                GameJournal.Instance.Log(JournalMessages.FleeFail + enemyAttackDamage + JournalMessages.Damage);
            }

                player.TakeDamage(enemyAttackDamage);

            player.InvestigateRoom();
        }
    }
}