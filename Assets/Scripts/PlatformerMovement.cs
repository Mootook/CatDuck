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

    private AudioSource audioSource;
    public AudioClip highFive;

    private bool hasUsedAirborneDash = false;
    private bool isFacingRight = true;
    private bool isDashing;
    private bool isGrounded;
    public Transform isGroundedCheck;
    public float groundCheckRadius = 0.25f;
    public LayerMask groundLayer;

    public enum CHAR_STATE { CHAD, FILBERT }
    private CHAR_STATE charState;

    public GameObject chad;
    public GameObject filbert;
    public GameObject highFiveGameObject;

    private PlayerState chadState;
    private PlayerState filbertState;
    private PlayerState activePlayerState {
        get
        {
            if (isChad())
                return chadState;
            return filbertState;
        }
    }

    private Animator chadAnimator;
    private Animator filbertAnimator;
    private Animator animator
    {
        get
        {
            if (isChad())
                return chadAnimator;
            return filbertAnimator;
        }
    }

    private float lateralSpeedMultiplier => activePlayerState.lateralSpeedMultipiler;
    private float fallMultiplier => activePlayerState.fallMultiplier;
    private float lowJumpMultiplier => activePlayerState.lowJumpMultiplier;
    private float jumpMultiplier => activePlayerState.jumpMultiplier;
    private float dashDistance => activePlayerState.dashDistance;

    private AudioClip walkingSound => activePlayerState.walkingSound;
    private AudioClip jumpSound => activePlayerState.jumpSound;
    private AudioClip dashSound => activePlayerState.dashSound;
    #endregion

    #region Lifecycle
    void Start()
    {
        rigibody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        chadState = chad.GetComponent<PlayerState>();
        chadAnimator = chad.GetComponent<Animator>();

        filbertState = filbert.GetComponent<PlayerState>();
        filbertAnimator = filbert.GetComponent<Animator>();

        highFiveGameObject.SetActive(false);
        SwapToChad();
    }

    void Update()
    {
        if (InputIsSwap())
            Swap();
        ApplyVerticalForce();
        ApplyHorizontalForce();

        CheckIfGrounded();
    }
    #endregion


    private void ApplyVerticalForce ()
    {
        if (!isDashing)
        {
            if (rigibody.velocity.y < 0)
                rigibody.velocity += GetModifiedGravityForce();
            else if (rigibody.velocity.y > 0 && !Input.GetKey(JUMP_KEY))
                rigibody.velocity += GetLowJumpForce();

            if (AllowJump())
            {
                if (!PauseMenu.GameIsPaused)
                    audioSource.PlayOneShot(jumpSound);
                rigibody.velocity = Vector2.up * jumpMultiplier;
            }

            animator.SetFloat("VerticalVelocity", rigibody.velocity.y);
        }
    }
    private void ApplyHorizontalForce ()
    {

        float xInput = GetLateralMovement();
        float xVel = xInput * lateralSpeedMultiplier;
        if (!isDashing)
        {
            if (!PauseMenu.GameIsPaused)
            {
                UpdateAnimator(xInput);
                UpdateFaceDirection(xInput);
            }

            rigibody.velocity = new Vector2(xVel, rigibody.velocity.y);
        }

        if (AllowDash() && Mathf.Abs(xInput) > 0)
            StartCoroutine(Dash(xInput));
    }
    private void UpdateFaceDirection (float xVel)
    {
        if (xVel > 0 && !isFacingRight)
            Flip();
        else if (xVel < 0 && isFacingRight)
            Flip();
    }

    private void Flip ()
    {
        isFacingRight = !isFacingRight;

        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void UpdateAnimator (float xVel)
    {
        animator.SetFloat("Speed", Mathf.Abs(xVel));
    }

    private Vector2 GetLowJumpForce ()
    {
        return Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
    }
    private Vector2 GetModifiedGravityForce ()
    {
        return Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
    }

    public bool isChad ()
    {
        return charState == CHAR_STATE.CHAD;
    }

    public bool isFilbert()
    {
        return charState == CHAR_STATE.FILBERT;
    }

    private void Swap ()
    {
        if (isChad())
            SwapToFilbert();
        else
            SwapToChad();

        if (!PauseMenu.GameIsPaused)
            PlayHighFive();
    }

    private void PlayHighFive ()
    {
        audioSource.PlayOneShot(highFive);
        highFiveGameObject.SetActive(true);
    }
    
    private void SwapToChad ()
    {
        charState = CHAR_STATE.CHAD;
        chad.SetActive(true);
        filbert.SetActive(false);
    }

    private void SwapToFilbert()
    {
        charState = CHAR_STATE.FILBERT;
        filbert.SetActive(true);
        chad.SetActive(false);
    }

    private bool InputIsSwap()
    {
        return Input.GetKeyDown(SWAP_KEY);
    }

    private bool AllowDash ()
    {
        return Input.GetKeyDown(DASH_KEY) && !hasUsedAirborneDash;
    }

    private bool AllowJump ()
    {
        return Input.GetKeyDown(JUMP_KEY) && isGrounded;
    }

    private void CheckIfGrounded ()
    {

        Collider2D collider = Physics2D.OverlapCircle(isGroundedCheck.position, groundCheckRadius, groundLayer);
        if (collider != null)
        {
            isGrounded = true;
            hasUsedAirborneDash = false;
        }
        else
            isGrounded = false;

    }

    private float GetLateralMovement ()
    {
        float x = Input.GetAxisRaw("Horizontal");
        return x;
    }

    IEnumerator Dash (float xDir)
    {
        isDashing = true;
        animator.SetBool("isDashing", true);
        rigibody.velocity = new Vector2(rigibody.velocity.x, 0.0f);
        rigibody.AddForce(new Vector2(dashDistance * xDir, 0.0f), ForceMode2D.Impulse);

        if (!PauseMenu.GameIsPaused)
            audioSource.PlayOneShot(dashSound);

        // cache the current gravityScale
        float gravityScale = rigibody.gravityScale;
        rigibody.gravityScale = 0.0f;

        yield return new WaitForSeconds(0.3f);

        isDashing = false;
        animator.SetBool("isDashing", false);
        rigibody.gravityScale = gravityScale;

        // guard against infinite dashing
        if (!isGrounded)
            hasUsedAirborneDash = true;
    }

    // move this
    public void HighFiveDidComplete ()
    {
        Debug.Log("HIGH FIVED");
    }
}
