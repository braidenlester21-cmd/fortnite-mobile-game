using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings - Fortnite Style")]
    public float walkSpeed = 5f;
    public float sprintSpeed = 8.5f;
    public float crouchSpeed = 3.5f;
    public float rotationSpeed = 12f;
    public float gravity = -18f;
    public float jumpHeight = 2.1f;
    
    [Header("Sliding")]
    public float slideSpeed = 12f;
    public float slideDuration = 0.8f;
    
    [Header("References")]
    public CharacterController controller;
    public Joystick joystick;
    public Transform cameraTransform;

    private Vector3 velocity;
    private bool isGrounded;
    private bool isCrouching = false;
    private bool isSliding = false;
    private float slideTimer = 0f;
    private float currentSpeed;

    void Update()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
        Vector3 move = new Vector3(horizontal, 0f, vertical).normalized;

        bool sprintInput = Input.GetKey(KeyCode.LeftShift);
        bool crouchInput = Input.GetKeyDown(KeyCode.LeftControl);

        if (crouchInput)
            ToggleCrouch();

        if (isSliding)
        {
            slideTimer -= Time.deltaTime;
            if (slideTimer <= 0) isSliding = false;
            currentSpeed = slideSpeed;
        }
        else if (sprintInput && !isCrouching && move.magnitude > 0.1f)
            currentSpeed = sprintSpeed;
        else if (isCrouching)
            currentSpeed = crouchSpeed;
        else
            currentSpeed = walkSpeed;

        Vector3 moveDirection = move * currentSpeed;
        controller.Move(moveDirection * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (sprintInput && crouchInput && isGrounded && move.magnitude > 0.3f && !isSliding)
        {
            StartSlide();
        }

        if (move != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void ToggleCrouch()
    {
        isCrouching = !isCrouching;
        controller.center = isCrouching ? new Vector3(0, 0.6f, 0) : new Vector3(0, 1f, 0);
        controller.height = isCrouching ? 1.2f : 2f;
    }

    private void StartSlide()
    {
        isSliding = true;
        slideTimer = slideDuration;
        velocity += transform.forward * 4f;
    }

    public void JumpButton() 
    { 
        if (isGrounded) velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); 
    }
    
    public void ToggleCrouchButton() => ToggleCrouch();
}
