using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataInserter : MonoBehaviour
{
    public string inputUsername;
    public string inputEmail;
    public string inputPassword;

    string CreateUserURL = "localhost/login/InsertUser.php";

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateUser(inputUsername, inputEmail, inputPassword);
        }
    }

    public void CreateUser(string username, string email, string password)
    {
        // WWWForm: Send form to a PHP to trigger the PHP from Unity
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        form.AddField("emailPost", email);
        form.AddField("passwordPost", password);

        // Connect to CreateUserURL and send "form" WWWForm to it
        WWW www = new WWW(CreateUserURL, form);
    }
}
