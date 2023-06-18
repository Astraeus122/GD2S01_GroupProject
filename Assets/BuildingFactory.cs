using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


// Class to create buildings
public class BuildingFactory
{
    // Create buildings
    public Building CreateBuilding(GameObject buildingObject, BuildingType type)
    {
        Building building = null;

        // Different types of buildings -- resource, soldier, defence
        switch (type)
        {
            case BuildingType.ResourceBuilding:
                building = buildingObject.AddComponent<ResourceBuilding>();
                break;
            case BuildingType.SoldierBuilding:
                building = buildingObject.AddComponent<SoldierBuilding>();
                break;
            // Add more cases as per your building types...
            default:
                throw new Exception("Invalid building type");
        }

        return building;
    }
}


