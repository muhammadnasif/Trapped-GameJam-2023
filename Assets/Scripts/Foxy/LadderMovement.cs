using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    public bool isLadder;
    private float verSpeed;
    private float initialGravityScale;

    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;

    
    void Start() {
        isLadder = false;
        moveSpeed = 7;
        initialGravityScale = rb.gravityScale;
    }

    void Update() {
        if(!isLadder) {
            rb.gravityScale = initialGravityScale;
            return;
        }

        rb.gravityScale = 0f;                       // turn off gravity
        verSpeed = Input.GetAxisRaw("Vertical");    // get keypress
        rb.velocity = new Vector2(rb.velocity.x, verSpeed*moveSpeed); // add velocity
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if(!coll.CompareTag("Ladder")) return;
        isLadder = true;
        anim.SetBool("IsLadder", true);
    }

    void OnTriggerExit2D(Collider2D coll) {
        if(!coll.CompareTag("Ladder")) return;
        isLadder = false;
        anim.SetBool("IsLadder", false);
    }
}
