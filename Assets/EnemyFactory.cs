using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyFactory 
{   
    // Create enemy types
    public Enemy CreateEnemy(GameObject enemyObject, Enemy.EnemyType type)
    {
        // Init enemy class
        Enemy enemy = null;

        // Init different enemy types -- Apendix 2
        switch (type)
        {   // Init basic enemy
            case Enemy.EnemyType.BasicEnemy:
                enemy = enemyObject.AddComponent<Enemy>();
                enemy.Initialize(100, 10, "Basic Enemy");
                break;

            // Init advanced enemy
            case Enemy.EnemyType.AdvancedEnemy:
                enemy = enemyObject.AddComponent<Enemy>();
                enemy.Initialize(200, 20, "Advanced Enemy");
                break;
            // Add more cases as per your enemy types...
            default:
                throw new Exception("Invalid enemy type");
        }

        return enemy;
    }
}
