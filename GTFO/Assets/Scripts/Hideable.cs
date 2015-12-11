using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class Hideable : MonoBehaviour {
	private FirstPersonController fps;




	// Use this for initialization
	void Start () {
		fps = GameObject.FindGameObjectWithTag ("Player").GetComponent<FirstPersonController> ();;
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			fps.setHideing (true);
		}
	}
	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			fps.setHideing (false);
		}
	}

}
