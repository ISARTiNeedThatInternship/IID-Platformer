using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth; // Remet la valeur de la vie à la vie maximale
        healthBar.SetMaxHealth(maxHealth); // Effectue ce changement sur la barre de vie
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage; // Retirer x dégâts
        healthBar.SetHealth(currentHealth); // Changer la valeur du slider
    }
}