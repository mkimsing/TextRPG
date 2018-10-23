using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* 
 * Manages logic for actions when encountering objects/items/enemies in the dungeon
 * Includes most dungeon functions and actions (except movement)
 * 
 */
namespace TextRPG
{ 
    public class Encounter : MonoBehaviour {

        public Enemy enemy { get; set; }
        [SerializeField]
        Player player;

        [SerializeField]
        JournalMessages messages;

        [SerializeField]
        Button[] dynamicControls;

        public delegate void OnEnemyDeathHandler();
        public static OnEnemyDeathHandler OnEnemyDeath;

        private void Start()
        {
            OnEnemyDeath += Loot;
        }

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

            //Attack
            enemy.TakeDamage(playerAttackDamage);
            GameJournal.Instance.Log(messages.BuildMessage(JournalMessages.MessageTypes.Attack, playerAttackDamage.ToString()));
            
            //TODO if dmg kills enemy, do not allow the enemy to retaliate

            //Enemy Retaliate
            player.TakeDamage(enemyAttackDamage);
            GameJournal.Instance.Log(messages.BuildMessage(JournalMessages.MessageTypes.Retaliate, enemyAttackDamage.ToString()));
        }

        public void Flee()
        {
            int enemyAttackDamage = (int)(Random.value * (enemy.Attack - player.Defence));
            float playerRoll = Random.value;
            float enemyRoll = Random.value;

            GameJournal.Instance.Log(messages.BuildMessage(JournalMessages.MessageTypes.FleeAttempt));

            if (player.Speed * playerRoll > enemyRoll * enemy.Speed) //Successful escape
            {
                GameJournal.Instance.Log(messages.BuildMessage(JournalMessages.MessageTypes.FleeSuccess, enemyAttackDamage.ToString())); 
                player.Room.Enemy = null; // Remove the enemy
                player.Room.Empty = true;
                player.InvestigateRoom();
            }
            else // Failed escape
            {
                GameJournal.Instance.Log(messages.BuildMessage(JournalMessages.MessageTypes.FleeFail, enemyAttackDamage.ToString()));
            }
                player.TakeDamage(enemyAttackDamage);
  
        }

        public void ExitFloor()
        {
            StartCoroutine(player.world.GenerateFloor());
            player.Floor += 1;
            GameJournal.Instance.Log(messages.BuildMessage(JournalMessages.MessageTypes.ExitFloor, player.Floor.ToString()));
        }

        public void Loot()
        {
            player.AddItem(this.enemy.Inventory[0]);
            player.Gold += this.enemy.Gold;
            GameJournal.Instance.Log(messages.BuildMessage(JournalMessages.MessageTypes.Loot, 
                this.enemy.Gold.ToString(), this.enemy.Description, this.enemy.Inventory[0]));

            player.Room.Enemy = null;
            player.Room.Empty = true;
            player.InvestigateRoom();
        }

        public void OpenChest()
        {
            Chest chest = player.Room.Chest;
            if(chest.Trap)
            {
                player.TakeDamage(chest.DamageAmount);
                GameJournal.Instance.Log(messages.BuildMessage(JournalMessages.MessageTypes.ChestTrap, chest.DamageAmount.ToString()));
            }
            else if(chest.Heal)
            {
                player.TakeDamage(-chest.HealAmount);
                GameJournal.Instance.Log(messages.BuildMessage(JournalMessages.MessageTypes.ChestHeal, chest.HealAmount.ToString()));
            }
            else if (chest.Enemy)
            {
                player.Room.Enemy = chest.Enemy;
                GameJournal.Instance.Log(messages.BuildMessage(JournalMessages.MessageTypes.ChestEnemy));

                player.Room.Chest = null; //Remove chest here since investigating to 'discover' chest enemy
                player.InvestigateRoom();
            }
            else if (chest.GoldAmount > 0)
            {
                player.Gold += chest.GoldAmount;
                GameJournal.Instance.Log(messages.BuildMessage(JournalMessages.MessageTypes.ChestGold, chest.GoldAmount.ToString()));
            }
            else if(chest.Item != null)
            {
                player.AddItem(chest.Item);
                GameJournal.Instance.Log(messages.BuildMessage(JournalMessages.MessageTypes.ChestItem,"", chest.Item));
            }

            player.Room.Chest = null; // Remove chest
            dynamicControls[2].interactable = false; // Disable loot button

        }
    }
}