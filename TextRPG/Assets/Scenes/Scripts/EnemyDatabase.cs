using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{

    public class EnemyDatabase : MonoBehaviour
    {

        public List<Enemy> Enemies { get; set; } = new List<Enemy>();
        public static EnemyDatabase MyEnemyDatabase { get; set; }

        private void Awake()
        {
            MyEnemyDatabase = this;

            foreach (Enemy enemy in GetComponents<Enemy>())
            {
                Enemies.Add(enemy);
            }
        }
    }
}
