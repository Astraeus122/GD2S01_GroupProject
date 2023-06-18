using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Town Class
public class Town : MonoBehaviour
{
    // Singleton instance
    private static Town _instance;

    // List of buildings
    private List<Building> _buildings = new List<Building>();

    public float timeSinceLastConsumption = 0f;

    // Accessor for the singleton instance
    public static Town Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject townObject = new GameObject("Town");
                _instance = townObject.AddComponent<Town>();
            }
            return _instance;
        }
    }

    // Method to access the buildings
    public List<Building> GetBuildings()
    {
        return _buildings;
    }

    // Methods to add/remove buildings
    public void AddBuilding(Building building)
    {
        _buildings.Add(building);
        Debug.Log("Building Added");
    }

    // Destroy building
    public void RemoveBuilding(Building building)
    {
        _buildings.Remove(building);
        Debug.Log("Building Removed");
    }

    // Display buildings
    public void DisplayBuildings()
    {
        foreach (var building in _buildings)
        {
            Debug.Log(building.ToString());
        }
    }
}
