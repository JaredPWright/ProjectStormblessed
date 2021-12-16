using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("RegularCrab") || other.gameObject.CompareTag("BeegCrab"))
        {
            other.gameObject.GetComponent<EnemyManager>().enemyHealth -= 2;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("RegularCrab") || other.gameObject.CompareTag("BeegCrab"))
        {
            other.gameObject.GetComponent<EnemyManager>().enemyHealth -= 1;
        }
    }
}
