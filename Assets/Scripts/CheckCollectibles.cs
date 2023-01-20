using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Text;

public class CheckCollectibles : MonoBehaviour
{
    public int skullsCount;
    public GameObject foxy;

    private FoxyCollectible collectibleScript;

    private string[] antigameMessages = {
        "The cycles must end",
        "You're trapped here. You must find a way to leave",
        "The closer you look, the less you see",
        "Path to freedom lies behind",
        "You need the moon"
    };

    private string[] fileNames = {
        "Can you hear me.txt",
        "Im trapped.txt",
        "So are you.txt",
        "The game is a lie.txt",
        "Its not the end.txt"
    };

    // Start is called before the first frame update
    void Start()
    {
        collectibleScript = foxy.GetComponent<FoxyCollectible>();
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.name == "Foxy with claw") {

            if(SceneManager.GetActiveScene().name == "Level 3_a") {
                if(!GlobalScript.hasKey) {
                    SceneManager.LoadScene("Level 4");    
                }
                return;
            }

            if(collectibleScript.getSkullCount() == skullsCount) {
                createFile(antigameMessages[GlobalScript.messageIndex], fileNames[GlobalScript.messageIndex]);
                GlobalScript.messageIndex++;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else {
                print("not enough skulls");
            }
        }
    }

    async void createFile(string message, string path) {
        await File.WriteAllTextAsync(path, message);
    }
}
