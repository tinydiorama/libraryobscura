using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerPlatformerController : PhysicsObject
{

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public float defaultSpeed = 5;
    public bool isInMidAir;
    private float prevYVelocity;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public bool facingRight;
    private GameManager gm;

    public event UnityAction onJump;
    public event UnityAction onLand;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        gm = GameManager.GetInstance();
    }

    protected override void ComputeVelocity()
    {
        if ( ! gm.isPaused )
        {
            Vector2 move = Vector2.zero;
            Vector2 inputVector = InputManager.GetInstance().GetMoveDirection();

            move.x = inputVector.x;

            if (InputManager.GetInstance().GetJumpPressed() && grounded)
            {
                velocity.y = jumpTakeOffSpeed;
            }
            else if (InputManager.GetInstance().GetJumpPressed())
            {
                if (velocity.y > 0)
                {
                    velocity.y = velocity.y * 0.5f;
                }
            }

            if (inputVector.x > 0.5f || inputVector.x < -0.5f)
            {
                if (inputVector.x > 0.5f && facingRight)
                {
                    Flip();
                    facingRight = false;
                }
                else if (inputVector.x < 0.5f && !facingRight)
                {
                    Flip();
                    facingRight = true;
                }
            }

            animator.SetBool("grounded", grounded);
            animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

            targetVelocity = move * maxSpeed;
        } else
        {
            Vector2 move = Vector2.zero;
            animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);
            targetVelocity = move * maxSpeed;
        }

        if (velocity.y != 0)
        {
            if (prevYVelocity == 0)
            {
                isInMidAir = true;
                onJump?.Invoke();
            }
        }
        if (velocity.y == 0)
        {
            if (prevYVelocity != 0)
            {
                isInMidAir = false;
                onLand?.Invoke();
            }
        }
        prevYVelocity = velocity.y;
    }

    public void stopPlayer()
    {
        velocity.x = 0;
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);
    }

    public void Flip()
    {
        // Switch the way the player is labelled as facing
        facingRight = !facingRight;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }

    public void faceLeft()
    {
        facingRight = true;
        spriteRenderer.flipX = true;
    }
}