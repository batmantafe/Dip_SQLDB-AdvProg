using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool showInv;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInv();
        }
    }

    private void OnGUI()
    {
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;

        if (showInv)
        {
            // fullscreen Inventory background
            //GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "INVENTORY");

            GUI.Box(new Rect(scrW * 1f, scrH * 1.5f, scrW * 1f, scrH * 5f), "Equipped");

            GUI.Box(new Rect(scrW * 2.5f, scrH * 2f, scrW * 3f, scrH * 4f), "Character View");

            GUI.Box(new Rect(scrW * 6f, scrH * 1f, scrW * 5f, scrH * 5f), "Inventory");

            GUI.Box(new Rect(scrW * 6f, scrH * 6.5f, scrW * 5f, scrH * 1f), "Quick Select");

            GUI.Box(new Rect(scrW * 12f, scrH * 1f, scrW * 3f, scrH * 3f), "Shop");

            GUI.Box(new Rect(scrW * 12f, scrH * 5f, scrW * 3f, scrH * 3f), "Chest");


        }
    }

    public bool ToggleInv()
    {
        // if showInv is True, then turn off Inventory
        if (showInv)
        {
            showInv = false;

            Time.timeScale = 1;
            Cursor.visible = false;

            return (false);
        }

        // if showInv is False, then turn on Inventory
        else
        {
            showInv = true;

            Time.timeScale = 0.25f;
            Cursor.visible = true;

            return (true);
        }
    }
}
