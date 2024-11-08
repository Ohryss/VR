using UnityEngine;

public class HealingItem : MonoBehaviour
{
    public int healAmount = 1;  // Quantité de PV restaurés

    private void OnCollisionEnter(Collision collision)
    {
        // Vérifie si l'objet en collision est le joueur
        if (collision.gameObject.CompareTag("Player"))
        {
            // Récupère le script de santé du joueur et ajoute des PV
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount);
            }

            // Détruit l'objet de soin après avoir soigné le joueur
            Destroy(gameObject);
        }
    }
}
