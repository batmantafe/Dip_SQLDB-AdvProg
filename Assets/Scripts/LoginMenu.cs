using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class LoginMenu : MonoBehaviour
{
    public Text screen, debugMsg;
    public GameObject username, email, password, confirmPassword, login, signup, resetPassword, exit, send, confirm, back, logout;

    public static bool userLoggedIn;
    public static bool onLoginScreen;

    // Use this for initialization
    void Start()
    {
        userLoggedIn = false;
        onLoginScreen = true;

        Cursor.visible = true;

        LoginScreen();
    }

    // Update is called once per frame
    void Update()
    {
        CheckLoggedIn();
        LoginScreen();
    }

    public void LoginScreen()
    {
        if (onLoginScreen == true)
        {
            userLoggedIn = false;

            screen.text = "Login";

            username.SetActive(true);
            //username.gameObject.GetComponent<InputField>().text = "";

            email.SetActive(false);
            //email.gameObject.GetComponent<InputField>().text = "";

            password.SetActive(true);
            //password.gameObject.GetComponent<InputField>().text = "";

            confirmPassword.SetActive(false);
            //confirmPassword.gameObject.GetComponent<InputField>().text = "";

            login.SetActive(true);
            signup.SetActive(true);
            resetPassword.SetActive(true);
            exit.SetActive(true);

            send.SetActive(false);
            confirm.SetActive(false);
            back.SetActive(false);

            logout.SetActive(false);

            if (debugMsg.text == "")
            {
                debugMsg.text = "";
            }
        }
    }

    public void SignUpButton()
    {
        userLoggedIn = false;
        onLoginScreen = false;

        screen.text = "Sign Up";

        username.SetActive(true);
        username.gameObject.GetComponent<InputField>().text = "";

        email.SetActive(true);
        email.gameObject.GetComponent<InputField>().text = "";

        password.SetActive(true);
        password.gameObject.GetComponent<InputField>().text = "";

        confirmPassword.SetActive(true);
        confirmPassword.gameObject.GetComponent<InputField>().text = "";

        login.SetActive(false);
        signup.SetActive(false);
        resetPassword.SetActive(false);
        exit.SetActive(false);

        send.SetActive(false);
        confirm.SetActive(true);
        back.SetActive(true);

        logout.SetActive(false);

        debugMsg.text = "";
    }

    public void ForgotPasswordScreen()
    {
        userLoggedIn = false;
        onLoginScreen = false;

        screen.text = "Reset Password";

        username.SetActive(false);
        username.gameObject.GetComponent<InputField>().text = "";

        email.SetActive(true);
        email.gameObject.GetComponent<InputField>().text = "";

        password.SetActive(false);
        password.gameObject.GetComponent<InputField>().text = "";

        confirmPassword.SetActive(false);
        confirmPassword.gameObject.GetComponent<InputField>().text = "";

        login.SetActive(false);
        signup.SetActive(false);
        resetPassword.SetActive(false);
        exit.SetActive(false);

        send.SetActive(true);
        confirm.SetActive(false);
        back.SetActive(true);

        logout.SetActive(false);

        debugMsg.text = "";
    }

    public void ExitButton()
    {
        userLoggedIn = false;

        Application.Quit();
    }

    void CheckLoggedIn()
    {
        if (userLoggedIn == true)
        {
            onLoginScreen = false;

            screen.text = "Your Account";

            username.gameObject.GetComponent<InputField>().text = "";
            username.SetActive(false);

            email.gameObject.GetComponent<InputField>().text = "";
            email.SetActive(false);
            
            password.gameObject.GetComponent<InputField>().text = "";
            password.SetActive(false);

            confirmPassword.SetActive(false);
            confirmPassword.gameObject.GetComponent<InputField>().text = "";

            login.SetActive(false);
            signup.SetActive(false);
            resetPassword.SetActive(false);
            exit.SetActive(false);

            send.SetActive(false);
            confirm.SetActive(false);
            back.SetActive(false);

            logout.SetActive(true);
        }
    }

    public void BackLoginButton()
    {
        onLoginScreen = true;
        userLoggedIn = false;

        username.gameObject.GetComponent<InputField>().text = "";
        email.gameObject.GetComponent<InputField>().text = "";
        password.gameObject.GetComponent<InputField>().text = "";
        confirmPassword.gameObject.GetComponent<InputField>().text = "";

        if (screen.text == "Your Account")
        {
            debugMsg.text = "You have logged out. ";
        }

        else
        {
            debugMsg.text = "You are not logged in. ";
        }
    }
}
