using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    public float speed = 2.0f;
    public Transform playerCamera;
    private CharacterController characterController;
    private Vector2 moveInput;
    
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    
    // This gets called by the PlayerInput component
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    
    void Update()
    {
        Vector3 moveDirection = playerCamera.forward * moveInput.y + playerCamera.right * moveInput.x;
        moveDirection.y = 0;
        characterController.Move(moveDirection * speed * Time.deltaTime);
    }
}