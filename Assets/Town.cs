using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Town : MonoBehaviour
{
    // Singleton instance
    private static Town _instance;

    // List of buildings
    private List<Building> _buildings = new List<Building>();

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

    // Methods to add/remove buildings
    public void AddBuilding(Building building)
    {
        _buildings.Add(building);
        Debug.Log("Building Added");
    }

    public void RemoveBuilding(Building building)
    {
        _buildings.Remove(building);
        Debug.Log("Building Removed");
    }

    public void DisplayBuildings()
    {
        foreach (var building in _buildings)
        {
            Debug.Log(building.ToString());
        }
    }
}