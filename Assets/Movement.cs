using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] int jumpForce;

    void Start()
    {
        jumpForce = 12;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKeyDown("space")) {
            rb.velocity = new Vector3(0, jumpForce, 0);
        }
    }
}
