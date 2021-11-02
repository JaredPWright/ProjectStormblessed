using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class PController : MonoBehaviour
{
    //These control various player movement values
    [Header("Set in Inspector")]
    public float playerSpeed = 5.0f;
    public float playerJumpHeight = 5.0f;
    public float gravity = -9.81f;

    //These are apparently important for controlling the player.
    private CharacterController playerController;
    private PlayerInput playerInput;
    private Vector3 pVel;

    //These are to store out inputs
    private InputAction moveAction;
    private InputAction jumpAction;
    //private InputAction lookAction;

    private bool grounded = false;
    // Start is called before the first frame update
    void Start()
    {
        //Set the player controller and player input here
        playerController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();

        moveAction = playerInput.actions["BasicMove"];
        jumpAction = playerInput.actions["Jump"];
    }

    // Update is called once per frame
    void Update()
    {
        //Get InputSystem input, as pulled through the Player Input Component
        Vector2 inputGrab = moveAction.ReadValue<Vector2>();
        //Since this controls our Forward, Backward, Left and Right movements, we get it as a Vector2,
        //then we put the x and the y into the Vector3 in the x and z slots so that we can use the
        //PlayerController move method.
        Vector3 moveVal = new Vector3(inputGrab.x, 0.0f, inputGrab.y);
        playerController.Move(moveVal * Time.deltaTime * playerSpeed);
    }
}
