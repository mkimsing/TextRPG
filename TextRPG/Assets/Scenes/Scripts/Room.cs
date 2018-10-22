using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{
    public class Room
    {
        public Chest Chest { get; set; }
        public Enemy Enemy { get; set; }
        public bool Exit { get; set; }
        public bool Empty { get; set; }
        public Vector2 RoomIndex { get; set; }

        // Generate random room
        public Room()
        {
            int roll = Random.Range(0, 30);
            if (roll > 0 && roll < 6) // Enemy 0 - 6
            {
                Enemy = EnemyDatabase.MyEnemyDatabase.GetRandomEnemy();
                Enemy.RoomIndex = this.RoomIndex;
            }
            else if(roll > 6 && roll < 11)
            {
                Chest = new Chest();
            }
            else
            {
                Empty = true;
            }
        }

        //Generate specific room
        public Room(Chest chest, Enemy enemy, bool exit, bool empty)
        {
            Chest = chest;
            Enemy = enemy;
            Exit = exit;
            Empty = empty;
        }

    }
}
