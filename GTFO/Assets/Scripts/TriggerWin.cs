using UnityEngine;
using System.Collections;

public class TriggerWin : MonoBehaviour
{
	private GameController controller;
	
	void Start ()
	{
		controller = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") {
			controller.endGameWithSuccess ();
		}
	}
}
