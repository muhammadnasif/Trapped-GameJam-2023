using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField] int jumpForce;
    [SerializeField] int moveSpeed;

    [SerializeField] LayerMask jumpableGround;


    void Start() {
        jumpForce = 12;
        moveSpeed = 7;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        moveHorizontal();
        jump();
    }

    private void moveHorizontal() {
        float horSpeed = moveSpeed * Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horSpeed, rb.velocity.y);
        anim.SetFloat("HorSpeed", Mathf.Abs(rb.velocity.x));
        if(rb.velocity.x < 0f) sprite.flipX = true;
        if(rb.velocity.x > 0f) sprite.flipX = false;
    }

    private void jump() {
        if(Input.GetButtonDown("Jump") && isGrounded()) {
            rb.velocity = new Vector3(0, jumpForce, 0);
        }
        anim.SetFloat("VerSpeed", rb.velocity.y);
    }

    private bool isGrounded() {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .01f, jumpableGround);
    }
}