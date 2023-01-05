using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxyInteractable : MonoBehaviour
{
    GameObject curItem;

    void Start()
    {
        curItem = null;
    }

    void Update()
    {
        if(Input.GetKeyDown("f") && curItem != null) {
            print("Consume or Hold?");
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if(!col.gameObject.CompareTag("Interactable")) return;
        curItem = null;
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(!col.gameObject.CompareTag("Interactable")) return;
        curItem = col.gameObject;
    }
}
