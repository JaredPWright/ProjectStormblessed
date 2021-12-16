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
    public float playerWeight = 25f;
    public Vector3 drag;
    public Transform sphereCastCenter;
    public LayerMask ground;
    public Vector3 degreeOfRotation;

    //These are apparently important for controlling the player.
    private CharacterController playerController;
    private PlayerInput playerInput;
    private Vector3 pVel;
    private Transform camForward;
    private float radiusOfCast = .25f;
    public Vector3 _velocity;
    
    //private Animator animator;
    private int moveXParameterID;
    private int moveYParameterID;

    //These are to store out inputs
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction lookAction;
    private InputAction rotateAction;

    [SerializeField] private bool grounded = false;
    // Start is called before the first frame update
    void Start()
    {
        //Set the player controller and player input here
        playerController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        camForward = GameObject.Find("Main Camera").GetComponent<Transform>();

        //animator = GetComponentInChildren<Animator>();
        moveXParameterID = Animator.StringToHash("MoveX");
        moveYParameterID = Animator.StringToHash("MoveY");

        moveAction = playerInput.actions["BasicMove"];
        jumpAction = playerInput.actions["Jump"];
        lookAction = playerInput.actions["Look"];
        rotateAction = playerInput.actions["Rotate"];
    }

    // Update is called once per frame
    void Update()
    {
        _velocity = Vector3.zero;
        Vector3 moveVal = Vector3.zero;
        Vector2 inputGrab;

        if(grounded && _velocity.y < 0.0f)
            _velocity.y = 0.0f;
        
        //Get InputSystem input, as pulled through the Player Input Component
        inputGrab = moveAction.ReadValue<Vector2>();

        float rotationGrab = rotateAction.ReadValue<float>();

        if(rotationGrab != 0)
        {
            if(rotationGrab < 0)
            {
                gameObject.transform.Rotate(-degreeOfRotation, Space.Self);
            }else if(rotationGrab > 0)
            {
                gameObject.transform.Rotate(degreeOfRotation, Space.Self);
            }
        }

        if(!grounded)
        {
            Vector3 tempGrab = inputGrab;
            tempGrab.x /= 1 + drag.x * Time.deltaTime;
            tempGrab.y /= 1 + drag.y * Time.deltaTime;
        }
        else
            moveVal = new Vector3(inputGrab.x, 0.0f, inputGrab.y);
        //transform.Rotate(0f, camForward.rotation.y, 0f);

        moveVal = transform.TransformDirection(moveVal);
        playerController.Move(moveVal * Time.deltaTime * playerSpeed);

        if((jumpAction.triggered && grounded) && !MovementBools.lashing)
        {
            _velocity.y += Mathf.Sqrt(playerJumpHeight * playerWeight * gravity);
            Debug.Log("jump");
        }

        _velocity.y -= gravity * playerWeight * Time.deltaTime;

        _velocity.x /= 1 + drag.x * Time.deltaTime;
        _velocity.y /= 1 + drag.y * Time.deltaTime;
        _velocity.z /= 1 + drag.z * Time.deltaTime;
        
        playerController.Move(_velocity * Time.deltaTime);
    }

    void FixedUpdate()
    {
        grounded = Physics.CheckSphere(sphereCastCenter.position, radiusOfCast, ground, QueryTriggerInteraction.Ignore);    
    }
}
