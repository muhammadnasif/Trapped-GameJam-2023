using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndingBranching : MonoBehaviour
{
    public int skullsCount;
    public GameObject foxy;

    private FoxyCollectible collectibleScript;

    // Start is called before the first frame update
    void Start()
    {
        collectibleScript = foxy.GetComponent<FoxyCollectible>();
    }


    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.name == "Foxy with claw") {
            if(collectibleScript.getSkullCount() == skullsCount) {
                if(GlobalScript.hasMoon) SceneManager.LoadScene("Level 6");
                else SceneManager.LoadScene("Final Run");
            }
            else {
                print("not enough skulls");
            }
        }
    }
}
