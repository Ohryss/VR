using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class LeftHand : MonoBehaviour
{
    public XRNode controllerNode = XRNode.LeftHand; // Définit la main gauche
    public float horizontalSpeedThreshold = 0.5f; // Sensibilité du mouvement
    private Vector3 controllerVelocity;

    public GameObject magicSpherePrefab; // Référence au prefab de la sphère magique
    public Transform spawnPoint; // Point d'apparition de la sphère (peut être la position de la main)

    public float cooldownTime = 2f; // Temps de recharge entre les tirs
    private float lastCastTime = -Mathf.Infinity; // Temps du dernier tir

    void Update()
    {
        // Récupérer la vitesse du contrôleur
        InputDevice device = InputDevices.GetDeviceAtXRNode(controllerNode);
        if (device.TryGetFeatureValue(CommonUsages.deviceVelocity, out controllerVelocity))
        {
            DetectHorizontalMovement(controllerVelocity);
        }
    }

    private void DetectHorizontalMovement(Vector3 velocity)
    {
        // Calculer la vitesse horizontale (composantes XZ)
        float horizontalSpeed = new Vector2(velocity.x, velocity.z).magnitude;

        // Si la vitesse horizontale dépasse le seuil
        if (horizontalSpeed > horizontalSpeedThreshold)
        {
            Debug.Log("Quick horizontal movement detected!");
            // Vérifier le cooldown avant de lancer la magie
            if (Time.time >= lastCastTime + cooldownTime)
            {
                CastMagic();
                lastCastTime = Time.time; // Met à jour le temps du dernier tir
            }
            else
            {
                Debug.Log("Cooldown in progress, cannot cast yet.");
            }
        }
    }

    private void CastMagic()
    {
        // Instancier la sphère magique
        if (magicSpherePrefab != null && spawnPoint != null)
        {
            GameObject magicSphere = Instantiate(magicSpherePrefab, spawnPoint.position, spawnPoint.rotation);

            // Ajouter une force à la sphère pour qu'elle parte en ligne droite
            Rigidbody rb = magicSphere.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(spawnPoint.forward * 10f, ForceMode.Impulse); // Ajustez la force selon vos besoins
            }

            Debug.Log("Magic sphere cast!");
        }
    }
}