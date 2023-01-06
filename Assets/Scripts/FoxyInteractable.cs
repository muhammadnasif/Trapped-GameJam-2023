using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoxyInteractable : MonoBehaviour
{
    GameObject curItem;
    public Canvas InteractableText = null;

    void Start()
    {
        curItem = null;
        if(InteractableText != null){
            InteractableText.enabled = false;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown("f") && curItem != null) {
            print("Consume or Hold?");
            if(InteractableText != null){
                InteractableText.enabled = true;
            }
            Time.timeScale = 0;
        }


        else if(Time.timeScale == 0 ){
            if(Input.GetKeyDown(KeyCode.Escape)){
                Time.timeScale = 1;
                if(InteractableText != null){
                    InteractableText.enabled = false;
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if(!col.gameObject.CompareTag("Interactable")) return;
        curItem = null;
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(!col.gameObject.CompareTag("Interactable")) return;
        print("Interactable");
        curItem = col.gameObject;
    }

    public void Consume(){
        print("Consume");
        Time.timeScale = 1;
        if(InteractableText != null){
            InteractableText.enabled = false;
        }
        Destroy(curItem);

    }
    public void Hold(){
        print("Hold");
        Time.timeScale = 1;
        if(InteractableText != null){
            InteractableText.enabled = false;
        }
        Destroy(curItem);
    }
}
