using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class LoginMenu : MonoBehaviour
{
    public Text screen, debugMsg;
    public GameObject username, email, password, login, signup, forgotpassword, exit, send, confirm, back, logout;

    public static bool UserLoggedIn;

    // Use this for initialization
    void Start()
    {
        UserLoggedIn = false;

        Cursor.visible = true;

        LoginBackLogout();
    }

    // Update is called once per frame
    void Update()
    {
        CheckLoggedIn();
    }

    public void LoginBackLogout()
    {
        UserLoggedIn = false;

        screen.text = "Login";

        username.SetActive(true);
        username.gameObject.GetComponent<InputField>().text = "";

        email.SetActive(false);
        email.gameObject.GetComponent<InputField>().text = "";

        password.SetActive(true);
        password.gameObject.GetComponent<InputField>().text = "";

        login.SetActive(true);
        signup.SetActive(true);
        forgotpassword.SetActive(true);
        exit.SetActive(true);

        send.SetActive(false);
        confirm.SetActive(false);
        back.SetActive(false);

        logout.SetActive(false);

        debugMsg.text = "";
    }

    public void SignUpButton()
    {
        UserLoggedIn = false;

        screen.text = "Sign Up";

        username.SetActive(true);
        username.gameObject.GetComponent<InputField>().text = "";

        email.SetActive(true);
        email.gameObject.GetComponent<InputField>().text = "";

        password.SetActive(true);
        password.gameObject.GetComponent<InputField>().text = "";

        login.SetActive(false);
        signup.SetActive(false);
        forgotpassword.SetActive(false);
        exit.SetActive(false);

        send.SetActive(false);
        confirm.SetActive(true);
        back.SetActive(true);

        logout.SetActive(false);

        debugMsg.text = "";
    }

    public void ForgotPasswordScreen()
    {
        UserLoggedIn = false;

        screen.text = "Reset Password";

        username.SetActive(false);
        username.gameObject.GetComponent<InputField>().text = "";

        email.SetActive(true);
        email.gameObject.GetComponent<InputField>().text = "";

        password.SetActive(false);
        password.gameObject.GetComponent<InputField>().text = "";

        login.SetActive(false);
        signup.SetActive(false);
        forgotpassword.SetActive(false);
        exit.SetActive(false);

        send.SetActive(true);
        confirm.SetActive(false);
        back.SetActive(true);

        logout.SetActive(false);

        debugMsg.text = "";
    }

    public void ExitButton()
    {
        UserLoggedIn = false;

        Application.Quit();
    }

    void CheckLoggedIn()
    {
        if (UserLoggedIn == true)
        {
            screen.text = "Your Account";

            username.gameObject.GetComponent<InputField>().text = "";
            username.SetActive(false);

            email.gameObject.GetComponent<InputField>().text = "";
            email.SetActive(false);
            
            password.gameObject.GetComponent<InputField>().text = "";
            password.SetActive(false);
            

            login.SetActive(false);
            signup.SetActive(false);
            forgotpassword.SetActive(false);
            exit.SetActive(false);

            send.SetActive(false);
            confirm.SetActive(false);
            back.SetActive(false);

            logout.SetActive(true);

            //debugMsg.text = "";
        }
    }
}
