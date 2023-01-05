using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionFoxy : MonoBehaviour
{
    FoxyDeath deathScript;

    void Start() {
        deathScript = GetComponent<FoxyDeath>();
    }

    void OnCollisionEnter2D(Collision2D col) {
        
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.CompareTag("Trap")) {
            deathScript.Die();
        }
    }
}
