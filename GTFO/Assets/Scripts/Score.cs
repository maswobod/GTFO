using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public static bool win=false;

	public void Win(){
		win = true;
	}
	public bool getWin(){
		return win;
	}
	public void Loose(){
		win = false;
	}
}
