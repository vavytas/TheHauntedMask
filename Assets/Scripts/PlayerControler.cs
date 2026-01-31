using UnityEngine;
using UnityEngine.InputSystem;

using MangoFog;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] public Rigidbody2D BodyPlayer;
    [SerializeField] public float Speed = 350f;
    private Vector2 moveInput;
    private float horizontal;
    private float vertical;
    [SerializeField]public MangoFogUnit fogUnit;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fogUnit.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -180));
    }

    // Update is called once per frame
    void Update()
    {
        BodyPlayer.linearVelocity = moveInput * Speed;
        fogUnit.transform.rotation = Quaternion.Euler(new Vector3(0, 0, moveInput.x));

    }


    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
}
