using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f); // Détruire après 5 secondes
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
