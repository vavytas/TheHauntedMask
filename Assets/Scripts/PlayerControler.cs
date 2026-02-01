using MangoFog;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] public Rigidbody2D BodyPlayer;
    [SerializeField] public float Speed = 350f;
    private Vector2 moveInput;
    private float horizontal;
    private float vertical;
    [SerializeField] public MangoFogUnit fogUnit;

    [SerializeField] GameObject Mask1;

    public bool isMasked = false;




    private bool facingRight = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fogUnit.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -180));
    }

    // Update is called once per frame
    void Update()
    {
        BodyPlayer.linearVelocity = moveInput * Speed;
        if (moveInput.x < 0 && facingRight)
        {
            Turn(false);
        }
        else if (moveInput.x > 0 && !facingRight)
        {
            Turn(true);
        }

        fogUnit.transform.rotation = Quaternion.Euler(new Vector3(0, 0, moveInput.x));

    }

    private void Turn(bool turnRight)
    {

        if (turnRight)
        {
            facingRight = true;
            transform.Rotate(0f, 180f, 0f);
        }
        else
        {
            facingRight = false;
            transform.Rotate(0f, -180f, 0f);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }


    public void MaskOnOff(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (!isMasked)
            {
                PutOnTheMask();
            }
            else
            {
                TakeOffTheMask();
            }
        }

    }

    public void PutOnTheMask()
    {

        if (MainManager.mainManager.overMask)
        {
            Mask1.SetActive(true);
            isMasked = true;

            MainManager.mainManager.GroundMask.SetActive(false);
            MainManager.mainManager.MaskOn();
            MainManager.mainManager.overMask= false;
        }
    }

    public void TakeOffTheMask()
    {
        Mask1.SetActive(false);
        isMasked = false;
        var newMask = Instantiate(MainManager.mainManager.MaskforInstant, transform.position, MainManager.mainManager.MaskforInstant.transform.rotation);

        MainManager.mainManager.GroundMask = newMask;
        MainManager.mainManager.MaskOff();
    }
}
