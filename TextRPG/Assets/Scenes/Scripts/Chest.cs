using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{
    public class Chest{
        public string Item { get; set; }
        public int Gold { get; set; }
        public bool Trap { get; set; }
        public bool Heal { get; set; }
        public Enemy Enemy { get; set; }

        //Initialize chest contents randomly
        public Chest()
        {
            int roll = Random.Range(0, 10);

            if (roll > 3) // positive
            {
                int posRoll = Random.Range(0, 4);
                switch (posRoll)
                {
                    case 1:
                        // ITEM
                        int itemToAdd = Random.Range(0, ItemDatabase.MyItemDatabase.Items.Count);
                        Item = ItemDatabase.MyItemDatabase.Items[itemToAdd];
                        break;
                    case 2:
                        // HEAL
                        Heal = true;
                        break;
                    default:
                        //GOLD
                        Gold = Random.Range(20, 100);
                        break;
                }
            }
            else // negative
            {
                int negRoll = Random.Range(0, 5);
                if (negRoll > 2)
                {
                    // TRAP
                    Trap = true;
                }
                else
                {
                    //ENEMY
                    Enemy = EnemyDatabase.MyEnemyDatabase.GetRandomEnemy();
                }
            }
        }
    }
}
