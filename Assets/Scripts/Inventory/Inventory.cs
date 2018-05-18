using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [Header("Bools")]
    public bool showInv;
    public bool playerAtShop;
    public bool playerAtChest;

    [Header("Scripts")]
    public MouseLook playerHeadLook;
    public MouseLook playerTurn;
    public Movement playerMove;

    [Header("Strings")]
    public string shopString;
    public string chestString;

    [Header("Ints")]
    public int thisChestMaxItems;

    [Header("GameObjects")]
    public GameObject miniMap;

    // Use this for initialization
    void Start()
    {
        SetupStuff();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInv();
        }
    }

    void SetupStuff()
    {
        playerHeadLook = transform.Find("Head").GetComponent<MouseLook>();
        playerTurn = GetComponent<MouseLook>();
        playerMove = GetComponent<Movement>();

        shopString = "Press TAB to access the Shop";
        chestString = "Press TAB to access this Chest";
    }

    void OnGUI()
    {
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;

        if (showInv)
        {
            DrawInventories();
        }

        // Let the Player know to press Tab
        else
        {
            if (playerAtShop == true)
            {
                GUI.Label(new Rect(scrW * 7f, scrH * 4f, scrW * 4f, scrH * 1f), shopString);
            }

            if (playerAtChest == true)
            {
                GUI.Label(new Rect(scrW * 7f, scrH * 4f, scrW * 4f, scrH * 1f), chestString);
            }
        }
    }

    #region Inventory
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

            miniMap.SetActive(true);

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

            miniMap.SetActive(false);

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
            GUI.Box(new Rect(scrW * 12f, scrH * 1f, scrW * 3f, scrH * 7f), "Shop");
        }

        if (playerAtChest == true)
        {
            if (thisChestMaxItems <= 3)
            {
                GUI.Box(new Rect(scrW * 12f, scrH * 1f, scrW * 3f, scrH * 1f), "Small Chest");
            }

            if (thisChestMaxItems >= 7)
            {
                GUI.Box(new Rect(scrW * 12f, scrH * 1f, scrW * 3f, scrH * 3f), "Big Chest");
            }

            if (thisChestMaxItems >= 4 && thisChestMaxItems <= 6)
            {
                GUI.Box(new Rect(scrW * 12f, scrH * 1f, scrW * 3f, scrH * 2f), "Average Chest");
            }
        }
    }
    #endregion

    #region Triggers
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Shop"))
        {
            playerAtShop = true;
        }

        if (other.gameObject.CompareTag("Chest"))
        {
            playerAtChest = true;

            thisChestMaxItems = other.gameObject.transform.parent.gameObject.GetComponent<Chest>().chestMaxItems;

            // What is Max Items for this Chest set at?
            // Debug.Log(other.gameObject.transform.parent.gameObject.GetComponent<Chest>().chestMaxItems);
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.gameObject.CompareTag("Shop"))
        {
            playerAtShop = false;
        }

        if (other.gameObject.CompareTag("Chest"))
        {
            playerAtChest = false;
        }
    }
    #endregion
}
