using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{
    public class World : MonoBehaviour
    {
        public Room[,] Dungeon { get; set; }
        public Vector2Int Grid = new Vector2Int(8,8); // Initialized in engine editor

        private void Awake()
        {
            Dungeon = new Room[Grid.x,Grid.y ];
        }

        public void GenerateFloor()
        {
            for (int x = 0; x < Grid.x; x++)
            {
                for (int y = 0; y < Grid.y; y++)
                {
                    Dungeon[x, y] = new Room();
                    Dungeon[x, y].RoomIndex = new Vector2(x, y);
                }
            }

            Vector2Int exitLocation = new Vector2Int(Random.Range(0, Grid.x), Random.Range(0, Grid.y));
            Dungeon[exitLocation.x, exitLocation.y].Exit = true;
            Dungeon[exitLocation.x, exitLocation.y].Empty = false;
        }
    }
}

