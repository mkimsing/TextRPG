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
            this.enemy = CombatManager.Instance.MakeEnemy(SceneManager.Instance.player.Room.Enemy);
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

        public void ExitFloor()
        {
            StartCoroutine(SceneManager.Instance.player.world.GenerateFloor());
            SceneManager.Instance.player.Floor += 1;
            GameJournal.Instance.Log(SceneManager.Instance.messages.BuildMessage(JournalMessages.MessageTypes.ExitFloor,
                SceneManager.Instance.player.Floor.ToString()));
        }

        public void Loot()
        {
            SceneManager.Instance.player.AddItem(this.enemy.Inventory[0]);
            SceneManager.Instance.player.Gold += this.enemy.Gold;
            GameJournal.Instance.Log(SceneManager.Instance.messages.BuildMessage(JournalMessages.MessageTypes.Loot, 
                this.enemy.Gold.ToString(), this.enemy.Name, this.enemy.Inventory[0]));

            CombatManager.Instance.EndCombat(); // Reset combat manager

            SceneManager.Instance.player.Room.Enemy = null;
            SceneManager.Instance.player.Room.Empty = true;
            SceneManager.Instance.player.InvestigateRoom();
        }

        public void OpenChest()
        {
            Chest chest = SceneManager.Instance.player.Room.Chest;
            if(chest.Trap)
            {
                SceneManager.Instance.player.TakeDamage(chest.DamageAmount);
                GameJournal.Instance.Log(SceneManager.Instance.messages.BuildMessage(JournalMessages.MessageTypes.ChestTrap, chest.DamageAmount.ToString()));
            }
            else if(chest.Heal)
            {
                SceneManager.Instance.player.TakeDamage(-chest.HealAmount);
                GameJournal.Instance.Log(SceneManager.Instance.messages.BuildMessage(JournalMessages.MessageTypes.ChestHeal, chest.HealAmount.ToString()));
            }
            else if (chest.Enemy)
            {
                SceneManager.Instance.player.Room.Enemy = chest.Enemy;
                GameJournal.Instance.Log(SceneManager.Instance.messages.BuildMessage(JournalMessages.MessageTypes.ChestEnemy));

                SceneManager.Instance.player.Room.Chest = null; //Remove chest here since investigating to 'discover' chest enemy
                SceneManager.Instance.player.InvestigateRoom();
            }
            else if (chest.GoldAmount > 0)
            {
                SceneManager.Instance.player.Gold += chest.GoldAmount;
                GameJournal.Instance.Log(SceneManager.Instance.messages.BuildMessage(JournalMessages.MessageTypes.ChestGold, chest.GoldAmount.ToString()));
            }
            else if(chest.Item != null)
            {
                SceneManager.Instance.player.AddItem(chest.Item);
                GameJournal.Instance.Log(SceneManager.Instance.messages.BuildMessage(JournalMessages.MessageTypes.ChestItem,"", chest.Item));
            }

            SceneManager.Instance.player.Room.Chest = null; // Remove chest
            dynamicControls[2].interactable = false; // Disable loot button

        }
    }
}