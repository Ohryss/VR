using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordKill : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the cube
            Destroy(collision.gameObject);
        }
    }
}
