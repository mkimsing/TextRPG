using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextRPG;

/*
 * Class defining the player's combat behavior and abilities
 */
public class PlayerCombatBehavior : MonoBehaviour {

    public void Attack()
    {
        int playerAttackDamage = (int)(Random.value * (SceneManager.Instance.player.Attack - CombatManager.Instance.EnemyInCombat.Defence));

        //Attack
        GameJournal.Instance.Log(SceneManager.Instance.messages.BuildMessage(JournalMessages.MessageTypes.Attack, playerAttackDamage.ToString()));
        CombatManager.Instance.EnemyInCombat.TakeDamage(playerAttackDamage);


        //Enemy fights back (if it exists)
        if(CombatManager.Instance.EnemyInCombat != null)
        {
            CombatManager.Instance.EnemyInCombat.Strike();
        }
        
    }

    public void Flee()
    {
        int enemyAttackDamage = (int)(Random.value * (CombatManager.Instance.EnemyInCombat.Attack - SceneManager.Instance.player.Defence));
        float playerRoll = Random.value;
        float enemyRoll = Random.value;

        GameJournal.Instance.Log(SceneManager.Instance.messages.BuildMessage(JournalMessages.MessageTypes.FleeAttempt));

        SceneManager.Instance.player.TakeDamage(enemyAttackDamage); // Deal damage regardless of flee success

        if (SceneManager.Instance.player.Speed * playerRoll > enemyRoll * CombatManager.Instance.EnemyInCombat.Speed) //Successful escape
        {
            GameJournal.Instance.Log(SceneManager.Instance.messages.BuildMessage(JournalMessages.MessageTypes.FleeSuccess, enemyAttackDamage.ToString()));
            CombatManager.Instance.EndCombat(); // Reset combat manager
            SceneManager.Instance.player.Room.Enemy = null; // Remove the enemy
            SceneManager.Instance.player.Room.Empty = true;
            SceneManager.Instance.player.InvestigateRoom();
        }
        else // Failed escape
        {
            GameJournal.Instance.Log(SceneManager.Instance.messages.BuildMessage(JournalMessages.MessageTypes.FleeFail, enemyAttackDamage.ToString()));
        }

    }
}
