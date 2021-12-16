using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCheck : MonoBehaviour
{
    private Rigidbody playerCollider;
    private Vector3 normalStruck;
    
    void Awake()
    {
        playerCollider = GetComponentInChildren<Rigidbody>();
    }

    void OnCollisionEnter(Collision other)
    {
        ContactPoint tempContactPoint = other.GetContact(0);
        normalStruck = tempContactPoint.normal;
        Debug.Log(normalStruck.ToString());

        if(normalStruck.y == -1.0f)
        {
            //MovementBools.canJump = true;
        }
    }
}
