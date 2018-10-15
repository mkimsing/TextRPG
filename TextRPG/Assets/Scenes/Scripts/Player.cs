using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TextRPG
{
    public class Player : Character
    {
        public int Floor { get; set; }

        // Use this for initialization
        void Start()
        {
            Floor = 0;
            Health = 30;
            Attack = 10;
            Defence = 5;
            Inventory = new List<string>();
            RoomIndex = new Vector2(2, 2); //TODO change start location
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