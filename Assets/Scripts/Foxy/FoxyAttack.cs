using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxyAttack : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] LadderMovement ladderScript;
    [SerializeField] AudioSource attackSoundEffect;

    private List<GameObject> inAttackRange = new List<GameObject>();
    private GameObject claw;

    private bool isClawActive = false;

    void Start() {
        claw = transform.Find("Claw").gameObject;
        claw.SetActive(false);
        claw.GetComponent<BoxCollider2D>().enabled = false;
    }

    void Update() {
        // attack starts
        if(Input.GetKeyDown("g") && !ladderScript.isLadder) {
            activateClaw();
        }

        // attack ends
        if(Input.GetKeyUp("g") && !ladderScript.isLadder) {
            retrieveClaw();    
        }
    }

    private void activateClaw() {
        isClawActive = true;
        claw.SetActive(true);
        claw.GetComponent<BoxCollider2D>().enabled = true;
        anim.SetTrigger("Attack");
        attackSoundEffect.Play();
    }

    private void retrieveClaw() {
        isClawActive = false;
        claw.SetActive(false);
        claw.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void breakStuff(GameObject breakableItem) {
        if(breakableItem == null) return;

        // destroy the sprite of the breakable item
        DestroyImmediate(breakableItem.GetComponent<SpriteRenderer>());
        // get the particle system which is a child of the breakable item
        // and play it
        breakableItem.GetComponentInChildren<ParticleSystem>().Play();
        // wait till the animation is over, then destroy the object
        Destroy(breakableItem, 1.0f);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.CompareTag("Enemy") && isClawActive) {
            col.gameObject.GetComponent<Death>().kill();
        }

        if(col.gameObject.CompareTag("Breakable") && isClawActive) {
            print("Breakable");
            breakStuff(col.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        
    }
}
