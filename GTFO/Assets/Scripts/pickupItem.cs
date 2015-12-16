using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class pickupItem : MonoBehaviour
{

	private string cardValue ;
	private Inventory inventory;

	void Start ()
	{
		//TODO: move functions calling inventory to gamecontroller
		inventory = GameObject.FindGameObjectWithTag ("GameController").GetComponent <Inventory> ();

	}


	// pickup by walking in 
	public void OnTriggerEnter (Collider col)
	{

		if (col.gameObject.tag == "Player") {
			//Only Pickup when inventory not full
			if (inventory.getInventoryList().Count < 5) {
				inventory.getInventoryList().Add (cardValue);
				Debug.Log ("Cards: " + inventory.getInventoryList().Count);
				Debug.Log ("destory", gameObject);
				Destroy (this.gameObject);
				inventory.updateInventoryDisplayOnCanvas ();
			}
		}
	}
	// set the card value that is added if you pick it up.
	public void SetCardValue(string val){
		cardValue = val;
	}

}
