using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject enemyObject;

    private void Start()
    {
        Player player = playerObject.AddComponent<Player>();
        Enemy enemy = enemyObject.AddComponent<Enemy>();
        enemy.SetHealth(100); // Initialize enemy with 100 health
        enemy.SetDamage(10); // Initialize enemy with 10 damage

        Town town = Town.Instance;

        // Test player actions
        player.Attack(enemy);

        // Test building creation and addition to town
        player.Build(BuildingType.ResourceBuilding);
        player.Build(BuildingType.SoldierBuilding);

        // Check the buildings in town
        town.DisplayBuildings();
        StartWave(1);
    }

    private void StartWave(int waveNumber)
    {
        Debug.Log("Wave " + waveNumber + " started.");

        // Create some enemies for this wave
        Enemy enemy1 = enemyObject.AddComponent<Enemy>();
        enemy1.Initialize(100, 10, "Enemy 1");

        Enemy enemy2 = enemyObject.AddComponent<Enemy>();
        enemy2.Initialize(200, 20, "Enemy 2");

        // Enemies start attacking
        enemy1.Attack();
        enemy2.Attack();
    }
}
