using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	
	private Score score;
	private static string playerName;



	void Start ()
	{
		score = GameObject.FindGameObjectWithTag ("Score").GetComponent<Score> ();
		playerName=PlayerPrefs.GetString ("PlayerName");
	}


	public void StartNewGame (string sceneToStart)
	{
		score.StartCounting ();
		if (playerName.Length > 0) {
			PlayerPrefs.SetString ("PlayerName", playerName);
			PlayerPrefs.Save ();
		}
		SceneManager.LoadScene (sceneToStart);
	}

	void Update ()
	{
	}

	public void setPlayerName (string name)
	{
		if (name.Length > 0) {
			playerName = name;
		}
	}


	public void endGameWithSuccess ()
	{
		score.Win ();
		score.Stop ();
		SceneManager.LoadScene ("endScreen");
	}

	public void endGameWithLoose ()
	{
		score.Loose ();
		score.Stop ();
		SceneManager.LoadScene ("endScreen");
	}
}
