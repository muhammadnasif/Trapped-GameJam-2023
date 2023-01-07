using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxyCollectible : MonoBehaviour
{
    List<string> items;

    // Start is called before the first frame update
    void Start()
    {
        items = new List<string>();
    }

    void Update() {
        if(Input.GetKeyDown("s")) {
            showItems();
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.CompareTag("Collectible")) {
            collectItem(col.gameObject);
        }
    }

    public bool hasItem(string itemName) {
        return items.Contains(itemName);
    }

    public void collectItem(GameObject item) {
        items.Add(item.name);
        Destroy(item);
    }

    public int getSkullCount() {
        int count = 0;
        for(int i = 0; i < items.Count; i++) 
            if(items[i].Contains("Skull"))
                count++;
        
        return count;
    }

    public void showItems() {
        string message = "Inventory:\n";
        for(int i = 0; i < items.Count; i++) {
            message += items[i] + ", ";
        }
        print(message);
    }
}
