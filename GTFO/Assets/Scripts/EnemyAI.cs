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
    private Animator animator;
    private AnimatorSetup animSetup;
    public float speedDampTime = 0.1f;              // Damping time for the Speed parameter.
    public float angularSpeedDampTime = 0.7f;       // Damping time for the AngularSpeed parameter
    public float angleResponseTime = 0.6f;          // Response time for turning an angle into angularSpee
    public float angle = 0;

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
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    


        //agent.updateRotation = false;
    }

	void Update ()
	{
		Debug.Log (player);
		if (Vector3.Distance (transform.position, player.transform.position) > hearingDistance || fpsController.IsSneaking ()) { 
			/*when not in sight make patrol*/
			if(agent.remainingDistance < 0.5f){
				GotoNextPoint ();
			}
		}
        else {
			/*Follow the player*/
			//agent.destination = player.transform.position+Vector3.one;
			agent.destination = player.transform.position+Vector3.up; /***Vector3.Up ist ein Vektor (0,1,0), Vector3.one ist (1,1,1)***/

		}
        float angularSpeed = angle / angleResponseTime;

        // Set the mecanim parameters and apply the appropriate damping to them.
        animator.SetFloat("Speed", agent.speed, speedDampTime, Time.deltaTime);
        animator.SetFloat("AngularSpeed", angularSpeed, angularSpeedDampTime, Time.deltaTime);

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
            Debug.Log("Player gesichtet");
			// By default the player is not in sight.
			//playerInSight = false;
			//Debug.Log("player");
			// Create a vector from the enemy to the player and store the angle between it and forward.
			//Vector3 direction = other.transform.position - transform.forward;
			Vector3 direction = other.transform.position - (transform.position+Vector3.up); /***Vektor von dem Gegner + Vector3 nach oben, hin zur Position 
			des Spielers. Das mit dem Vektor3.Up hab ich gemacht, weil der Pivot Punkt des Gegners an seinen Füßen ist und der des SPielers in der Mitte***/

			Debug.DrawRay(transform.position+transform.up, direction.normalized*col.radius, Color.green); /***gut zum debuggen, 
			hatte ich vergessen, dass es die Methode noch gibt ;) ***/

			angle = Vector3.Angle (direction, transform.forward);
			// If the angle between forward and where the player is, is less than half the angle of view...
			if (angle < fieldOfViewAngle * 0.5f) 
			{
				RaycastHit hit;
				Debug.Log ("in Field of View");
				// ... and if a raycast towards the player hits something...
				//Debug.DrawRay(transform.position + transform.up +transform.forward, direction.normalized*10);
				//if(Physics.Raycast(transform.position + transform.up +transform.forward, direction.normalized*10, out hit, col.radius))
				//if (Physics.Raycast (transform.position + transform.up, direction.normalized, out hit, col.radius)) {
				if (Physics.Raycast (transform.position + Vector3.up, direction.normalized, out hit, col.radius)) /*** +transform.up oder +Vector.up, 
				sollte eigentlich egal sein welches von beiden man nimmt ***/
				{ 

					// ... and if the raycast hits the player...
					//Debug.Log (hit.collider.gameObject);

					if (hit.collider.gameObject == player.gameObject) 
					{
						// ... the player is in sight.
						playerInSight = true;
						//transform.LookAt (player.transform.position);/*** konnte komplett raus, der Agent macht das automatisch***/
						Debug.Log ("And SEE you");
						agent.destination = player.transform.position; /*** An dieser Stelle noch das neue Target setzen. 
						Sonst wird das bis jetzt nirgends getan (Zumindest soweit ich gesehn habe***/
						if(Vector3.Distance(player.transform.position,transform.position)<2.0f)
						{
							gameController.endGameWithLoose(); //Besser in der Start() schon suchen
						}
					}
				} 
				else 
				{
					Debug.Log ("But something is in the way");
					
				}
			}
		}
	}

    public bool isPlayerInSight()
    {
        return this.playerInSight;
    }

   
   
}
