using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] public Rigidbody2D BodyPlayer;
    [SerializeField] public float Speed = 350f;
    private Vector2 moveInput;
    private float horizontal;
    private float vertical;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BodyPlayer.linearVelocity = moveInput * Speed;
    }


public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
}
