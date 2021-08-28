using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour
{
    private Rigidbody2D rigibody;

    public float laterSpeedMultiplier = 3.0f;
    public float jumpForce = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigibody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = GetLateralMovement();
        float xVel = xInput * laterSpeedMultiplier;
        float yVel = rigibody.velocity.y;

        if (InputIsJump())
            yVel = jumpForce;

        rigibody.velocity = new Vector2(xVel, yVel);
    }

    private bool InputIsJump ()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    private float GetLateralMovement ()
    {
        float x = Input.GetAxisRaw("Horizontal");
        return x;
    }
}
