using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TextRPG
{
    public class Player : Character
    {
        public int Floor { get; set; }
        public Room Room { get; set; }

        public World world;

        [SerializeField]
        Encounter encounter;

        // Use this for initialization
        void Start()
        {
            Floor = 0;
            Health = 30;
            Attack = 10;
            Defence = 0;
            Speed = 5;
            Inventory = new List<string>();
            RoomIndex = new Vector2(2, 2); //TODO change start location, randomize?
            Room = world.Dungeon[(int)RoomIndex.x, (int)RoomIndex.y];

            //Initialize room and UI
            Room.Empty = true;
            Room.Enemy = null; //TODO check that this fixes the issue of spawning into an enemy
            encounter.ResetControls();
            UIController.OnPlayerStatChange();
            UIController.OnPlayerInventoryChange();

        }

        public void Move(int direction)
        {
            // Prevent movement if there is an enemy
            if(this.Room.Enemy)
            {
                return;
            }

            //Logic for movement
            if( direction == 0 && RoomIndex.y >0) // North movement
            {
                RoomIndex -= Vector2.up;
                GameJournal.Instance.Log(SceneManager.Instance.messages.BuildMessage(JournalMessages.MessageTypes.MoveNorth));

            }
            else if (direction == 1 && RoomIndex.x < world.Dungeon.GetLength(0) -1) // East movement
            {
                RoomIndex += Vector2.right;
                GameJournal.Instance.Log(SceneManager.Instance.messages.BuildMessage(JournalMessages.MessageTypes.MoveEast));
            }
            else if (direction == 2 && RoomIndex.y < world.Dungeon.GetLength(1) -1) // South movement
            {
                RoomIndex -= Vector2.down;
                GameJournal.Instance.Log(SceneManager.Instance.messages.BuildMessage(JournalMessages.MessageTypes.MoveSouth));
            }
            else if (direction == 3 && RoomIndex.x > 0) // West movement
            {
                RoomIndex += Vector2.left;
                GameJournal.Instance.Log(SceneManager.Instance.messages.BuildMessage(JournalMessages.MessageTypes.MoveWest));
            }
            else
            {
                GameJournal.Instance.Log(SceneManager.Instance.messages.BuildMessage(JournalMessages.MessageTypes.CannotMove));
            }

            //If we did actually move
            if(this.Room.RoomIndex != RoomIndex)
            {
                //Assign new room
                this.Room = world.Dungeon[(int)RoomIndex.x, (int)RoomIndex.y];

                // Investigate Room
                InvestigateRoom();
            }

            Debug.Log("Location is: " + (int)RoomIndex.x + " " + (int)RoomIndex.y); //TODO remove player location statement
        }

        public void InvestigateRoom()
        {
            encounter.ResetControls();
            //Check properties of new room
            if (this.Room.Empty)
            {
                GameJournal.Instance.Log(SceneManager.Instance.messages.BuildMessage(JournalMessages.MessageTypes.EncounterEmpty));
            }
            else if (this.Room.Chest != null)
            {
                encounter.ChestControls();
                GameJournal.Instance.Log(SceneManager.Instance.messages.BuildMessage(JournalMessages.MessageTypes.EncounterChest));
            }
            else if (this.Room.Enemy != null)
            {
                encounter.CombatControls();
                GameJournal.Instance.Log(SceneManager.Instance.messages.BuildMessage(JournalMessages.MessageTypes.EncounterEnemy, "", Room.Enemy.Description));

            }
            else if (this.Room.Exit == true)
            {
                encounter.ExitControls();
                GameJournal.Instance.Log(SceneManager.Instance.messages.BuildMessage(JournalMessages.MessageTypes.EncounterExit));
            }
        }

        public void AddItem(string item)
        {
            Inventory.Add(item);
            UIController.OnPlayerInventoryChange();
        }

        public override void TakeDamage(int amount)
        {
            base.TakeDamage(amount);
            UIController.OnPlayerStatChange();
        }

        public override void Death()
        {
            base.Death();
        }


    }

}