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
    [Header("Input Fields")]
    public InputField inputUsername;
    public InputField inputEmail, inputPassword, inputConfirmPassword, inputChgPwdEmail, inputChgPwdCurrPwd, inputChgPwdNewPwd, inputChgPwdConfPwd;

    [Header("PHP Echoes")]
    public Text debugMsg;
    public string[] echoFromPhp;

    [Header("Random Code")]
    public string code;
    public string codeCharactersList = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

    private int codeLength = 10;
    private string CreateUserURL = "localhost/ninja/InsertUser.php";
    private string LoginURL = "localhost/ninja/Login.php";
    private string CheckEmailURL = "localhost/ninja/CheckEmail.php";
    private string UpdateCodeURL = "localhost/ninja/UpdateCode.php";
    private string UpdatePasswordURL = "localhost/ninja/UpdatePassword.php";

    [Header("Audio")]
    public AudioSource ding;

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
        debugMsg.text = www.text;

        if (!www.text.Contains("ERROR"))
        {
            inputUsername.text = "";
            inputEmail.text = "";
            inputPassword.text = "";
            inputConfirmPassword.text = "";

            LoginMenu.onLoginScreen = true;
        }
    }

    public void CreateUser_ConfirmButton()
    {
        ding.Play();

        if (inputPassword.text == inputConfirmPassword.text)
        {
            StartCoroutine(CreateUser(inputUsername.text, inputEmail.text, inputPassword.text));
        }

        if (inputPassword.text != inputConfirmPassword.text)
        {
            debugMsg.text = "ERROR: Passwords don't match.";
        }
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

        string wwwTextString = www.text;
        echoFromPhp = wwwTextString.Split('|');

        if (echoFromPhp.Length == 2 && echoFromPhp[1] == "Logged in. ")
        {
            LoginMenu.userLoggedIn = true;

            debugMsg.text = echoFromPhp[0] + echoFromPhp[1];
        }

        else
        {
            Debug.Log(www.text);
            debugMsg.text = www.text;
        }
    }

    public void Login_Button()
    {
        ding.Play();

        StartCoroutine(LoginUser(inputUsername.text, inputPassword.text));
    }
    #endregion

    #region Reset-Password Email
    public void EmailUserButton()
    {
        ding.Play();

        StartCoroutine(CheckUserEmailExists(inputEmail.text));
    }

    IEnumerator CheckUserEmailExists(string email)
    {
        WWWForm form = new WWWForm();
        form.AddField("emailPost", email);

        WWW www = new WWW(CheckEmailURL, form);

        // Coroutine is used to wait for downloading of WWWForm to finish before running anything else;
        yield return www;

        // If "echo" from PHP script DOES NOT contain "Error"
        if (!www.text.Contains("ERROR"))
        {
            Debug.Log(www.text);

            string wwwTextString = www.text;
            echoFromPhp = wwwTextString.Split('|');

            // Generate random Password
            RandomCode();

            // In Database: Replace Password with Code
            StartCoroutine(UpdateCodeAsPassword(inputEmail.text, code));

            // Send Email!
            SendUserEmail();

            LoginMenu.onLoginScreen = true;
        }

        else
        {
            Debug.Log(www.text);
            debugMsg.text = www.text;
        }

    }

    void SendUserEmail()
    {
        MailMessage mail = new MailMessage();

        // Email
        mail.From = new MailAddress("");
        mail.To.Add(echoFromPhp[1]);
        mail.Subject = "Reset Your 99 NINJA Password";
        mail.Body = "Hi " + echoFromPhp[2] + ", your Password has been reset to: " + code + ". You can use this Password to Login OR you can Change this Password. Best Regards, 99 Ninja!";

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

        debugMsg.text = echoFromPhp[0] + "Your new Password has been sent to " + echoFromPhp[1];

        // Set Code back to Nothing after updating Database (not before! har har) so it is not saved in Unity.
        code = "";
    }

    void RandomCode()
    {
        // Reset Code to Nothing (just in case!)
        code = "";

        while (code.Length < codeLength)
        {
            code += codeCharactersList[UnityEngine.Random.Range(0, codeCharactersList.Length)];
        }
    }

    // Randomly generated Code replaces existing Password
    IEnumerator UpdateCodeAsPassword(string email, string codeString)
    {
        WWWForm form = new WWWForm();
        form.AddField("emailPost", email);
        form.AddField("passwordPost", codeString);

        WWW www = new WWW(UpdateCodeURL, form);

        // Coroutine is used to wait for downloading of WWWForm to finish before running anything else;
        yield return www;

        Debug.Log(www.text);
    }
    #endregion

    #region Change Password
    public void ChangePassword_Button()
    {
        ding.Play();

        if (inputChgPwdNewPwd.text == inputChgPwdConfPwd.text)
        {
            StartCoroutine(ChangePasswordUpdate(inputChgPwdEmail.text, inputChgPwdCurrPwd.text, inputChgPwdNewPwd.text));
        }

        else
        {
            debugMsg.text = "ERROR: New Passwords don't match. ";
        }
    }

    IEnumerator ChangePasswordUpdate(string email, string currPw, string newPw)
    {
        WWWForm form = new WWWForm();

        form.AddField("emailPost", email);
        form.AddField("currentPasswordPost", currPw);
        form.AddField("newPasswordPost", newPw);

        WWW www = new WWW(UpdatePasswordURL, form);

        yield return www;

        Debug.Log(www.text);

        debugMsg.text = www.text;

        LoginMenu.onLoginScreen = true;
    }
    #endregion
}