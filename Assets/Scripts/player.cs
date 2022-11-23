using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class player : MonoBehaviour
{

   
    
        private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("zombieBoss"))
        {
            Transform panelTransform = GameObject.Find("Panel").transform;
            
            foreach (Transform child in panelTransform)
            {
                Destroy(child.gameObject);
                break;
            }

            
            if(panelTransform.childCount<=0)
            {
                GameObject.Destroy(gameObject);
                Debug.Log("player died");
            }
        }
        if (collision.gameObject.CompareTag("zombieGirls"))
        {
            Transform panelTransform = GameObject.Find("Panel").transform;

            foreach (Transform child in panelTransform)
            {
                Destroy(child.gameObject);
                break;
            }
            if (panelTransform.childCount <= 0)
            {
                GameObject.Destroy(gameObject);
                Debug.Log("player died");
            }
        }
    }
}
