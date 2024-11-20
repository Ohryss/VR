using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        deathMenu.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        Debug.Log("Player Health: " + currentHealth);
    }

public void IncreaseMaxHealth(int amount)
{
    maxHealth += amount;
    currentHealth = maxHealth;
    Debug.Log("Player Max Health Increased: " + maxHealth);
}

    private void Die()
    {
        Debug.Log("Player has died.");
        Destroy(gameObject);
        playerDeath();
    }

    public GameObject deathMenu;
    public bool isDead;

    public void playerDeath() {
        deathMenu.SetActive(true);
        Time.timeScale = 0f;
        isDead = true;
    }
}
