using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TextRPG {
    public class JournalMessages : MonoBehaviour
    {

        public enum MessageTypes
        {
            MoveNorth,
            MoveEast,
            MoveWest,
            MoveSouth,
            CannotMove,
            EncounterEmpty,
            EncounterChest,
            EncounterExit,
            EncounterEnemy,
            Attack,
            Retaliate,
            FleeAttempt,
            FleeSuccess,
            FleeFail,
            ExitFloor,
            Loot,
            ChestTrap,
            ChestHeal,
            ChestEnemy,
            ChestGold,
            ChestItem
        }

        //Markup
        public const string EndColor = "</color>";
        public const string Bold = "<b>";
        public const string EndBold = "</b>";

        //Generic texts
        public const string DamageText = " damage!";
        public const string HPText = " health points!";
        public const string GoldText = " gold!";

        //Markup for generic Colors
        public const string DealDamageColor = "<color=#0033cc>"; //Royal blue
        public const string TakeDamageColor = "<color=#ff3300>"; //Red-orange
        public const string GoldColor = "<color=#ffcc66>"; //Gold
        public const string ItemColor = "<color=#9966ff>"; //Purple
        public const string EnemyColor = "<color=#ccffff>"; //Blue-white (ice)
        public const string HealColor = "<color=#00ff00>"; //Green

        //Movement messages
        public const string MoveNorth = "You move north";
        public const string MoveEast = "You move east";
        public const string MoveSouth = "You move south";
        public const string MoveWest = "You move west";
        public const string CannotMove = "There is nothing in that direction. You cannot move that way.";
        public const string MoveColor = "<color=##999966>"; // Olive
        public const string CannotMoveColor = "<color=#ffff99>"; // Cream-Yellow

        //Encounter messsages
        public const string EncounterEmpty = "You look around and find that this room is empty.";
        public const string EncounterChest = " You see a chest in the center of the room. What would you like to do?";
        public const string EncounterChestColor = "<color=##66ffb3>"; // Teal-green
        public const string EncounterExit = @"You see a stairway in the middle of the room. It seems to head down into the next floor.
                What would you like to do?";
        public const string EncounterEnemy1 = "You encounter ";
        public const string EncounterEnemy2 = "! \n What would you like to do?";
        public const string ExitFloor = "You take the stairway down to the next floor. According to your count, this is floor: ";

        //Combat messages
        public const string Attack = "You strike, dealing ";
        public const string AttackColor = "<color=#004d80>"; //Navy blue

        public const string Retaliate = " The enemy fights back, dealing ";
        public const string RetaliateColor = "<color=#cc3300>"; //Orange-red

        //Flee messages
        public const string FleeAttempt = "You attempt to flee...";
        public const string FleeAttemptColor = "<color=#660033>"; //Burgandy

        public const string FleeSuccess = "You manage to escape, but the monster strikes you as you flee for ";
        public const string FleeSuccessColor = "<color=#666699>"; //Purple
        public const string FleeFlavor = "You hide in the shadows of the room. Eventually the monster loses interest and wanders off";
        public const string FleeFlavorColor = "<color=#666699>"; //Dark Blue-Gray-Purple

        public const string FleeFail = "You try to escape but are unable to escape... The monster attacks you for ";
        public const string FleeFailColor = "<color=#ff9933>"; //Orange

        //Loot Message
        public const string Loot1 = "You've slain the ";
        public const string Loot2 = "\n You search the carcass and discover ";

        //Chest Result Messages
        public const string ChestTrap = "The chest was a trap! You take ";
        public const string ChestHeal = "A soothing light bursts from the chest. You are healed for ";
        public const string ChestGold = "The chest contains gold! You collect: ";
        public const string ChestItem = "The chest contains some kind of item.... You inspect it and discover a: ";
        public const string ChestEnemy = "An enemy was hiding in the chest! You leap back and prepare for combat...";
        public const string ChestEnemyColor = "<color=#996600>"; //Mustard Brown

        /* Builds formatted, colored strings  for journal events/ messages
         * 
         */
        public string BuildMessage (MessageTypes messageType, string value = "", string description = "", string description2 ="")
        {
            string msg;
            string BoldValue = Bold + value + EndBold;
            switch(messageType)
            {
                case MessageTypes.MoveNorth:
                    msg = MoveColor + MoveNorth + EndColor;
                    break;
                case MessageTypes.MoveEast:
                    msg = MoveColor + MoveEast + EndColor;
                    break;
                case MessageTypes.MoveWest:
                    msg = MoveColor + MoveWest + EndColor;
                    break;
                case MessageTypes.MoveSouth:
                    msg = MoveColor + MoveSouth + EndColor;
                    break;
                case MessageTypes.CannotMove:
                    msg = CannotMoveColor + CannotMove + EndColor;
                    break;
                // =============================================================
                case MessageTypes.EncounterEmpty:
                    msg = EncounterEmpty;
                    break;
                case MessageTypes.EncounterChest:
                    msg = EncounterChestColor + EncounterChest + EndColor;
                    break;
                case MessageTypes.EncounterExit:
                    msg = EncounterExit;
                    break;
                case MessageTypes.EncounterEnemy:
                    msg = EncounterEnemy1 + EnemyColor + description + EndColor + EncounterEnemy2;
                    break;
                // ===============================================================
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
                case MessageTypes.ExitFloor:
                    msg = ExitFloor + BoldValue;
                    break;
                //==========================================================================================================
                case MessageTypes.Loot:
                    msg = Loot1 + EnemyColor + description + EndColor + Loot2 + ItemColor + description2 + EndColor;
                    msg += " and " + GoldColor + BoldValue + EndColor + GoldText;
                    break;
                case MessageTypes.ChestTrap:
                    msg = ChestTrap + TakeDamageColor + BoldValue + EndColor + DamageText;
                    break;
                case MessageTypes.ChestHeal:
                    msg = ChestHeal + HealColor + BoldValue + EndColor + HPText;
                    break;
                case MessageTypes.ChestEnemy:
                    msg = ChestEnemyColor + ChestEnemy + EndColor;
                    break;
                case MessageTypes.ChestGold:
                    msg = ChestGold + GoldColor + BoldValue + EndColor + GoldText;
                    break;
                case MessageTypes.ChestItem:
                    msg = ChestItem + ItemColor + description + EndColor;
                    break;
                default:
                    msg = "???";
                    break;
            }
            return msg;
        }
    }
}
