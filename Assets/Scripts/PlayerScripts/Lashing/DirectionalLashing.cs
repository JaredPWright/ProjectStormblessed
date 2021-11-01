using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LashMethods;

public class DirectionalLashing : MonoBehaviour
{
    public Rigidbody pRb;

    LashingForceValues lashingForceValues;
    public float[] lashForces = new float[6] {0f, 0f, 0f, 0f, 0f, 0f};
    public RaycastHit[] hits = new RaycastHit[6];

    void Awake()
    {
        lashingForceValues = GetComponent<LashingForceValues>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) && LashData.currentLashings[0] < LashData.maxLashings[0])
        {
            LashData.currentLashings[0]++;
            lashForces[0] = lashingForceValues.directionalLashingForces[0] * lashingForceValues.directionalLashingForcesMultipliers[0];
            CameraForwardLash();
        }

        if(Input.GetKeyDown(KeyCode.Alpha2) && LashData.currentLashings[0] < LashData.maxLashings[0])
        {
            LashData.currentLashings[1]++;
            lashForces[1] = lashingForceValues.directionalLashingForces[1] * lashingForceValues.directionalLashingForcesMultipliers[1];
            CameraBackwardLash();
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            LashData.currentLashings[2]++;
            lashForces[2] = lashingForceValues.directionalLashingForces[2] * lashingForceValues.directionalLashingForcesMultipliers[2];
            UpwardLash();
        }

        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            LashData.currentLashings[3]++;
            lashForces[3] = lashingForceValues.directionalLashingForces[3] * lashingForceValues.directionalLashingForcesMultipliers[3];
            DownwardLash();
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            LashData.currentLashings[4]++;
            lashForces[4] = lashingForceValues.directionalLashingForces[4] * lashingForceValues.directionalLashingForcesMultipliers[4];
            RightwardLash();
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            LashData.currentLashings[5]++;
            lashForces[5] = lashingForceValues.directionalLashingForces[5] * lashingForceValues.directionalLashingForcesMultipliers[5];
            LeftwardLash();
        }
    }

    void CameraForwardLash()
    {
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hits[0], Mathf.Infinity))
        {
            ForwardLash flash = this.gameObject.AddComponent<ForwardLash>() as ForwardLash;
        }
    }

    void CameraBackwardLash()
    {
        if(Physics.Raycast(transform.position, -transform.TransformDirection(Vector3.forward), out hits[1], Mathf.Infinity))
        {
            BackwardLash blash = this.gameObject.AddComponent<BackwardLash>() as BackwardLash;
        }
    }

    void UpwardLash()
    {
        // Does the ray intersect any objects excluding the player layer
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hits[2], Mathf.Infinity))
        {
            UpLash uLash = this.gameObject.AddComponent<UpLash>() as UpLash;
        }
    }

    void DownwardLash()
    {
        // Does the ray intersect any objects excluding the player layer
        if(Physics.Raycast(transform.position, -transform.TransformDirection(Vector3.up), out hits[3], Mathf.Infinity))
        {
            DownLash dLash = this.gameObject.AddComponent<DownLash>() as DownLash;
        }
    }

    void RightwardLash()
    {
        // Does the ray intersect any objects excluding the player layer
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hits[4], Mathf.Infinity))
        {
            RightLash dLash = this.gameObject.AddComponent<RightLash>() as RightLash;
        }
    }

    void LeftwardLash()
    {
        // Does the ray intersect any objects excluding the player layer
        if(Physics.Raycast(transform.position, -transform.TransformDirection(Vector3.right), out hits[5], Mathf.Infinity))
        {
            LeftLash dLash = this.gameObject.AddComponent<LeftLash>() as LeftLash;
        }
    }
}
