using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject onDeath;

    void Start() {
    
    }

    public void kill() {
        Instantiate(onDeath, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
