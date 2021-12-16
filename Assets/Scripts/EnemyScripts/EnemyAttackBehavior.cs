using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBehavior : MonoBehaviour
{
    private Animator[] clawAnimators;
    public float baseDamage = 10.0f;
    public float attackInterval = 3.5f;
    private float attackTimer = 0.0f;
    private bool playerInRange = false;

    void Start()
    {
        if(gameObject.CompareTag("BeegCrab"))
            baseDamage *= 2.0f;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerHealth.playerHealth -= baseDamage;
            playerInRange = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(playerInRange)
        {
            attackTimer += Time.deltaTime;
            if(attackTimer % attackInterval == 0)
            {
                PlayerHealth.playerHealth -= baseDamage;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(playerInRange)
        {
            playerInRange = false;
        }
    }
}
