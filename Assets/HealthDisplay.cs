using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public Player player; // Set this in the inspector
    public Text healthText; // Set this in the inspector

    private void Awake()
    {
        player.OnHealthChanged.AddListener(UpdateHealthDisplay);
    }

    private void UpdateHealthDisplay(int newHealth)
    {
        healthText.text = "Health: " + newHealth;
    }
}
