using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;


public class FoxyDeath : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] BoxCollider2D bc;
    [SerializeField] AudioSource deathSound;

    // Final Death
    [SerializeField] AudioSource finalDeathSound;
    [SerializeField] GameObject skullPrefab;

    public bool isDead;
    float deathJumpForce;
    public CinemachineVirtualCamera vcam;
    void Start() {
        deathJumpForce = 14;
        isDead = false;
    }

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.CompareTag("Enemy") || col.gameObject.CompareTag("Trap")) {
            Die();
        }
        else if(col.gameObject.CompareTag("Kill Trigger")){
            // cimeachine camera stops following player
            // player dies

            if (vcam != null) {
                vcam.Follow = null;
            }
            FinalDeath();
            StartCoroutine(WaitAndLoadMenu(5.0f));
            GlobalScript.hasKey = false;
            GlobalScript.hasMoon = false;
            GlobalScript.messageIndex = 0;
            SceneManager.LoadScene(0);
        }
    }

    public void FinalDeath() {
        finalDeathSound.Play();
        Instantiate(skullPrefab, transform.position,  Quaternion.identity);
        rb.velocity = new Vector2(0, deathJumpForce);
        bc.enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }

    IEnumerator WaitAndLoadMenu(float waitTime) {
        yield return new WaitForSeconds(waitTime);
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
        if(!isDead) return;
        
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
    }
}
