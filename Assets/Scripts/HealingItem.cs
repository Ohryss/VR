using UnityEngine;

public class HealingItem : MonoBehaviour
{
    public int healAmount = 1;  // Quantité de PV restaurés
    private GameObject player;

    void Start(){
        player = GameObject.FindWithTag("Player");
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Vérifie si l'objet en collision est le joueur
        if (collision.gameObject.CompareTag("Sword"))
        {
            // Récupère le script de santé du joueur et ajoute des PV
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount);
            }

            // Détruit l'objet de soin après avoir soigné le joueur
            Destroy(gameObject);
        }
    }
}
