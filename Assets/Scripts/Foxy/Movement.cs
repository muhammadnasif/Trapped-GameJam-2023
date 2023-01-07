using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;

    private bool facingRight = true;

    public float jumpForce;
    public float moveSpeed;
    [SerializeField] LayerMask jumpableGround;
    [SerializeField] AudioSource jumpSoundEffect;
    [SerializeField] AudioSource landSoundEffect;
    [SerializeField] AudioSource walkSoundEffect;
    [SerializeField] FoxyDeath deathScript;

    void Start() {
        // jumpForce = 12;
        // moveSpeed = 7;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        if(deathScript.isDead) return;
        
        moveHorizontal();
        jump();
    }

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.name == "Terrain" && isGrounded()) {
            landSoundEffect.Play();
        }
    }

    private void moveHorizontal() {
        float horSpeed = moveSpeed * Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horSpeed, rb.velocity.y);
        anim.SetFloat("HorSpeed", Mathf.Abs(rb.velocity.x));
        
        // trying to go left but facing right
        if(rb.velocity.x < 0f && facingRight) {
            flipHorizontal();
        }

        // trying to go right but facing left        
        if(rb.velocity.x > 0f && !facingRight) { 
            flipHorizontal();
        }

        if(Mathf.Abs(rb.velocity.x) > 0.01 && isGrounded()) {
            if(!walkSoundEffect.isPlaying) walkSoundEffect.Play();
        }
        else {
            walkSoundEffect.Stop();
        }
    }

    private void flipHorizontal() {
        Vector3 newScale = rb.transform.localScale;
        newScale.x *= -1;
        rb.transform.localScale = newScale;
        facingRight = !facingRight;
    }

    private void jump() {
        if(Input.GetButtonDown("Jump") && isGrounded()) {
            rb.velocity = new Vector3(0, jumpForce, 0);
            jumpSoundEffect.Play();
        }        
        anim.SetFloat("VerSpeed", Mathf.Abs(rb.velocity.y));
        if(rb.velocity.y > 0f)  anim.SetBool("VerDir", true);
        else                    anim.SetBool("VerDir", false);
    }

    private bool isGrounded() {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .01f, jumpableGround);
    }
}
