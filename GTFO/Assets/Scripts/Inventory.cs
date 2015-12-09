using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
    //Inventory
    static public List<string> inventoryList = new List<string>();

    /* Int value = Card value
     * Card deck in Strings
     * Herz = Herz2 -> HerzA 
     * Kreuz = Kreuz2 -> KreuzA (2 3 4 5 6 7 8 9 10 B D K A)
     * Pik = Pik2 -> PikA
     * Karo = Karo2 -> KaroA
     */

    private Image[] image;
    private string[] array = new string[] { "Herz2", "Herz3", "Herz4", "Herz5", "Herz6", "Herz7", "Herz8", "Herz9", "Herz10", "HerzB", "HerzD", "HerzK", "HerzA",
        "Kreuz2", "Kreuz3", "Kreuz4", "Kreuz5", "Kreuz6", "Kreuz7", "Kreuz8", "Kreuz9", "Kreuz10", "KreuzB", "KreuzD", "KreuzK", "KreuzA",
        "Pik2", "Pik3", "Pik4", "Pik5", "Pik6", "Pik7", "Pik8", "Pik9", "Pik10", "PikB", "PikD", "PikK", "PikA",
        "Karo2", "Karo3", "Karo4", "Karo5", "Karo6", "Karo7", "Karo8", "Karo9", "Karo10", "KaroB", "KaroD", "KaroK", "KaroA" };

    private List<string> cards;

    // Use this for initialization
    void Start () {
        //Start with 5 Random Cards
        /*cards = new List<string>(array);
        for (int i = 0; i < 5; i++)
        {
            int num = Random.Range(0, cards.Count);
            Inventory.inventoryList.Add(cards[num]);
            cards.RemoveAt(num);


        }

        Debug.Log("Cards: " + inventoryList.Count);

        image = GameObject.FindGameObjectWithTag("Canvas").GetComponentsInChildren<Image>();

        for (int i = 0; i < inventoryList.Count; i++)
        {

            var name = inventoryList[i];
            var name2 = name.ToString();
            var sprite = (Sprite)Resources.Load(name2, typeof(Sprite));

            image[i].sprite = sprite;
        }*/

    }

    // Update is called once per frame
    void Update () {
	
	}

    //Use Card for something
    static public void useItem(string cardToOpen)
    {
        if (inventoryList.Count > 0)
        {
            Debug.Log("Remove Card nr: " + inventoryList.Count);
            inventoryList.Remove(cardToOpen);
            Debug.Log("Cards: " + inventoryList.Count);
        }
    }
}
