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
        public Text playerTalk;

        [Header("Username SQL Check")]
        public InputField usernameInput;
        public string checkUsernameURL = "localhost/ninja/sql3CheckUsername.php";

        [Header("PHP Echo")]
        public string[] charClassArray;

        [Header("Character Buttons")]
        public GameObject char1;
        public GameObject char2, char3;
        public bool charChosen;
        public string charChoice;
        public Text classTalk;
        public GameObject icon;

        [Header("Quick Select")]
        public QuickSelect quickSelect;
        public GameObject playerMainInventory;
        public Inventory3 inv3;

        // Use this for initialization
        void Start()
        {
            userLoggedIn = false;
            charChosen = false;
        }

        // Update is called once per frame
        void Update()
        {
            VerifyUserLogin();

            CheckUsername();

            CheckCharChosen();
        }

        #region Is the User Logged In?
        void VerifyUserLogin()
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

                playerTalk.text = "Login & Choose Your Character.";

                icon.SetActive(false);

                quickSelect.enabled = false;

                playerMainInventory.SetActive(false);
            }

            else
            {
                char1.SetActive(true);
                char2.SetActive(true);
                char3.SetActive(true);

                usernameInput.gameObject.SetActive(false);

                if (charChosen)
                {
                    mouseLookX.enabled = true;
                    mouseLookY.enabled = true;
                    movement.enabled = true;
                    hud.enabled = true;

                    char1.SetActive(false);
                    char2.SetActive(false);
                    char3.SetActive(false);

                    icon.SetActive(true);

                    quickSelect.enabled = true;
                    inv3.enabled = true;

                    switch (charChoice)
                    {
                        case "Warrior":
                            hud.playerIsWarrior = true;

                            classTalk.text = "A Warrior has lots of Health, but very little Mana, and some Stamina.";
                            break;

                        case "Wizard":
                            hud.playerIsWizard = true;

                            classTalk.text = "A Wizard has some Health, lots of Mana, but very little Stamina.";
                            break;

                        case "Rogue":
                            hud.playerIsRogue = true;

                            classTalk.text = "A Rogue has very little Health, some Mana, but lots of Stamina.";
                            break;
                    }
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
                charClassArray = wwwTextString.Split('|');

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
            if (charClassArray.Length > 1)
            {
                char1.GetComponentInChildren<Text>().text = charClassArray[1] + " the " + charClassArray[2];

                char1.GetComponent<CharButtons>().charNameInButton = charClassArray[1];
                char1.GetComponent<CharButtons>().charClassInButton = charClassArray[2];
            }

            if (charClassArray.Length > 3)
            {
                char2.GetComponentInChildren<Text>().text = charClassArray[3] + " the " + charClassArray[4];

                char2.GetComponent<CharButtons>().charNameInButton = charClassArray[3];
                char2.GetComponent<CharButtons>().charClassInButton = charClassArray[4];
            }

            if (charClassArray.Length > 5)
            {
                char3.GetComponentInChildren<Text>().text = charClassArray[5] + " the " + charClassArray[6];

                char3.GetComponent<CharButtons>().charNameInButton = charClassArray[5];
                char3.GetComponent<CharButtons>().charClassInButton = charClassArray[6];
            }
        }

        void CheckCharChosen()
        {
            if (char1.GetComponent<CharButtons>().charButtonClicked == true)
            {
                charChoice = char1.GetComponent<CharButtons>().charClassInButton;

                charChosen = true;
            }

            if (char2.GetComponent<CharButtons>().charButtonClicked == true)
            {
                charChoice = char2.GetComponent<CharButtons>().charClassInButton;

                charChosen = true;
            }

            if (char3.GetComponent<CharButtons>().charButtonClicked == true)
            {
                charChoice = char3.GetComponent<CharButtons>().charClassInButton;

                charChosen = true;
            }
        }
        #endregion
    }

}
