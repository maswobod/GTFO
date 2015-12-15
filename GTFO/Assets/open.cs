using UnityEngine;
using System.Collections;

public class open : MonoBehaviour {
	Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	void OnTriggerEnter(Collider other){
		animator.SetBool ("open",true);
	}
	void OnTriggerExit(Collider other){
		animator.SetBool ("open",false);
	}
}
