using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D coll;

    [SerializeField] int jumpForce;
    [SerializeField] int moveSpeed;

    [SerializeField] LayerMask jumpableGround;


    void Start() {
        jumpForce = 12;
        moveSpeed = 7;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Update() {
        moveHorizontal();
        jump();
    }

    private void moveHorizontal() {
        float dirX = moveSpeed * Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    private void jump() {
        if(Input.GetButtonDown("Jump") && isGrounded()) {
            rb.velocity = new Vector3(0, jumpForce, 0);
        }
    }

    private bool isGrounded() {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .01f, jumpableGround);
    }
}
