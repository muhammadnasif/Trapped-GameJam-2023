using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level6LastTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.name == "Foxy with claw") {
            StartCoroutine(WaitAndLoadMenu(5.0f));
            GlobalScript.hasKey = false;
            GlobalScript.hasMoon = false;
            GlobalScript.messageIndex = 0;
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator WaitAndLoadMenu(float waitTime) {
        yield return new WaitForSeconds(waitTime);
    }
}
