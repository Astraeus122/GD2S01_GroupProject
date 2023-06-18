using UnityEngine;
using UnityEngine.UI;


// Class to display player health
public class HealthDisplay : MonoBehaviour
{
    public Player player; // Set this in the inspector
    public Text healthText; // Set this in the inspector

    // Update Health
    private void Awake()
    {
        player.OnHealthChanged.AddListener(UpdateHealthDisplay);
    }

    // Display Health
    private void UpdateHealthDisplay(int newHealth)
    {
        healthText.text = "Health: " + newHealth;
    }
}
