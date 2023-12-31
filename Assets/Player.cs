using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


// Player class
public class Player : MonoBehaviour
{
    // Player stats
    private int health;
    private int gold;

    [System.Serializable]
    public class HealthEvent : UnityEvent<int> { }

    public HealthEvent OnHealthChanged;
    public BuildingFactory buildingFactory;

    private void Awake()
    {
        // Initialize the BuildingFactory instance
        buildingFactory = new BuildingFactory();
    }

    // Player actions
    public void Attack(Enemy enemy)
    {
        // Attack functionality
        Debug.Log("Soldiers Attacking");
        enemy.Defeated();  // Call the enemy's Defeated method here
    }

    // Player create a new building
    public void Build(BuildingType type)
    {
        GameObject buildingObject = new GameObject();
        Building newBuilding = buildingFactory.CreateBuilding(buildingObject, type);
        Town.Instance.AddBuilding(newBuilding);
        Debug.Log("Player Building");
    }

    // Update player health
    public void UpdateHealth(int amount)
    {
        health += amount;
        if (OnHealthChanged != null)
            OnHealthChanged.Invoke(health);
    }
}
