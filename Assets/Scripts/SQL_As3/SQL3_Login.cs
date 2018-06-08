using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

namespace sql3
{
    

    public class SQL3_Login : MonoBehaviour
    {
        [Header("Username Login Start Check")]
        public bool userLoggedIn;
        public MouseLook mouseLookX, mouseLookY;
        public Movement movement;
        public HUD hud;

        [Header("Username SQL Check")]
        public InputField usernameInput;
        public string checkUsernameURL = "localhost/ninja/sql3CheckUsername.php";

        [Header("PHP Echo")]
        public string[] phpEcho;

        [Header("Character Buttons")]
        public GameObject char1;
        public GameObject char2, char3;
        public bool charChosen;

        // Use this for initialization
        void Start()
        {
            userLoggedIn = false;
            charChosen = false;
        }

        // Update is called once per frame
        void Update()
        {
            UserNotLoggedIn();

            CheckUsername();
        }

        #region Is the User Logged In?
        void UserNotLoggedIn()
        {
            if (!userLoggedIn)
            {
                mouseLookX.enabled = false;
                mouseLookY.enabled = false;
                movement.enabled = false;
                hud.enabled = false;

                char1.SetActive(false);
                char2.SetActive(false);
                char3.SetActive(false);
            }

            else
            {
                char1.SetActive(true);
                char2.SetActive(true);
                char3.SetActive(true);

                if (charChosen)
                {
                    mouseLookX.enabled = true;
                    mouseLookY.enabled = true;
                    movement.enabled = true;
                    hud.enabled = true;
                }
            }
        }

        void CheckUsername()
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                StartCoroutine(CheckUsernameNow(usernameInput.text));
            }
        }

        IEnumerator CheckUsernameNow(string username)
        {
            WWWForm form = new WWWForm();
            form.AddField("usernamePost", username);

            WWW www = new WWW(checkUsernameURL, form);

            yield return www;

            // If NO ERROR from SQL
            if (!www.text.Contains("ERROR"))
            {
                Debug.Log(www.text);

                string wwwTextString = www.text;
                phpEcho = wwwTextString.Split('|');

                /*if (phpEcho[0] == "")
                {
                    Debug.Log("It's NOT null! It's NOT a Space! But it's DEFINITELY got a value!");
                }*/

                userLoggedIn = true;

                SetButtonsToCharacter();
            }

            // If ERROR from SQL
            else
            {
                Debug.Log(www.text);
            }
        }
        #endregion

        #region Check Character stuff
        void SetButtonsToCharacter()
        {
            char1.GetComponentInChildren<Text>().text = phpEcho[1] + " the " + phpEcho[2];
            char2.GetComponentInChildren<Text>().text = phpEcho[3] + " the " + phpEcho[4];
            char3.GetComponentInChildren<Text>().text = phpEcho[5] + " the " + phpEcho[6];
        }


        #endregion
    }

}
