using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    [Header("Set in Script")]
    [SerializeField] Rigidbody playerRb;
    [SerializeField] Animator animator;
    private bool[] directionBools = {false, false, false, false, false};

    [Header("Set in Inspector")]
    public float playerSpd = 5.0f;
    public float playerJmp = 20.0f;

    private float baseSpd;

    void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        baseSpd = playerSpd;
    }

    void Update()
    {
        // if(Input.GetKey(KeyCode.LeftShift))
        // {
        //     playerSpd *= 1.2f;
        // }

        // if(Input.GetKeyUp(KeyCode.LeftShift))
        // {
        //     playerSpd = baseSpd;
        // }

        if(Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Forward");
            directionBools[0] = true;
            animator.SetBool("running", true);
        }

        if(Input.GetKeyUp(KeyCode.W))
        {
            directionBools[0] = false;
            animator.SetBool("running", false);
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Backward");
            directionBools[1] = true;
            animator.SetBool("running", true);
        }

        if(Input.GetKeyUp(KeyCode.S))
        {
            directionBools[1] = false;
            animator.SetBool("running", false);
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Leftward");
            directionBools[2] = true;
        }

        if(Input.GetKeyUp(KeyCode.A))
        {
            directionBools[2] = false;
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Rightward");
            directionBools[3] = true;
        }

        if(Input.GetKeyUp(KeyCode.D))
        {
            directionBools[3] = false;
        }

        if(Input.GetKeyDown(KeyCode.Space)/*MovementBools.canJump*/)
        {
            directionBools[4] = true;
            /*MovementBools.canJump = false;*/
            animator.SetBool("jumping", true);
        }
    }

    void FixedUpdate()
    {
        if(directionBools[0])
        {
            playerRb.AddForce(transform.forward * playerSpd, ForceMode.VelocityChange);
        }
        
        if(directionBools[1])
        {
            playerRb.AddForce(-transform.forward * playerSpd, ForceMode.VelocityChange);
        }

        if(directionBools[2])
        {
            playerRb.AddForce(-transform.right * playerSpd, ForceMode.VelocityChange);
        }

        if(directionBools[3])
        {
            playerRb.AddForce(transform.right * playerSpd, ForceMode.VelocityChange);
        }

        if(directionBools[4])
        {
            playerRb.AddForce(transform.up * playerJmp, ForceMode.Impulse);
            directionBools[4] = false;
            animator.SetBool("jumping", false);
        }
    }
}