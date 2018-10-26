using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TextRPG;

public class UIController : MonoBehaviour {

    [SerializeField]
    Text playerStatsText, playerInventoryText, enemyStatsText;

    public delegate void OnPlayerUpdateHandler();
    public static OnPlayerUpdateHandler OnPlayerStatChange;
    public static OnPlayerUpdateHandler OnPlayerInventoryChange;

    public delegate void OnEnemyUpdateHandler();
    public static OnEnemyUpdateHandler OnEnemyUpdate;

    // Use this for initialization
    void Start()
    {
        OnPlayerStatChange += UpdatePlayerStats;
        //OnPlayerStatChange += UpdatePlayerInventory; // TODO implement stat changes on items
        OnPlayerInventoryChange += UpdatePlayerInventory;
        OnEnemyUpdate += UpdateEnemyStats;

        //Initialize header for inventory
        playerInventoryText.text = "Items: ";
    }

    public void UpdatePlayerStats()
    {
        playerStatsText.text = string.Format("Player Stats:  {0} HP, {1} Attack, {2} Defence, {3} gold",
            SceneManager.Instance.player.Health, SceneManager.Instance.player.Attack, SceneManager.Instance.player.Defence, SceneManager.Instance.player.Gold);
    }

    public void UpdatePlayerInventory()
    {
        playerInventoryText.text = "Items: ";
        foreach (string item in SceneManager.Instance.player.Inventory)
        {
            playerInventoryText.text += item + " / ";
        }
    }

    public void UpdateEnemyStats()
    {
        if(CombatManager.Instance.EnemyInCombat != null)
        {
            enemyStatsText.text= string.Format("{0} : {1} HP, {2} Attack, {3} Defence, {4} gold",
            CombatManager.Instance.EnemyInCombat.Name, CombatManager.Instance.EnemyInCombat.Health,
            CombatManager.Instance.EnemyInCombat.Attack, CombatManager.Instance.EnemyInCombat.Defence, CombatManager.Instance.EnemyInCombat.Gold);
        }
        else
        {
           enemyStatsText.text = "Not Currently In Combat";
        }
    }
}
