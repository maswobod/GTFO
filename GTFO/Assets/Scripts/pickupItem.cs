using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class pickupItem : MonoBehaviour {

    //Card with Default Value
    public string cardValue = "Karo2";
    private Renderer renderer;

    void Start () {
        renderer = GetComponent<Renderer>();
        Debug.Log(Resources.Load(cardValue));
        renderer.material.mainTexture = Resources.Load(cardValue) as Texture2D;
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
              Inventory.inventoryList.Add(cardValue);
              Debug.Log("Cards: " + Inventory.inventoryList.Count);
              Debug.Log("destory", gameObject);
              Destroy(this.gameObject);
          }
      }

    }
}
