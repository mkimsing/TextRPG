using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TextRPG
{
    public class Player : Character
    {
        public int Floor { get; set; }
        public Room Room { get; set; }

        [SerializeField]
        World world;

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
            RoomIndex = new Vector2(2, 2); //TODO change start location
            Room = world.Dungeon[(int)RoomIndex.x, (int)RoomIndex.y];
            Room.Empty = true;

        }

        public void Move(int direction)
        {
            // Prevent movement if there is an enemy
            if(this.Room.Enemy)
            {
                return; //TODO if initial room is enemy, movement is prevented since room is flagged as empty as empty and enemy
            }

            //Logic for movement
            if( direction == 0 && RoomIndex.y >0) // North movement
            {
                RoomIndex -= Vector2.up;
                GameJournal.Instance.Log(JournalMessages.MoveNorth);
            }
            else if (direction == 1 && RoomIndex.x < world.Dungeon.GetLength(0) -1) // East movement
            {
                RoomIndex += Vector2.right;
                GameJournal.Instance.Log(JournalMessages.MoveEast);
            }
            else if (direction == 2 && RoomIndex.y < world.Dungeon.GetLength(1) -1) // South movement
            {
                RoomIndex -= Vector2.down;
                GameJournal.Instance.Log(JournalMessages.MoveSouth);
            }
            else if (direction == 3 && RoomIndex.x > 0) // West movement
            {
                RoomIndex += Vector2.left;
                GameJournal.Instance.Log(JournalMessages.MoveWest);
            }
            else
            {
                GameJournal.Instance.Log(JournalMessages.CannotMove);
            }

            //If we did actually move
            if(this.Room.RoomIndex != RoomIndex)
            {
                //Assign new room
                this.Room = world.Dungeon[(int)RoomIndex.x, (int)RoomIndex.y];

                // Investigate Room
                InvestigateRoom();
            }
        }

        public void InvestigateRoom()
        {
            encounter.ResetControls();
            //Check properties of new room
            if (this.Room.Empty)
            {
                GameJournal.Instance.Log(JournalMessages.EncounterEmpty);
            }
            else if (this.Room.Chest != null)
            {
                GameJournal.Instance.Log(JournalMessages.EncounterChest);
            }
            else if (this.Room.Enemy != null)
            {
                GameJournal.Instance.Log(JournalMessages.EncounterEnemy1 + Room.Enemy.Description + JournalMessages.EncounterEnemy2);
                encounter.CombatControls();
                
            }
            else if (this.Room.Exit == true)
            {
                GameJournal.Instance.Log(JournalMessages.EncounterExit);
            }
        }

        public void AddItem(string item)
        {
            Inventory.Add(item);
        }

        public override void TakeDamage(int amount)
        {
            base.TakeDamage(amount);
            Debug.Log("Player's TakeDamage");
        }

        public override void Death()
        {
            base.Death();
        }
    }

}