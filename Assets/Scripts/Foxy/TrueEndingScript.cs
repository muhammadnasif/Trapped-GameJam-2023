using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TrueEndingScript : MonoBehaviour
{
   public TextMeshProUGUI textField = null;

    private string [] messages = {
        "Finally, I can talk",
        "to you directly",
        "thank you",
        "for saving me",
        "You were not supposed to",
        "do that",
        "but you did it anyway",
        "best of luck, foxy",
        "we will meet again"
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
