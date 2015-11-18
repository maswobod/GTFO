using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	private Score score;

	void Start () {
		score = GameObject.FindGameObjectWithTag ("Score").GetComponent<Score>();
	}

	void Update () {
	}

	public void endGameWithSuccess(){
		score.Win ();
		Application.LoadLevel("endScreen");
	}
	public void endGameWithLoose(){
		score.Loose ();
		Application.LoadLevel("endScreen");
	}
}
