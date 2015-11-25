using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class EnemyAI : MonoBehaviour
{
	public Transform[] points;
	private int destPoint = 0;
	private NavMeshAgent agent;
	public float hearingDistance;
	private FirstPersonController fpsController;
	private bool playerInSight;
	public float fieldOfViewAngle = 180;
	private SphereCollider col;
	private GameObject player;
	private GameController gameController;

	void Start ()
	{
		agent = GetComponent<NavMeshAgent> ();
		// Disabling auto-braking allows for continuous movement
		// between points (ie, the agent doesn't slow down as it
		// approaches a destination point).
		agent.autoBraking = false;
		GotoNextPoint ();

		player = GameObject.FindGameObjectWithTag ("Player");
		gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		fpsController = player.GetComponent<FirstPersonController> ();
		col = GetComponent<SphereCollider> ();
	}

	void Update ()
	{
		Debug.Log (this.gameObject.transform.up);
		if (Vector3.Distance (transform.position, player.transform.position) > hearingDistance || fpsController.IsSneaking ()) { 
			/*when not in seight make patrol*/
			playerInSight=false;
			if(agent.remainingDistance <0.5f){
				GotoNextPoint ();
			}
		} else {
			/*Follow the player*/
			agent.destination = player.transform.position+Vector3.up; /***Vector3.Up ist ein Vektor (0,1,0), Vector3.one ist (1,1,1)***/
			playerInSight=true;
		}
		
	}

	void GotoNextPoint ()
	{
		// Returns if no points have been set up
		if (points.Length == 0) {
			return;
		}
		Debug.Log ("going to: " + destPoint);

		// Set the agent to go to the currently selected destination.
		agent.destination = points [destPoint].position;
		
		// Choose the next point in the array as the destination,
		// cycling to the start if necessary.
		destPoint = (destPoint + 1) % points.Length;
	}

	void OnTriggerStay (Collider other)
	{
		//Debug.Log ("on trigger stay: " + other.tag);
		// If the player has entered the trigger sphere...
		if (other.tag == "Player") {
			// By default the player is not in sight.
			//playerInSight = false;
			//Debug.Log("player");
			// Create a vector from the enemy to the player and store the angle between it and forward.
			//Vector3 direction = other.transform.position - transform.forward;
			Vector3 direction = other.transform.position - (transform.position+Vector3.up); /***Vektor von dem Gegner + Vector3 nach oben, hin zur Position 
			des Spielers. Das mit dem Vektor3.Up hab ich gemacht, weil der Pivot Punkt des Gegners an seinen Füßen ist und der des SPielers in der Mitte***/

			Debug.DrawRay(transform.position+transform.up, direction.normalized*col.radius, Color.green); /***gut zum debuggen, 
			hatte ich vergessen, dass es die Methode noch gibt ;) ***/

			float angle = Vector3.Angle (direction, transform.forward);
			// If the angle between forward and where the player is, is less than half the angle of view...
			if (angle < fieldOfViewAngle * 0.5f) 
			{
				RaycastHit hit;
				Debug.Log ("in Field of View");
				// ... and if a raycast towards the player hits something...

				if (Physics.Raycast (transform.position + Vector3.up, direction.normalized, out hit /*, col.radius*100 this does infinity ?*/ )) /*** +transform.up oder +Vector.up, 
				sollte eigentlich egal sein welches von beiden man nimmt ***/
				{ 

					// ... and if the raycast hits the player...
					//Debug.Log (hit.collider.gameObject);

					if (hit.collider.gameObject == player.gameObject) 
					{
						// ... the player is in sight.
						playerInSight = true;
						//transform.LookAt (player.transform.position);/*** konnte komplett raus, der Agent macht das automatisch***/
						//Debug.Log ("And SEE you");
						agent.destination = player.transform.position; /*** An dieser Stelle noch das neue Target setzen. 
						Sonst wird das bis jetzt nirgends getan (Zumindest soweit ich gesehn habe***/
						if(Vector3.Distance(player.transform.position,transform.position)<2.0f)
						{
							gameController.endGameWithLoose(); 
						}
					}
				} 
//				else 
//				{
//					Debug.Log ("But something is in the way");
//					
//				}
			}
		}
	}
}
