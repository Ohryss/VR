using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyMovements : MonoBehaviour
{
    [SerializeField] private Transform player; // Assign in Inspector
    public float moveSpeed = 2f;
    void Start(){
        if (player == null) {
            player = GameObject.FindWithTag("Player").transform;
            if (player == null) {
                Debug.LogError("Player not found! Assign a Transform in the Inspector.");
            }
        }
    }

    void Update(){
        if (player != null) {
            FollowAndLookPlayer();
        }
    }

    void FollowAndLookPlayer(){
        // Calculate the direction towards the player
        Vector3 direction = (player.position - transform.position).normalized;

        // Move the enemy towards the player
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Rotate the enemy to look at the player
        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
    }
}
