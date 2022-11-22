using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class player : MonoBehaviour
{
    
    
    float playerHealth = 100;

    

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("zombieBoss"))
        {
            playerHealth = playerHealth - 1;
            if(playerHealth<=0)
            {
                GameObject.Destroy(gameObject);
                Debug.Log("player died");
            }
        }
        if (collision.gameObject.CompareTag("zombieGirls"))
        {
            playerHealth = playerHealth - 1;
            if (playerHealth <= 0)
            {
                GameObject.Destroy(gameObject);
                Debug.Log("player died");
            }
        }
    }
}
