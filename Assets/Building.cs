using System;
using UnityEngine;

public enum BuildingType
{
    ResourceBuilding, // Formerly Farm
    SoldierBuilding,  // Formerly Factory
    CustomBuilding1,  // Any other custom buildings
    CustomBuilding2
    // Add more building types as needed...
}

public class Building : MonoBehaviour
{
    protected Town town; // The town this building belongs to
    public BuildingType buildingType;
    public int level = 1;

    public virtual void Upgrade()
    {
        level += 1;
        Debug.Log("Building upgraded to level " + level);

        // Add code here to change the building's behavior based on its level
    }

    public virtual void ConsumeResources()
    {
        Debug.Log("Default resource consumption");
    }

    public void SetTown(Town town)
    {
        this.town = town;
    }

    public virtual void Functionality()
    {
        if (town != null)
        {
            // Try to produce unit
            try
            {
                switch (buildingType)
                {
                    case BuildingType.ResourceBuilding:
                        // ResourceBuilding logic...
                        Debug.Log("Resource Unit Created");
                        break;
                    case BuildingType.SoldierBuilding:
                        // SoldierBuilding logic...
                        Debug.Log("Soldier Unit Created");
                        break;
                    case BuildingType.CustomBuilding1:
                        // CustomBuilding1 logic...
                        Debug.Log("Custom Building 1 Functionality Executed");
                        break;
                    case BuildingType.CustomBuilding2:
                        // CustomBuilding2 logic...
                        Debug.Log("Custom Building 2 Functionality Executed");
                        break;
                    // Add more cases for each building type...
                    default:
                        throw new Exception("Invalid building type");
                }
            }
            catch (Exception e)
            {
                // Log the exception for debugging purposes
                Debug.LogError(e);
            }
        }
        else
        {
            Debug.LogError("Town is null");
        }
    }
}