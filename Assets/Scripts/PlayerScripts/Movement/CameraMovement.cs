using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float mouseSensitivity = 100;
    float rotationOnY = 0;

    [SerializeField] Transform player;

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;

        rotationOnY -= mouseY;
        rotationOnY = Mathf.Clamp(rotationOnY, -90f, 90f);

        transform.localEulerAngles = new Vector3(rotationOnY, 0, 0);

        player.Rotate(Vector3.up * mouseX);
    }
}
