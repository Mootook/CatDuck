using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour
{


    #region Variables
    private Rigidbody2D rigibody;
    private readonly KeyCode JUMP_KEY = KeyCode.Space;
    private readonly KeyCode SWAP_KEY = KeyCode.Q;
    private readonly KeyCode DASH_KEY = KeyCode.E;


    public bool isGrounded;
    public Transform isGroundedCheck;
    public float groundCheckRadius = 0.25f;
    public LayerMask groundLayer;

    enum CHAR_STATE { CHAD, FILBERT }
    private CHAR_STATE charState;
    private PlayerInfo chadInfo;
    private PlayerInfo filbertInfo;

    private PlayerInfo activePlayerInfo {
        get
        {
            if (charState == CHAR_STATE.CHAD)
                return chadInfo;
            return filbertInfo;
        }
    }
    private float lateralSpeedMultiplier => activePlayerInfo.lateralSpeedMultipiler;
    private float fallMultiplier => activePlayerInfo.fallMultiplier;
    private float lowJumpMultiplier => activePlayerInfo.lowJumpMultiplier;
    private float jumpMultiplier => activePlayerInfo.jumpMultiplier;


    [Header("Chad Info")]
    public float chadLateralSpeedMultiplier = 3.0f;
    public float chadFallMultiplier = 2.5f;
    public float chadLowJumpMultiplier = 2.0f;
    public float chadJumpMultiplier = 3.0f;

    [Header("Filbert Info")]
    public float filbertLateralSpeedMultiplier = 3.0f;
    public float filbertFallMultiplier = 2.5f;
    public float filbertLowJumpMultiplier = 2.0f;
    public float filbertJumpMultiplier = 3.0f;

    // DEBUG
    private SpriteRenderer sprite;

    #endregion

    private void OnValidate()
    {
        chadInfo = new PlayerInfo();
        chadInfo.lateralSpeedMultipiler = chadLateralSpeedMultiplier;
        chadInfo.fallMultiplier = chadFallMultiplier;
        chadInfo.lowJumpMultiplier = chadLowJumpMultiplier;
        chadInfo.jumpMultiplier = chadJumpMultiplier;

        filbertInfo = new PlayerInfo();
        filbertInfo.lateralSpeedMultipiler = filbertLateralSpeedMultiplier;
        filbertInfo.fallMultiplier = filbertFallMultiplier;
        filbertInfo.lowJumpMultiplier = filbertLowJumpMultiplier;
        filbertInfo.jumpMultiplier = filbertJumpMultiplier;
    }


    // Start is called before the first frame update
    void Start()
    {
        rigibody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();


        SwapToChad();
    }

    // Update is called once per frame
    void Update()
    {

        float xInput = GetLateralMovement();
        float xVel = xInput * lateralSpeedMultiplier;

        ApplyVerticalForce();


        if (InputIsSwap())
            Swap();

        // apply in fixedUpdate?
        rigibody.velocity = new Vector2(xVel, rigibody.velocity.y);

        CheckIfGrounded();
    }

    private void ApplyVerticalForce ()
    {
        if (rigibody.velocity.y < 0)
            rigibody.velocity += GetModifiedGravityForce();
        else if (rigibody.velocity.y > 0 && !Input.GetKey(JUMP_KEY))
            rigibody.velocity += GetLowJumpForce();

        if (AllowJump())
            rigibody.velocity = Vector2.up * jumpMultiplier;
    }


    private Vector2 GetLowJumpForce ()
    {
        return Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
    }
    private Vector2 GetModifiedGravityForce ()
    {
        return Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
    }

    private void Swap ()
    {
        if (charState == CHAR_STATE.CHAD)
            SwapToFilbert();
        else
            SwapToChad();
    }

    private void SwapToFilbert()
    {
        charState = CHAR_STATE.FILBERT;
        sprite.color = Color.yellow;
    }
    
    private void SwapToChad ()
    {
        charState = CHAR_STATE.CHAD;
        sprite.color = Color.green;
    }

    private bool InputIsSwap()
    {
        return Input.GetKeyDown(SWAP_KEY);
    }

    private bool AllowJump ()
    {
        return Input.GetKeyDown(JUMP_KEY) && isGrounded;
    }

    private void CheckIfGrounded ()
    {

        Collider2D collider = Physics2D.OverlapCircle(isGroundedCheck.position, groundCheckRadius, groundLayer);
        if (collider != null)
            isGrounded = true;
        else
            isGrounded = false;

    }

    private float GetLateralMovement ()
    {
        float x = Input.GetAxisRaw("Horizontal");
        return x;
    }
}
