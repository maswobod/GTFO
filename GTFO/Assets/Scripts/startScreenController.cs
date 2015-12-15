using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class startScreenController : MonoBehaviour
{
	public InputField inputField;

	void Start ()
	{
		string name = PlayerPrefs.GetString ("PlayerName");
		if (name.Length > 0) {
			inputField.text = name;
		}
	}

}
