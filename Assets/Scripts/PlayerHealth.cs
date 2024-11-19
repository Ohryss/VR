using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
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
    }
}
