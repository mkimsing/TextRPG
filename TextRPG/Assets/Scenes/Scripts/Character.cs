using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{
    public class Character : MonoBehaviour
    {
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Gold { get; set; }
        public int Speed { get; set; }
        public Vector2 RoomIndex { get; set; } //Coordinates for location
        public List<string> Inventory { get; set; } = new List<string>();

        public virtual void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health <= 0)
            {
                Death();
            }
        }

        public virtual void Death()
        {
            // Death behavior
        }
    }
}
