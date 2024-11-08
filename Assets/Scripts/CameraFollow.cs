using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Glissez le cube ici dans l’inspecteur
    public Vector3 offset = new Vector3(0, 5, -7);  // Position de la caméra par rapport au cube

    void LateUpdate()
    {
        transform.position = player.position + offset;
    }
}
