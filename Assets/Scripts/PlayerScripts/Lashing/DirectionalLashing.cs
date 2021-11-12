using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LashMethods;
using UnityEngine.InputSystem;

public class DirectionalLashing : MonoBehaviour
{
    LashingForceValues lashingForceValues;
    public float[] lashForces = new float[6] {0f, 0f, 0f, 0f, 0f, 0f};
    public RaycastHit[] hits = new RaycastHit[6];

    private PlayerInput playerInput;

    private InputAction[] lashingMaps = new InputAction[6];

    void Awake()
    {
        lashingForceValues = GetComponent<LashingForceValues>();
        playerInput = GetComponent<PlayerInput>();

        lashingMaps[0] = playerInput.actions["LashForward"];
        lashingMaps[1] = playerInput.actions["LashBackward"];
        lashingMaps[2] = playerInput.actions["LashRight"];
        lashingMaps[3] = playerInput.actions["LashLeft"];
        lashingMaps[4] = playerInput.actions["LashUp"];
        lashingMaps[5] = playerInput.actions["LashDown"];
    }

    void Update()
    {
        if(lashingMaps[0].triggered && LashData.currentLashings[0] < LashData.maxLashings[0])
        {
            LashData.currentLashings[0]++;
            lashForces[0] = lashingForceValues.directionalLashingForces[0] * lashingForceValues.directionalLashingForcesMultipliers[0];
            CameraForwardLash();
        }

        if(lashingMaps[1].triggered && LashData.currentLashings[1] < LashData.maxLashings[1])
        {
            LashData.currentLashings[1]++;
            lashForces[1] = lashingForceValues.directionalLashingForces[1] * lashingForceValues.directionalLashingForcesMultipliers[1];
            CameraBackwardLash();
        }

        if(lashingMaps[2].triggered && LashData.currentLashings[2] < LashData.maxLashings[2])
        {
            LashData.currentLashings[2]++;
            lashForces[2] = lashingForceValues.directionalLashingForces[2] * lashingForceValues.directionalLashingForcesMultipliers[2];
            UpwardLash();
        }

        if(lashingMaps[3].triggered && LashData.currentLashings[3] < LashData.maxLashings[3])
        {
            LashData.currentLashings[3]++;
            lashForces[3] = lashingForceValues.directionalLashingForces[3] * lashingForceValues.directionalLashingForcesMultipliers[3];
            DownwardLash();
        }

        if(lashingMaps[4].triggered && LashData.currentLashings[4] < LashData.maxLashings[4])
        {
            LashData.currentLashings[4]++;
            lashForces[4] = lashingForceValues.directionalLashingForces[4] * lashingForceValues.directionalLashingForcesMultipliers[4];
            RightwardLash();
        }

        if(lashingMaps[5].triggered && LashData.currentLashings[5] < LashData.maxLashings[5])
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
