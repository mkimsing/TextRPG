using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TextRPG {
    public class JournalMessages : MonoBehaviour
    {

        public enum MessageTypes
        {
            EncounterEmpty,
            EncounterChest,
            EncounterExit,
            EncounterEnemy,
            Attack,
            Retaliate,
            FleeAttempt,
            FleeSuccess,
            FleeFail
        }

        //Markup
        public const string EndColor = "</color>";
        public const string Bold = "<b>";
        public const string EndBold = "</b>";

        //Generic texts
        public const string DamageText = " damage!";
        public const string DealDamageColor = "<color=#0033cc>";
        public const string TakeDamageColor = "<color=#ff3300>";


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
                What would you like to do?";
        public const string EncounterEnemy1 = "You encounter ";
        public const string EncounterEnemy2 = "! \n What would you like to do?";

        //Combat messages
        public const string Attack = "You strike, dealing ";
        public const string AttackColor = "<color=#004d80>";

        public const string Retaliate = " The enemy fights back, dealing ";
        public const string RetaliateColor = "<color=#cc3300>";

        //Flee messages
        public const string FleeAttempt = "You attempt to flee...";
        public const string FleeAttemptColor = "<color=#660033>";

        public const string FleeSuccess = "You manage to escape, but the monster strikes you as you flee for ";
        public const string FleeSuccessColor = "<color=#666699>";
        public const string FleeFlavor = "You hide in the shadows of the room. Eventually the monster loses interest and wanders off";
        public const string FleeFlavorColor = "<color=#666699>";

        public const string FleeFail = "You try to escape but are unable to escape... The monster attacks you for ";
        public const string FleeFailColor = "<color=#ff9933>";

        public string BuildMessage (MessageTypes messageType, string value = "", string description = "")
        {
            string msg;
            string BoldValue = Bold + value + EndBold;
            switch(messageType)
            {
                case MessageTypes.EncounterEmpty:
                    msg = EncounterEmpty;
                    break;
                case MessageTypes.EncounterChest:
                    msg = EncounterChest;
                    break;
                case MessageTypes.EncounterExit:
                    msg = EncounterExit;
                    break;
                case MessageTypes.EncounterEnemy:
                    msg = EncounterEnemy1 + description + EncounterEnemy2;
                    break;

                case MessageTypes.Attack:
                    msg = AttackColor + Attack + EndColor; 
                    msg+= DealDamageColor + BoldValue + EndColor +  AttackColor + DamageText + EndColor;
                    break;
                case MessageTypes.Retaliate:
                    msg = RetaliateColor + Retaliate + EndColor;
                    msg+= TakeDamageColor + BoldValue + EndColor + RetaliateColor + DamageText + EndColor;
                    break;
                case MessageTypes.FleeAttempt:
                    msg = FleeAttemptColor + FleeAttempt + EndColor;
                    break;
                case MessageTypes.FleeSuccess:
                    msg = FleeSuccessColor + FleeSuccess + EndColor;
                    msg+= TakeDamageColor + BoldValue + EndColor + FleeSuccessColor + DamageText + EndColor;
                    msg += "\n" + FleeFlavorColor + FleeFlavor + EndColor;
                    break;
                case MessageTypes.FleeFail:
                    msg = FleeFailColor + FleeFail + EndColor;
                    msg+= TakeDamageColor + BoldValue + EndColor + FleeFailColor + DamageText + EndColor;
                    break;
                default:
                    msg = "???";
                    break;
            }
            return msg;
        }
    }
}
