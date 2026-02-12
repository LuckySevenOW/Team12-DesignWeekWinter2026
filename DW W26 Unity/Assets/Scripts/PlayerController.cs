using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField] public int PlayerNumber { get; private set; }
    [field: SerializeField] public Color PlayerColor { get; private set; }
    [field: SerializeField] public SpriteRenderer SpriteRenderer { get; private set; }
    [field: SerializeField] public Rigidbody2D Rigidbody2D { get; private set; }
    [field: SerializeField] public float MoveSpeed { get; private set; } = 7f;
    [field: SerializeField] public float JumpForce { get; private set; } = 5f;
    public bool DoJump { get; private set; }

    public bool CanMove = true;

    public float ClimbSpeed = 5f;

    private bool Climbing = false;

    public bool HoldingAmmo = false;

    public bool OnAmmo = false;

    public bool TouchingCannon = false;

    LayerMask GroundLayers;

    LayerMask CannonLayers;

    LayerMask AmmoBoxLayers;

    public int CannonRotateSpeed = 1;

    private Rigidbody2D currentcollider;

    public Rigidbody2D CurrCannon;

    private float rotationrangeright;

    private float rotationrangeleft;


    private void Start()
    {
        GroundLayers = LayerMask.GetMask("ground", "cannon");
        CannonLayers = LayerMask.GetMask("cannon");
        AmmoBoxLayers = LayerMask.GetMask("ammobox");
    }

    // Player input information
    private PlayerInput PlayerInput;
    private InputAction InputActionMove;
    private InputAction InputActionJump;
    private InputAction InputActionInteract;
    private InputAction InputActionAttack;

    // Assign color value on spawn from main spawner
    public void AssignColor(Color color)
    {
        // record color
        PlayerColor = color;

        // Assign to sprite renderer
        if (SpriteRenderer == null)
            Debug.Log($"Failed to set color to {name} {nameof(PlayerController)}.");
        else
            SpriteRenderer.color = color;
    }

    // Set up player input
    public void OnLadder(bool check)
    {
        print(check);
        Climbing = check;
    }

    public void AssignPlayerInputDevice(PlayerInput playerInput)
    {
        // Record our player input (ie controller).
        PlayerInput = playerInput;
        // Find the references to the "Move" and "Jump" actions inside the player input's action map
        // Here I specify "Player/" but it in not required if assigning the action map in PlayerInput inspector.
        InputActionMove = playerInput.actions.FindAction($"Player/Move");
        InputActionJump = playerInput.actions.FindAction($"Player/Jump");
        InputActionInteract = playerInput.actions.FindAction($"Player/Interact");
        InputActionAttack = playerInput.actions.FindAction($"Player/Attack");
    }

    // Assign player number on spawn
    public void AssignPlayerNumber(int playerNumber)
    {
        this.PlayerNumber = playerNumber;
    }

    // Runs each frame
    public void Update()
    {
        //if on cannon and attack pressed shoot
        if (CurrCannon != null)
        {
            if (CanMove == false)
            {
                if (InputActionAttack.WasPressedThisFrame())
                {
                   CurrCannon.transform.GetComponentInParent<CannonBulletSpawn>().Shoot();
                }
            }
        }
        // Read the "Jump" action state, which is a boolean value
        if (InputActionJump.WasPressedThisFrame())
        {
            // Buffer input becuase I'm controlling the Rigidbody through FixedUpdate
            // and checking there we can miss inputs.
            DoJump = true;
        }
        //check for cannon interaction
        if (TouchingCannon)
        {
            if (HoldingAmmo)
            {
                CurrCannon.transform.GetComponentInParent<CannonBulletSpawn>().AddAmmo(1);
                HoldingAmmo = false;
            }
            if (InputActionInteract.WasPressedThisFrame())
            {
                if (CanMove)
                {
                  CanMove = false;
                }
                else
                {
                    CanMove = true;
                }
            }

        }
        //pick up ammo on touching box
        if (OnAmmo)
        {
            if (InputActionInteract.WasPressedThisFrame())
            {
                HoldingAmmo = true;
            }

        }


    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // i forget what this does I forgot to add a comment
        if (collision.gameObject.layer == 3)
        {
            currentcollider = collision.rigidbody;
        }
        
    }
    // Runs each phsyics update
    void FixedUpdate()
    {
        if (Rigidbody2D == null)
        {
            Debug.Log($"{name}'s {nameof(PlayerController)}.{nameof(Rigidbody2D)} is null.");
            return;
        }



        // MOVE
        // Read the "Move" action value, which is a 2D vector
        Vector2 moveValue = InputActionMove.ReadValue<Vector2>();
        //check if character can move

        if (CanMove == true)
        {
            if (Climbing)
            {
                float climbForce = moveValue.y * ClimbSpeed;
                // add force up or down to climb
                Rigidbody2D.linearVelocityY = climbForce;
            }
            // Here we're only using the X axis to move.
            float moveForce = moveValue.x * MoveSpeed;
            // Apply fraction of force each frame
            Rigidbody2D.linearVelocityX = moveForce;
            // turn towards direction
            if (moveForce > 0)
            {
                SpriteRenderer.flipX = true;

            }
            else
            if (moveForce < 0)
            {
                SpriteRenderer.flipX = false;
            }
        }
        // change inputs to move cannon
        else
        {
            if (CurrCannon != null)
            {
                Rigidbody2D.linearVelocityX = 0;
                Rigidbody2D cannonget = CurrCannon;
                //leftturrets
                if (cannonget.transform.position.x > 0)
                {
                    rotationrangeright = 0.1f;
                    rotationrangeleft = 0.65f;
                    CannonRotateSpeed = -50;
                }
                else
                //rightturrets
                {

                    rotationrangeright = -0.65f;
                    rotationrangeleft = -0.1f;
                    CannonRotateSpeed = 50;
                }
                //lock rotation and move it back slightly if past rotationrange
                if (cannonget.transform.rotation.z > rotationrangeright && cannonget.transform.rotation.z < rotationrangeleft)
                {
                    cannonget.transform.Rotate(0, 0, moveValue.y / 50 * CannonRotateSpeed);
                }
                else
                {
                    if (cannonget.transform.rotation.z < rotationrangeright)
                    {
                        cannonget.transform.Rotate(0, 0, 0.3f);
                    }
                    if (cannonget.transform.rotation.z > rotationrangeleft)
                    {
                        cannonget.transform.Rotate(0, 0, -0.3f);
                    }
                }
            }
            //check if player is on floor
            if (Rigidbody2D.IsTouchingLayers(GroundLayers))
            {
                //if not moving stop all velocity
                if (moveValue == new Vector2(0, 0))
                {
                    Rigidbody2D.linearVelocityX = 0;
                }

            }

        }
        // JUMP - review Update()
        if (DoJump)
        {
            //floorcheck
            if (Rigidbody2D.IsTouchingLayers(GroundLayers))
            // Apply all force immediately
            {
                if (CanMove == true)
                {
                    Rigidbody2D.AddForceY(JumpForce, ForceMode2D.Impulse);
                    DoJump = false;
                }

            }
            else
            {
                DoJump = false;
            }

        }

    }

    // OnValidate runs after any change in the inspector for this script.
    private void OnValidate()
    {
        Reset();
    }

    // Reset runs when a script is created and when a script is reset from the inspector.
    private void Reset()
    {
        // Get if null
        if (Rigidbody2D == null)
            Rigidbody2D = GetComponent<Rigidbody2D>();
        if (SpriteRenderer == null)
            SpriteRenderer = GetComponent<SpriteRenderer>();
    }
}
