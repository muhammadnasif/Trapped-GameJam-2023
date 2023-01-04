using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.name == "Foxy") {
            int totalScenes = SceneManager.sceneCountInBuildSettings;
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            
            if(nextSceneIndex < totalScenes) {
                SceneManager.LoadScene(nextSceneIndex);
            }
            else {
                Debug.Log("No scenes next");
            }
        }
    }
}
