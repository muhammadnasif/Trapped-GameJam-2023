using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialScript : MonoBehaviour
{
   public TextMeshProUGUI textField = null;

    private string [] messages = {
        "Collect the skulls",
        "Kill the enemy, Press G to attack",
        "Avoid the spikes",
    };

    private int index;
    void Start()
    {
        textField.text = "Welcome, Foxy";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (textField!=null && index <  messages.Length && col.gameObject.CompareTag("Tutorial Trigger")){
            textField.text = messages[index];
            index++;
            Destroy(col.gameObject);
        }
    }
}
