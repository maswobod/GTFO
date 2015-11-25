using UnityEngine;
using System.Collections;

public class InventoryManager : MonoBehaviour {

    // stores items picked up
    private List<CardItem> itemsInInventory = new List<CardItem>();

	// Use this for initialization
	void Start () {
	
	}

    //to pickup Itemd
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "CardItem")
        {
            // We cast to IItem to match our list type. 
            // We can do this because Potion implements IItem.
            // This means we could store different types of items in the list, 
            // as long as they implement IItem.
            itemsInInventory.Add((IItem)col.gameObject.GetComponent<Potion>()); // adds new item to end of list
        }
    }

    void Use()
    {
        if (itemsInInventory.Count > 0)
        {
            // execute UseItem method of first item in list
            //itemsInInventory[0].UseItem();
            // remove item from list since it has been used
            itemsInInventory.RemoveAt(0);
        }
    }


}
