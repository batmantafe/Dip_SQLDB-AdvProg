using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

namespace sql3
{
    public class CharButtons : MonoBehaviour
    {
        public string charNameInButton;
        public string charClassInButton;

        public bool charButtonClicked;
        public Text playerTalk;

        public HUD hud;

        // Use this for initialization
        void Start()
        {
            charButtonClicked = false;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ClickCharButton()
        {
            playerTalk.text = "You are " + charNameInButton + ", a " + charClassInButton + ".";

            charButtonClicked = true;

            
        }
    }
}
