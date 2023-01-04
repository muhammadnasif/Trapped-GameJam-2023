using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    private bool isLadder;
    private bool isClimbing;
    private float verSpeed;
    private float initialGravityScale;

    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rb;

    
    void Start() {
        isLadder = false;
        isClimbing = false;
        speed = 7;
        initialGravityScale = rb.gravityScale;
    }

    void Update() {
        verSpeed = Input.GetAxisRaw("Vertical");
        
        if(isLadder && Mathf.Abs(verSpeed) > 0.01f) {
            isClimbing = true;
        }
    }

    private void FixedUpdate() {
        if(!isClimbing) {
            rb.gravityScale = initialGravityScale;
            return;
        }

        rb.gravityScale = 0f;
        rb.velocity = new Vector2(rb.velocity.x, verSpeed*speed);
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if(!coll.CompareTag("Ladder")) return;
        isLadder = true;
    }

    void OnTriggerExit2D(Collider2D coll) {
        if(!coll.CompareTag("Ladder")) return;
        isLadder = false;
        isClimbing = false;
    }
}
