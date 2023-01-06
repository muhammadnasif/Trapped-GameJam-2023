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

    private void retrieveClaw() {
        claw.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.CompareTag("Enemy")) {
            col.gameObject.GetComponent<Death>().kill();
        }
    }
}
