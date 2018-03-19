using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Login : MonoBehaviour
{
    public GameObject loginScreen, signUpScreen, forgotPasswordScreen;

    // Use this for initialization
    void Start()
    {
        LoginButton();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoginButton()
    {
        loginScreen.SetActive(true);
        signUpScreen.SetActive(false);
        forgotPasswordScreen.SetActive(false);
    }

    public void SignUpButton()
    {
        loginScreen.SetActive(false);
        signUpScreen.SetActive(true);
        forgotPasswordScreen.SetActive(false);
    }

    public void ForgotPasswordScreen()
    {
        loginScreen.SetActive(false);
        signUpScreen.SetActive(false);
        forgotPasswordScreen.SetActive(true);
    }

    public void BackButton()
    {
        loginScreen.SetActive(true);
        signUpScreen.SetActive(false);
        forgotPasswordScreen.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
