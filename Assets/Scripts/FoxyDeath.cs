using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FoxyDeath : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] BoxCollider2D bc;
    
    bool isDead;
    float deathJumpForce;

    void Start() {
        deathJumpForce = 14;
        isDead = false;
    }

    public void Die() {
        if(isDead) return;

        isDead = true;
        rb.velocity = new Vector2(0, deathJumpForce);
        bc.enabled = false;
        anim.SetBool("IsHurt", true);
    }

    void OnBecameInvisible() {
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
    }
}
