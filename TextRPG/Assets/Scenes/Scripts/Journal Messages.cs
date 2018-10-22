using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG {
    public class JournalMessages : MonoBehaviour {

        //Movement messages
        public const string MoveNorth = "You move north";
        public const string MoveEast = "You move east";
        public const string MoveSouth = "You move south";
        public const string MoveWest = "You move west";
        public const string CannotMove = "There is nothing in that direction. You cannot move that way.";

        //Encounter messsages
        public const string EncounterEmpty = "You look around and find that this room is empty.";
        public const string EncounterChest = "You see a chest in the center of the room. What would you like to do?";
        public const string EncounterExit = @"You see a stairway in the middle of the room. It seems to head down into the next floor.
                \n What would you like to do";
        public const string EncounterEnemy1 = "You encounter a ";
        public const string EncounterEnemy2 = "! \n What would you like to do?";
    }
}
