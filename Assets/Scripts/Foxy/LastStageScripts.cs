using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LastStageScripts : MonoBehaviour
{
    public TextMeshProUGUI textField = null;

    private string [] messages = {
        "Oh! You are here then",
        "To the very end",
        "Of our journey",
        "Thanks for collecting",
        "All the souls for me",
        "I might have",
        "fooled you sometimes",
        "LOL",
        "DIE BITCH"
    };

    private int index;
    void Start()
    {
        index = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (textField!=null && index <  messages.Length && col.gameObject.CompareTag("Breakable Trigger") ){
            textField.text = messages[index];
            index++;
            Destroy(col.gameObject);
        }
    }
}
