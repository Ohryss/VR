using UnityEngine;

public class MaxHealthIncrease : MonoBehaviour
{
    public int additionalMaxHealth = 1;  // Quantité de PV maximum supplémentaire
    private GameObject player;

    void Start(){
        player = GameObject.FindWithTag("Player");
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Vérifie si l'objet en collision est le joueur
        if (collision.gameObject.CompareTag("Sword"))
        {
            // Récupère le script de santé du joueur et augmente les PV max
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.IncreaseMaxHealth(additionalMaxHealth);
            }

            // Détruit l'objet bonus de santé après avoir augmenté les PV max
            Destroy(gameObject);
        }
    }
}
