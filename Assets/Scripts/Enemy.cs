using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damageAmount = 1;  // Points de dégâts infligés au joueur

    private void OnCollisionEnter(Collision collision)
    {
        // Vérifie si l'objet en collision est le joueur
        if (collision.gameObject.CompareTag("Player"))
        {
            // Récupère le script de santé du joueur et applique les dégâts
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }

            // Détruit l'ennemi après avoir infligé les dégâts
            Destroy(gameObject);
        }
    }
}
