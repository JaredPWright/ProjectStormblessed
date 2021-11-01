using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationalMovement : MonoBehaviour
{
    private Transform playerTrans;
    private bool[] directionBools = {false, false};

    public float degreeOfRotation = 6.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerTrans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            directionBools[0] = true;
        }

        if(Input.GetKeyUp(KeyCode.Q))
        {
            directionBools[0] = false;
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            directionBools[1] = true;
        }

        if(Input.GetKeyUp(KeyCode.E))
        {
            directionBools[1] = false;
        }
    }

    void FixedUpdate()
    {
        if(directionBools[0])
        {
            playerTrans.transform.Rotate(0f,0f,degreeOfRotation);
        }

        if(directionBools[1])
        {
            playerTrans.transform.Rotate(0f,0f,-degreeOfRotation);
        }
    }
}