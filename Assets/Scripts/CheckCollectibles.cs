using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckCollectibles : MonoBehaviour
{
    public int skullsCount;
    public GameObject foxy;

    private FoxyCollectible collectibleScript;

    // Start is called before the first frame update
    void Start()
    {
        collectibleScript = foxy.GetComponent<FoxyCollectible>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.name == "Foxy with claw") {
            if(collectibleScript.getSkullCount() == skullsCount) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1)               ;
            }
            else {
                print("not enough skulls");
            }
        }
    }
}
