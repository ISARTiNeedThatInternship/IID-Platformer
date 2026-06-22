using UnityEngine;
using System.Collections; // Permet de créer des coroutines, qui permettent de marquer des pauses

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool isInvincible = false;
    public float InvincibilityTime = 3f;
    public float InvincibilityFlashDelay = 0.2f;
    public SpriteRenderer graphics;
    public HealthBar healthBar;

    void Start()
    {
        graphics = GetComponent<SpriteRenderer>();
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

    public void TakeDamage(int damage)
    {
        if(!isInvincible){
        currentHealth -= damage; // Retirer x dégâts
        healthBar.SetHealth(currentHealth); // Changer la valeur du slider
        isInvincible = true; // Rendre le joueur invincible
        StartCoroutine(InvincibilityFlash());
        StartCoroutine(HandleInvincibilityDelay());
        }
    }

    public IEnumerator InvincibilityFlash()
    {
        while(isInvincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(InvincibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(InvincibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(InvincibilityTime);
        isInvincible = false;
    }
}