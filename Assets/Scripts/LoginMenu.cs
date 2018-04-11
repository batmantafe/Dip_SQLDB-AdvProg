using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class LoginMenu : MonoBehaviour
{
    public Text screen, debug;
    public GameObject username, email, password, login, signup, forgotpassword, exit, send, confirm, back;

    // Use this for initialization
    void Start()
    {
        LoginBack();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoginBack()
    {
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

        debug.text = "";
    }

    public void SignUpButton()
    {
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

        debug.text = "";
    }

    public void ForgotPasswordScreen()
    {
        screen.text = "Forgot Password";

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

        debug.text = "";
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
