using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace sql3
{

    public class HUD : MonoBehaviour
    {
        public bool hudCheckInvOn;

        [Header("Health")]
        public float healthMax;
        public float healthCurrent;
        public GUIStyle healthGui;

        [Header("Mana")]
        public float manaMax;
        public float manaCurrent;
        public GUIStyle manaGui;

        [Header("Stamina")]
        public float stamMax;
        public float stamCurrent;
        public GUIStyle stamGui;
        public float stamBurn;
        public float stamRegen;
        public float playerNormalSpeed;
        public float playerSlowSpeed;
        public QuickSelect quickSelect;

        [Header("Class Choice Stats")]
        public float highStat, medStat, lowStat;
        public bool playerIsWarrior, playerIsWizard, playerIsRogue, playerClassSet;

        // Use this for initialization
        void Start()
        {
            StartConditions();
        }

        // Update is called once per frame
        void Update()
        {
            if (playerIsWarrior)
            {
                healthMax = highStat;
                manaMax = lowStat;
                stamMax = medStat;

                if (!playerClassSet)
                {
                    healthCurrent = healthMax;
                    manaCurrent = manaMax;
                    stamCurrent = stamMax;

                    playerClassSet = true;
                }
            }

            if (playerIsWizard)
            {
                healthMax = medStat;
                manaMax = highStat;
                stamMax = lowStat;

                if (!playerClassSet)
                {
                    healthCurrent = healthMax;
                    manaCurrent = manaMax;
                    stamCurrent = stamMax;

                    playerClassSet = true;
                }
            }

            if (playerIsRogue)
            {
                healthMax = lowStat;
                manaMax = medStat;
                stamMax = highStat;

                if (!playerClassSet)
                {
                    healthCurrent = healthMax;
                    manaCurrent = manaMax;
                    stamCurrent = stamMax;

                    playerClassSet = true;
                }
            }

            StaminaUse();

            
        }

        void StartConditions()
        {
            highStat = 200;
            medStat = 100;
            lowStat = 50;

            // Set Health
            //healthMax = 100f;
            healthCurrent = healthMax;

            //manaMax = 100f;
            manaCurrent = manaMax;

            //stamMax = 100f;
            stamCurrent = stamMax;
            stamBurn = 10f;
            stamRegen = 5f;
            playerNormalSpeed = GetComponent<Movement>().speed;
            playerSlowSpeed = 1f;
        }

        void OnGUI()
        {
            float scrW = Screen.width / 16;
            float scrH = Screen.height / 9;

            if (hudCheckInvOn == false)
            {
                GUI.Box(new Rect(scrW * 6f, scrH * 7f, healthCurrent * (scrW * 4f) / healthMax, scrH * 0.5f), "Health", healthGui);

                GUI.Box(new Rect(scrW * 6f, scrH * 7.5f, manaCurrent * (scrW * 4f) / manaMax, scrH * 0.5f), "Mana", manaGui);

                GUI.Box(new Rect(scrW * 6f, scrH * 8f, stamCurrent * (scrW * 4f) / stamMax, scrH * 0.5f), "Stamina", stamGui);
            }

            if (hudCheckInvOn == true)
            {
                GUI.Box(new Rect(scrW * 1f, scrH * 6.25f, healthCurrent * (scrW * 3f) / healthMax, scrH * 0.25f), "Health: ", healthGui);

                GUI.Box(new Rect(scrW * 1f, scrH * 6.5f, manaCurrent * (scrW * 3f) / manaMax, scrH * 0.25f), "Mana: ", manaGui);

                GUI.Box(new Rect(scrW * 1f, scrH * 6.75f, stamCurrent * (scrW * 3f) / stamMax, scrH * 0.25f), "Stamina: ", stamGui);
            }
        }

        void StaminaUse()
        {
            if (stamCurrent >= stamMax)
            {
                stamCurrent = stamMax;
            }

            if (stamCurrent <= 0f)
            {
                stamCurrent = 0f;

                GetComponent<Movement>().speed = playerSlowSpeed;
            }

            if (stamCurrent > 0f)
            {
                GetComponent<Movement>().speed = playerNormalSpeed;
            }

            if (!quickSelect.showSelectMenu)
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
                {
                    stamCurrent = stamCurrent - (stamBurn * Time.deltaTime);
                }
            }

            else
            {
                stamCurrent = stamCurrent + (stamRegen * Time.deltaTime);
            }
        }
    }
}