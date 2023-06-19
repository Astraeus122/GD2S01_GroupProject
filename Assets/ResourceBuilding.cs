using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for resources building
public class ResourceBuilding : Building
{
    // Variables for resource stats would go here

    // Resourse building functions -- creating resources
    public override void Functionality()
    {
        // Resource building functionality
        Debug.Log("Resource Building Functionality Executed");
    }

    // Upgrade resource building
    public override void Upgrade()
    {
        // Perform the base upgrade
        base.Upgrade();

        // Add additional upgrade logic specific to resource buildings such as increasing resource production
        Debug.Log("Additional upgrade steps for resource buildings...");
    }

    // Continueously consume resources -- Apendix 2
    public override void ConsumeResources()
    {
        // Consume resources according to the level of the building
        Debug.Log("Resource Building consumed " + level * 10 + " resources for upkeep.");
    }
    public void ProduceResources()
    {
        // Implement your logic for producing resources here
        Debug.Log("Resource Building produced resources.");
    }
}
