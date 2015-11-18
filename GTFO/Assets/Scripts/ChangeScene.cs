using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour {
	public Text t;


	public void changeToScene (string sceneToChangeTo) {
        Application.LoadLevel(sceneToChangeTo);
	}

	void Start(){
		Score score = GameObject.FindGameObjectWithTag ("Score").GetComponent<Score>();

		if (score.getWin ()) {
			t.text="You won the Game !";
		}else{
			t.text="Looser!!!";
		}
	}
}
