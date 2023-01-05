using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxyAttack : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] LadderMovement ladderScript;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown("g") && !ladderScript.isLadder) {
            attack();   
        }
    }

    void attack() {
        print("Attacking");
        anim.SetTrigger("Attack");
    }
}
