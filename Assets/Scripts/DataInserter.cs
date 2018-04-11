using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataInserter : MonoBehaviour
{
    public InputField inputUsername, inputEmail, inputPassword;
    
    string CreateUserURL = "localhost/ninja/InsertUser.php";
    string LoginURL = "localhost/ninja/Login.php";

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Sign Up
    public void CreateUser(string username, string email, string password)
    {
        // WWWForm: Send form to a PHP to trigger the PHP from Unity
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        form.AddField("emailPost", email);
        form.AddField("passwordPost", password);

        // Connect to CreateUserURL and send "form" WWWForm (as "www" WWWForm) to it
        WWW www = new WWW(CreateUserURL, form);
    }

    public void CreateUser_ConfirmButton()
    {
        CreateUser(inputUsername.text, inputEmail.text, inputPassword.text);
    }
    #endregion

    #region Login
    IEnumerator LoginUser(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        form.AddField("passwordPost", password);

        WWW www = new WWW(LoginURL, form);

        // Coroutine is used to wait for downloading of WWWForm to finish before running anything else;
        yield return www;

        // This gets the "echo" from the PHP script
        Debug.Log(www.text);
    }

    public void Login_Button()
    {
        StartCoroutine(LoginUser(inputUsername.text, inputPassword.text));
    }
    #endregion
}
