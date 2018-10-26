using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextRPG;

/*
 * Stores combat instance information. Is reset after every combat
 */
public class CombatManager : MonoBehaviour {

    public Enemy EnemyInCombat;

    public static CombatManager Instance { get; private set; }
    private void Awake()
    {
        //Ensure singleton
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
        {
            Instance = this;
        }
    }
    // Create new enemy script in combat manager 
    public Enemy MakeEnemy (Enemy enemy)
    {
        Component newEnemy = gameObject.AddComponent(enemy.GetType());
        EnemyInCombat = (Enemy)newEnemy;
        return (Enemy)newEnemy ;
    }

    // Remove all enemy scripts in combat manger
    public void EndCombat()
    {
        foreach(Enemy EnemyComponent in GetComponents<Enemy>())
        {
            Destroy(EnemyComponent);
        }
        EnemyInCombat = null;
    }


}
