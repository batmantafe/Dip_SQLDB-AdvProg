using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginMenu : MonoBehaviour
{
    [Header("Menu GameObjects")]
    public Text screen;
    public Text debugMsg;
    public GameObject username, email, password, confirmPassword, login, signup, resetPassword, exit, send, confirm, back, logout, chgPwdMenu, playButton;

    [Header("Static Bools")]
    public static bool userLoggedIn;
    public static bool onLoginScreen;

    [Header("Audio")]
    public AudioSource ding;

    // Use this for initialization
    void Start()
    {
        userLoggedIn = false;
        onLoginScreen = true;

        Cursor.visible = true;

        // Default starting screen
        LoginScreen();
    }

    // Update is called once per frame
    void Update()
    {
        CheckLoggedIn();
        LoginScreen();
    }

    #region Login Screen
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

            chgPwdMenu.SetActive(false);

            playButton.SetActive(false);

            if (debugMsg.text == "")
            {
                debugMsg.text = "";
            }
        }
    }
    #endregion

    #region Create Account Screen (Sign Up Button)
    public void SignUpButton()
    {
        ding.Play();

        userLoggedIn = false;
        onLoginScreen = false;

        screen.text = "Create Account";

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

        chgPwdMenu.SetActive(false);

        playButton.SetActive(false);

        debugMsg.text = "";
    }
    #endregion

    #region Forgot Account Screen (Forgot Account Button)
    public void ForgotPasswordScreen()
    {
        ding.Play();

        userLoggedIn = false;
        onLoginScreen = false;

        screen.text = "Forgot Account";

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

        chgPwdMenu.SetActive(true);

        playButton.SetActive(false);

        debugMsg.text = "";
    }
    #endregion

    #region Exit Button
    public void ExitButton()
    {
        ding.Play();

        userLoggedIn = false;

        Application.Quit();
    }
    #endregion

    #region Back Button
    public void BackLoginButton()
    {
        ding.Play();

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
    #endregion

    #region Check if User is Logged In, then show Your Account screen, otherwise go to Login Screen
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

            chgPwdMenu.SetActive(false);

            playButton.SetActive(true);
        }
    }
    #endregion

    public void PlayButton()
    {
        ding.Play();

        SceneManager.LoadScene("Game");
    }
}
