using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class EnemyAI : MonoBehaviour
{

	public Transform[] Waypoints;
	public float Speed;
	public int curWayPoint;
	public bool doPatrol = true;
	public Vector3 Target;
	public Vector3 MoveDirection;
	public Vector3 Velocity;
	Transform tr_player; /* FPS Controller*/
	public float hoerfeld;
	private FirstPersonController fpsController;
	private bool playerInSight;
	public float fieldOfViewAngle=180;
	private SphereCollider col;     
	private GameObject player;
	void Start ()
	{
		tr_player = GameObject.FindGameObjectWithTag ("Player").transform;
		player = GameObject.FindGameObjectWithTag ("Player");
		fpsController = tr_player.GetComponent<FirstPersonController> ();
		col = GetComponent<SphereCollider>();
	}

	void Update ()
	{
		transform.LookAt (tr_player);

		
			if (Vector3.Distance (transform.position, tr_player.position) > hoerfeld || fpsController.IsSneaking()) { 
				/*when not in seight make patrol*/
				if (curWayPoint < Waypoints.Length) {
					Target = Waypoints [curWayPoint].position;
					MoveDirection = Target - transform.position;
					Velocity = GetComponent<Rigidbody> ().velocity;

					if (MoveDirection.magnitude < 1) {
						curWayPoint++;
					} else {
						Velocity = MoveDirection.normalized * Speed;

					}
				} else {
					if (doPatrol) {
						curWayPoint = 0;
					} else {
						Velocity = Vector3.zero;
					}
				}

				GetComponent<Rigidbody> ().velocity = Velocity;
				transform.LookAt (Target);

			} else {
				/*Follow the player*/
				transform.position += transform.forward * Speed * Time.deltaTime;
			}
		
	}

	void OnTriggerStay (Collider other)
	{
		//Debug.Log ("on trigger stay: " + other.tag);
		// If the player has entered the trigger sphere...
		if(other.tag == "Player")
		{
			// By default the player is not in sight.
			playerInSight = false;
			//Debug.Log("player");
			// Create a vector from the enemy to the player and store the angle between it and forward.
			Vector3 direction = other.transform.position - transform.position + transform.up +transform.forward;
			float angle = Vector3.Angle(direction, transform.forward);
			Debug.Log(angle + "  "+ fieldOfViewAngle * 0.5f);
			// If the angle between forward and where the player is, is less than half the angle of view...
			if(angle < fieldOfViewAngle * 0.5f)
			{
				RaycastHit hit;
				Debug.Log("ray ");
				// ... and if a raycast towards the player hits something...
				Debug.DrawRay(transform.position + transform.up +transform.forward, direction.normalized*10);
				if(Physics.Raycast(transform.position + transform.up +transform.forward, direction.normalized*10, out hit, col.radius))
				{
					Debug.Log("ray hit something");
					// ... and if the raycast hits the player...
					Debug.Log (hit.collider.gameObject);



					if(hit.collider.gameObject.name.Contains("FPS"))
					{
						// ... the player is in sight.
						playerInSight = true;
						Debug.Log("SEE you ");
						
						// Set the last global sighting is the players current position.
						//lastPlayerSighting.position = player.transform.position;
					}
				}
			}
			
			// Store the name hashes of the current states.
			//int playerLayerZeroStateHash = playerAnim.GetCurrentAnimatorStateInfo(0).nameHash;
			//int playerLayerOneStateHash = playerAnim.GetCurrentAnimatorStateInfo(1).nameHash;
			
			// If the player is running or is attracting attention...
			//if(playerLayerZeroStateHash == hash.locomotionState || playerLayerOneStateHash == hash.shoutState)
			//{
				// ... and if the player is within hearing range...
			//	if(CalculatePathLength(player.transform.position) <= col.radius)
					// ... set the last personal sighting of the player to the player's current position.
			//		personalLastSighting = player.transform.position;
			//}
		}
	}

}
