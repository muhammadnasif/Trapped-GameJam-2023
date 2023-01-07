using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public bool isHidden = true;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(!isHidden);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isHidden){
            this.gameObject.SetActive(true);
        }
    }
}
