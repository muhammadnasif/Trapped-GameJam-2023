using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionFoxy : MonoBehaviour
{
    [SerializeField] AudioSource landSoundEffect;

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.name == "Terrain") {
            landSoundEffect.Play();
        }
    }
}
