using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] AudioSource deathSoundEffect;
    [SerializeField] AnimationClip deathAnimation;
    private Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
    }

    public void kill() {
        // deathSoundEffect.Play();
        anim.SetBool("isDead", true);
    }

    public void destroyObject() {
        Destroy(gameObject);
    }
}
