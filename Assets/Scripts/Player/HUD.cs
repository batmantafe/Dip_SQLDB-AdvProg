using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public bool InvOn;

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

    // Use this for initialization
    void Start()
    {
        StartConditions();
    }

    // Update is called once per frame
    void Update()
    {
        StaminaUse();
    }

    void StartConditions()
    {
        // Set Health
        healthMax = 100f;
        healthCurrent = healthMax;

        manaMax = 100f;
        manaCurrent = manaMax;

        stamMax = 100f;
        stamCurrent = stamMax;
        stamBurn = 10f;
        stamRegen = 5f;
        playerNormalSpeed = GetComponent<Movement>().speed;
        playerSlowSpeed = 1f;

        InvOn = GetComponent<Inventory>().showInv;
    }

    void OnGUI()
    {
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;

        if (InvOn == false)
        {
            GUI.Box(new Rect(scrW * 6f, scrH * 7f, healthCurrent * (scrW * 4f) / healthMax, scrH * 0.5f), "Health", healthGui);

            GUI.Box(new Rect(scrW * 6f, scrH * 7.5f, manaCurrent * (scrW * 4f) / manaMax, scrH * 0.5f), "Mana", manaGui);

            GUI.Box(new Rect(scrW * 6f, scrH * 8f, stamCurrent * (scrW * 4f) / stamMax, scrH * 0.5f), "Stamina", stamGui);
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

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            stamCurrent = stamCurrent - (stamBurn * Time.deltaTime);
        }

        else
        {
            stamCurrent = stamCurrent + (stamRegen * Time.deltaTime);
        }
    }
}
