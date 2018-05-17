using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("Bools")]
    public bool showInv;
    public bool playerAtShop;
    public bool playerAtChest;

    public MouseLook playerHeadLook;
    public MouseLook playerTurn;
    public Movement playerMove;

    // Use this for initialization
    void Start()
    {
        GetStuff();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInv();
        }
    }

    void OnGUI()
    {
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;

        if (showInv)
        {
            DrawInventories();
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

            playerHeadLook.enabled = true;
            playerTurn.enabled = true;
            playerMove.enabled = true;

            return (false);
        }

        // if showInv is False, then turn on Inventory
        else
        {
            showInv = true;

            Time.timeScale = 0.25f;
            Cursor.visible = true;

            playerHeadLook.enabled = false;
            playerTurn.enabled = false;
            playerMove.enabled = false;

            return (true);
        }
    }

    void DrawInventories()
    {
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;

        // fullscreen Inventory background
        //GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "INVENTORY");

        GUI.Box(new Rect(scrW * 4.5f, scrH * 1f, scrW * 1f, scrH * 5f), "Equipped");

        GUI.Box(new Rect(scrW * 1f, scrH * 2f, scrW * 3f, scrH * 4f), "Character View");

        GUI.Box(new Rect(scrW * 6f, scrH * 1f, scrW * 5f, scrH * 5f), "Inventory");

        GUI.Box(new Rect(scrW * 6f, scrH * 6.5f, scrW * 5f, scrH * 1f), "Quick Select");

        if (playerAtShop == true)
        {
            GUI.Box(new Rect(scrW * 12f, scrH * 1f, scrW * 3f, scrH * 3f), "Shop");
        }

        if (playerAtChest == true)
        {
            GUI.Box(new Rect(scrW * 12f, scrH * 4.5f, scrW * 3f, scrH * 3f), "Chest");
        }
    }

    void GetStuff()
    {
        playerHeadLook = transform.Find("Head").GetComponent<MouseLook>();
        playerTurn = GetComponent<MouseLook>();
        playerMove = GetComponent<Movement>();
    }

    #region Triggers
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Shop"))
        {
            playerAtShop = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.gameObject.CompareTag("Shop"))
        {
            playerAtShop = false;
        }
    }
    #endregion
}
