using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

    private Animator animator;

    // Use this for initialization
    
    private Vector3 startRot;
    private Vector3 endRot;
    private bool doorOpen;
	private bool canOpen = false;

    public float angleDoor = 90;
    public float smooth = 1;
    

    void Start () {

        //animator = GetComponent<Animator>();
        
        doorOpen = false;
        startRot = transform.eulerAngles;
        endRot = new Vector3(startRot.x, startRot.y + angleDoor, startRot.z);

    }
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("allowed: "+canOpen);
        if (canOpen) {
			//Open door
			if (doorOpen) {
				transform.eulerAngles = Vector3.Slerp (transform.eulerAngles, endRot, Time.deltaTime * smooth);
			}

			//Close door
			if (!doorOpen) {
				transform.eulerAngles = Vector3.Slerp (transform.eulerAngles, startRot, Time.deltaTime * smooth);
			}

			if (Input.GetKeyDown ("f") && transform.eulerAngles.y < 1) {
				doorOpen = true;
			}
        
			if (Input.GetKeyDown ("f") && transform.eulerAngles.y > 75) {
				doorOpen = false;
			}
       

//       if (Input.GetKeyDown("f") && !animator.GetBool("openDoor")) {
//           animator.SetBool("openDoor", true);
//           Debug.Log("If 1");
//       }
//
//       else if (Input.GetKeyDown("f") && animator.GetBool("openDoor"))
//       {
//           animator.SetBool("openDoor", false);
//           Debug.Log("If 2");
//       }
		}
    }
	void OnTriggerEnter(Collider collider){
		canOpen = true;
	}
	void OnTriggerExit(Collider collider){
		canOpen = false;
	}
}
