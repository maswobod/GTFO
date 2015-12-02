using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
    //Inventory
    static public List<int> inventoryList = new List<int>();

	// Use this for initialization
	void Start () {

        Debug.Log("Before " + inventoryList.Count, gameObject);
        inventoryList.Add(0);
        Debug.Log("Added" + inventoryList.Count, gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Use Card for something
    static public void useItem()
    {
        if (inventoryList.Count > 0)
        {
            inventoryList.Remove(inventoryList.Count - 1);
        }
    }
}
