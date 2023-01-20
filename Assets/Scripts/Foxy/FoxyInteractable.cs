using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

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
        if(curItem != null) {
            
            if(curItem.name == "Door" && GlobalScript.hasKey) {
                createFile("You need the moon", "Its not the end.txt");
                SceneManager.LoadScene("Level 5");
                return;
            }
            
            // print("Consume or Hold?");
            // if(InteractableText != null){
            //     InteractableText.enabled = true;
            // }
            // Time.timeScale = 0;
        }


        // else if(Time.timeScale == 0 ){
        //     if(Input.GetKeyDown(KeyCode.Escape)){
        //         Time.timeScale = 1;
        //         if(InteractableText != null){
        //             InteractableText.enabled = false;
        //         }
        //     }
        // }
    }

    async void createFile(string message, string path) {
        await File.WriteAllTextAsync(path, message);
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
