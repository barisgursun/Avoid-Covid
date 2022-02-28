using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    //Movement
    private CharacterController controller;
    public float Speed = 1f;

    //CameraController
    private float xRotation = 0f;
    public float MouseSensitivity = 100f;


    // jump and gravity
    private Vector3 velocity;
    private float gravity = -9.81f;
    private bool isGround;

    public Transform GroundChecker;
    public float groundCheckerRadius;
    public LayerMask obstacleLayer;

    public float jumpHeight = 0.1f;
    public float gravityDivide = 100f;
    public float jumpSpeed = 100f;

    private float accTimer;
    private void Awake()
    {
        controller = GetComponent<CharacterController>();

        //cursor
        Cursor.visible = false; // mouse cursor destroyed
        Cursor.lockState = CursorLockMode.Locked; // fix the cursor screen pivot

    }
    private void FixedUpdate()
    {
        //check char is grounded or not checksphere creates an imaginary sphere and returns true or false
        isGround = Physics.CheckSphere(GroundChecker.position, groundCheckerRadius, obstacleLayer);

        //value of horizontal and vertical mines 
        Vector3 moveInputs = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;

        Vector3 moveVelocity = moveInputs * Time.deltaTime * Speed; // optimize the fps per time;

        controller.Move(moveVelocity);
        //player  to movement motion this part


        //camera

        transform.Rotate(0f, Input.GetAxis("Mouse X") * Time.deltaTime * MouseSensitivity, 0f); // rotate to gameobject input values;

        xRotation -= Input.GetAxis("Mouse Y") * Time.deltaTime * MouseSensitivity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // limits of mouse y position
        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // rotate to camera for xrotation


        // jump and gravity

        if (!isGround)
        {
            velocity.y += (gravity * Time.deltaTime / gravityDivide );
            accTimer += Time.deltaTime;
            Speed = Mathf.Lerp(10, jumpSpeed, accTimer);
        }
        else
        {
            velocity.y = -0.05f;
            Speed = 10f;
            accTimer = 0f;
        }
        //If gameobject is on the ground and pressed space
        if (Input.GetKey(KeyCode.Space) && isGround)

        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity / gravityDivide ); // formulas of jump
        }


        controller.Move(velocity * Time.deltaTime);

    }
    private void Update()
    {



    }
}
