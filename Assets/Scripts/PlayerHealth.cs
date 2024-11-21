using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Nécessaire pour TextMeshPro

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public TextMeshProUGUI healthText; // Ajoutez cette ligne pour lier le texte HP
    public GameObject deathMenu;
    public bool isDead;

    void Start()
    {
        currentHealth = maxHealth;
        deathMenu.SetActive(false);
        UpdateText(); // Initialisation du texte
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player Health: " + currentHealth);
        UpdateText();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        Debug.Log("Player Health: " + currentHealth);
        UpdateText();
    }

    public void IncreaseMaxHealth(int amount)
    {
        maxHealth += amount;
        UpdateText();
        Debug.Log("Player Max Health Increased: " + maxHealth);
    }

    private void Die()
    {
        playerDeath();
    }

    public void playerDeath()
    {
        deathMenu.SetActive(true);
        isDead = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void UpdateText()
    {
        if (healthText != null)
        {
            healthText.text = "HP: " + currentHealth.ToString(); // Met à jour le texte
        }
    }
}