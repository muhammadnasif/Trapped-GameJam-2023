using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FoxyDeath : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] BoxCollider2D bc;
    [SerializeField] AudioSource deathSound;
    
    public bool isDead;
    float deathJumpForce;

    void Start() {
        deathJumpForce = 14;
        isDead = false;
    }

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.CompareTag("Enemy") || col.gameObject.CompareTag("Trap")) {
            Die();
        }
    }

    public void Die() {
        if(isDead) return;

        isDead = true;
        rb.velocity = new Vector2(0, deathJumpForce);
        bc.enabled = false;
        anim.SetBool("IsHurt", true);
        deathSound.Play();
    }

    void OnBecameInvisible() {
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
    }
}
