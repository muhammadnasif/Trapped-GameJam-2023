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

    void Start() {
        claw = transform.Find("Claw").gameObject;
        claw.SetActive(false);
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
        claw.SetActive(true);
        anim.SetTrigger("Attack");
        attackSoundEffect.Play();
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

    private void retrieveClaw() {
        claw.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.CompareTag("Enemy")) {
            col.gameObject.GetComponent<Death>().kill();
        }

        if(col.gameObject.CompareTag("Breakable")) {
            print("Breakable");
            breakStuff(col.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        
    }
}
