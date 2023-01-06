using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxyBreakable : MonoBehaviour
{
    GameObject breakableItem = null;
    
    void Start()
    {
        

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("g") && breakableItem != null) {
            print("Breaking stuff");

            // destroy the sprite of the breakable item
            DestroyImmediate(breakableItem.GetComponent<SpriteRenderer>());



            // get the particle system which is a child of the breakable item
            // and play it

            breakableItem.GetComponentInChildren<ParticleSystem>().Play();

            // wait till the animation is over, then destroy the object
            Destroy(breakableItem, 1.0f);
        }
        else if(Input.GetKeyDown("g") && breakableItem == null){
            print("Not breaking stuff");
        }
        
    }



    void OnTriggerEnter2D(Collider2D col) {
        if(!col.gameObject.CompareTag("Breakable")) return;
        print("Breakable");
        breakableItem = col.gameObject;
    }

    void OnTriggerExit2D(Collider2D col) {
        if(!col.gameObject.CompareTag("Breakable")) return;
        breakableItem = null;
    }
}
