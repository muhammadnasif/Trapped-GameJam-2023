using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                print("proceed to next level");
            }
            else {
                print("not enough skulls");
            }
        }
    }
}
