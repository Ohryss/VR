using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyMovements : MonoBehaviour
{
    private Transform player;
    public float moveSpeed = 2f;
    void Start(){
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update(){
        FollowAndLookPlayer();
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
