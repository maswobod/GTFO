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
            Inventory.inventoryList.Add(23);
            Debug.Log("destory", gameObject);
            Destroy(this.gameObject);
      }

    }
}
