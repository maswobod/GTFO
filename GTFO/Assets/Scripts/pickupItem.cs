using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class pickupItem : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter(Collider col)
    {

      if(col.gameObject.tag == "Player"){
          //Only Pickup when inventory not full
          if (Inventory.inventoryList.Count < 5)
          {
              Inventory.inventoryList.Add(23);
              Debug.Log("Cards: " + Inventory.inventoryList.Count);
              Debug.Log("destory", gameObject);
              Destroy(this.gameObject);
          }
      }

    }
}
