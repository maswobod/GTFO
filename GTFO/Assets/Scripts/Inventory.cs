using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
    //Inventory
    static public List<int> inventoryList = new List<int>();

	// Use this for initialization
	void Start () {

        Debug.Log("Cards: " + inventoryList.Count);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Use Card for something
    static public void useItem()
    {
        if (inventoryList.Count > 0)
        {
            Debug.Log("Remove Card nr: " + inventoryList.Count);
            inventoryList.RemoveAt((inventoryList.Count -1));
            Debug.Log("Cards: " + inventoryList.Count);
        }
    }
}
