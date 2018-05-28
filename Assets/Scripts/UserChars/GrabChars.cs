using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class GrabChars : MonoBehaviour {

	public string username;

	public string[] userChars;

	public Text char1, char2;

	public string[] getCharInfo;

	// Use this for initialization
	void Start ()
	{	
		StartCoroutine (GetChars(username));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator GetChars(string username)
	{
		string createCharURL = "http://localhost/ninja/getallcharacters.php";
		WWWForm user = new WWWForm ();
		user.AddField ("username_Post", username);
		WWW www = new WWW (createCharURL, user);
		yield return www;
		Debug.Log (www.text);

		userChars = www.text.Split('|');

		char1.text = userChars[0];
		char2.text = userChars [1];
	}

	IEnumerator SetCharInfo(string username, string character)
	{
		string createCharURL = "http://localhost/ninja/getcharinfo.php";
		WWWForm user = new WWWForm ();
		user.AddField ("username_Post", username);
		user.AddField ("char_Post", character);
		WWW www = new WWW (createCharURL, user);
		yield return www;
		Debug.Log (www.text);

		getCharInfo = www.text.Split('|');


	}

	public void CharButton()
	{
		Debug.Log(gameObject);

		StartCoroutine (SetCharInfo(username, char1.text));
	}
}
