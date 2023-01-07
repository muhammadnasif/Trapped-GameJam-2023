using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] AudioSource deathSoundEffect;

    void Start() {
        deathSoundEffect.Play();
    }

    public void destroyObject() {
        Destroy(this.gameObject);
    }
}
