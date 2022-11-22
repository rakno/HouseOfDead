using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieScript : MonoBehaviour
{

    NavMeshAgent agent;
    player mainPlayer;

    private void Awake()
    {
    GameObject go = GameObject.FindWithTag("mainPlayer");
    mainPlayer = go.GetComponent<player>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        agent.SetDestination(mainPlayer.transform.position);
    }






}