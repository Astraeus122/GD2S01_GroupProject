using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBuilding : Building
{
    // Variables for soldier stats such as attack, defense, etc. would go here

    public override void Functionality()
    {
        // Soldier building functionality
        Debug.Log("Soldier Building Functionality Executed");
    }

    public override void Upgrade()
    {
        // Perform the base upgrade
        base.Upgrade();

        // Add additional upgrade logic specific to resource buildings such as increasing soldier production
        Debug.Log("Additional upgrade steps for soldier buildings...");
    }

    public override void ConsumeResources()
    {
        // Consume resources according to the level of the building
        Debug.Log("Soldier Building consumed " + level * 10 + " resources for upkeep.");
    }
}
