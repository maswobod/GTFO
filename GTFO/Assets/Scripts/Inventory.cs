using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
    //Inventory
    static public List<int> inventoryList = new List<int>();

    /* Int value = Card value
     * Card deck = 52 Cards (Values 0-51)
     * Clubs = 0 - 12 (A 2 3 4 5 6 7 8 9 10 J Q K)
     * Diamonds = 13 - 25
     * Hearts = 26 - 38
     * Spades = 39 - 51
     */

	// Use this for initialization
	void Start () {
        //Start with 5 Random Cards
        Inventory.inventoryList.Add(Random.Range(0, 51));
        Inventory.inventoryList.Add(Random.Range(0, 51));
        Inventory.inventoryList.Add(Random.Range(0, 51));
        Inventory.inventoryList.Add(Random.Range(0, 51));
        Inventory.inventoryList.Add(Random.Range(0, 51));
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
