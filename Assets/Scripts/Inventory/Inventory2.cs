using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Inventory2 : MonoBehaviour
{
    public GameObject playerInventory, miniMap;

    public MouseLook playerXLook, playerYLook;
    public Movement playerMovement;

    public GameObject[] itemButtons;

    public int itemNumber;

    // Use this for initialization
    void Start()
    {
        StartConditions();
    }

    // Update is called once per frame
    void Update()
    {
        InventoryInput();
    }

    void StartConditions()
    {
        playerInventory.SetActive(false);
        miniMap.SetActive(true);
        Cursor.visible = false;
    }

    void InventoryInput()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Turn Inventory ON!
            if (playerInventory.activeSelf == false)
            {
                playerInventory.SetActive(true);
                Cursor.visible = true;

                miniMap.SetActive(false);
                playerXLook.enabled = false;
                playerYLook.enabled = false;
                playerMovement.enabled = false;

                CheckInventoryButtons();
            }

            // Turn Inventory OFF!
            else
            {
                playerInventory.SetActive(false);
                Cursor.visible = false;

                miniMap.SetActive(true);
                playerXLook.enabled = true;
                playerYLook.enabled = true;
                playerMovement.enabled = true;
            }

        }
    }

    void CheckInventoryButtons()
    {
        for (int i = 0; i < itemButtons.Length; i++)
        {
            if (itemButtons[i].GetComponent<ItemButton>().itemPresent == false)
            {
                itemButtons[i].SetActive(false);
            }
        }
    }
}
