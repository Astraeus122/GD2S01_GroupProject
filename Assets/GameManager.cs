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

        ResourceBuilding buildingToUpgrade = null;
        foreach (var building in Town.Instance.GetBuildings())
        {
            if (building is ResourceBuilding)
            {
                buildingToUpgrade = building as ResourceBuilding;
                break;
            }
        }

        // If a resource building was found, upgrade it
        if (buildingToUpgrade != null)
        {
            buildingToUpgrade.Upgrade();
        }
        else
        {
            Debug.LogError("No resource building found to upgrade.");
        }

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

    void Update()
    {
        // Update the time since the last consumption
        Town.Instance.timeSinceLastConsumption += Time.deltaTime;

        // If it's been more than some amount of time since the last consumption, consume resources
        if (Town.Instance.timeSinceLastConsumption >= 5f)  // Change the 5 to whatever number of seconds you want between each consumption
        {
            foreach (var building in Town.Instance.GetBuildings())
            {
                building.ConsumeResources();
            }

            // Reset the timer
            Town.Instance.timeSinceLastConsumption = 0f;
        }
    }
}
