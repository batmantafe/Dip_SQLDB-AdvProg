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
        private string checkUsernameURL = "localhost/ninja/sql3CheckUsername.php";

        // Use this for initialization
        void Start()
        {
            userLoggedIn = false;
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
            }

            else
            {
                mouseLookX.enabled = true;
                mouseLookY.enabled = true;
                movement.enabled = true;
                hud.enabled = true;
            }
        }

        void CheckUsername()
        {
            if (Input.GetKeyDown(KeyCode.Return))
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
            }

            // If ERROR from SQL
            else
            {
                Debug.Log(www.text);
            }
        }

        #endregion
    }

}
