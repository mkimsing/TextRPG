using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TextRPG {
    public class JournalMessages : MonoBehaviour {

        public static JournalMessages Instance { get; set; }

        void Awake()
        {
            //Ensure singleton
            if (Instance != null && Instance != this)
                Destroy(this.gameObject);
            else
                Instance = this;
        }


        //Generic endings
        public const string Damage = " damage!";

        //Movement messages
        public const string MoveNorth = "You move north";
        public const string MoveEast = "You move east";
        public const string MoveSouth = "You move south";
        public const string MoveWest = "You move west";
        public const string CannotMove = "There is nothing in that direction. You cannot move that way.";

        //Encounter messsages
        public const string EncounterEmpty = "You look around and find that this room is empty.";
        public const string EncounterChest = " You see a chest in the center of the room. What would you like to do?";
        public const string EncounterExit = @"You see a stairway in the middle of the room. It seems to head down into the next floor.
                \n What would you like to do";
        public const string EncounterEnemy1 = "You encounter ";
        public const string EncounterEnemy2 = "! \n What would you like to do?";

        //Combat messages
        public const string Attack = "You strike, dealing ";
        public const string AttackColor = "<color = #6699ff>";

        public const string Retaliate = " The enemy fights back, dealing ";
        public const string RetaliateColor = "<color = #cc3300>";

        //Flee messages
        public const string FleeAttempt = "You attempt to flee...";
        public const string FleeAttemptColor = "<color = #660066>";
        public const string FleeSuccess = "<color = #666699> You manage to escape, but the monster strikes you as you flee for </color>";
        public const string FleeFlavor = "<color = #666699> You hide in the shadows of the room. Eventually the monster loses interest and wanders off</color>";
        public const string FleeFail = "<color = #ff9933> You try to escape but are unable to escape... The monster attacks you for </color>";

        public string ColorMessage(string color, string message)
        {
            string msg = color + message + "</color>";
            return msg;
        }
    }
}
