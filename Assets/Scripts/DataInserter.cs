using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class DataInserter : MonoBehaviour
{
    public InputField inputUsername, inputEmail, inputPassword;

    public Text debug;

    private string CreateUserURL = "localhost/ninja/InsertUser.php";
    private string LoginURL = "localhost/ninja/Login.php";

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    #region Sign Up
    IEnumerator CreateUser(string username, string email, string password)
    {
        // WWWForm: Send form to a PHP to trigger the PHP from Unity
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        form.AddField("emailPost", email);
        form.AddField("passwordPost", password);

        // Connect to CreateUserURL and send "form" WWWForm (as "www" WWWForm) to it
        WWW www = new WWW(CreateUserURL, form);

        yield return www;

        Debug.Log(www.text);

        debug.text = www.text;
    }

    public void CreateUser_ConfirmButton()
    {
        StartCoroutine(CreateUser(inputUsername.text, inputEmail.text, inputPassword.text));
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

        debug.text = www.text;
    }

    public void Login_Button()
    {
        StartCoroutine(LoginUser(inputUsername.text, inputPassword.text));
    }
    #endregion

    #region Email
    public void EmailUserButton()
    {
        debug.text = "";

        MailMessage mail = new MailMessage();

                                // Email
        mail.From = new MailAddress("");
        mail.To.Add(inputEmail.text);
        mail.Subject = "Reset Your 99 NINJA Password";
        mail.Body = "Hi User, you can reset your Password HERE:";

        //Simple Mail Transfer Protocol
        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        smtpServer.Port = 25;
                                                    // Email, Password
        smtpServer.Credentials = new NetworkCredential("", "") as ICredentialsByHost;
        smtpServer.EnableSsl = true;

        ServicePointManager.ServerCertificateValidationCallback = delegate
        (object s, X509Certificate cert, X509Chain chain, SslPolicyErrors policyErrors)
        { return true; };

        smtpServer.Send(mail);

        debug.text = "The Password-Reset Email has been sent to: " + inputEmail.text;
    }
    #endregion
}