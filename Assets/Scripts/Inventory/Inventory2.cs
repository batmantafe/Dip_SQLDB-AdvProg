using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Inventory2 : MonoBehaviour
{
    public GameObject playerInventory, miniMap;

    public MouseLook playerXLook, playerYLook;
    public Movement playerMovement;

    public GameObject[] itemButtonsArray;

    public int itemNumber;

    // Use this for initialization
    void Start()
    {
        StartConditions();

        itemButtonsArray[0].GetComponent<ItemButton>().itemPresent = true;
        itemButtonsArray[0].GetComponent<ItemButton>().itemNumber = 10;

        itemButtonsArray[1].GetComponent<ItemButton>().itemPresent = true;
        itemButtonsArray[1].GetComponent<ItemButton>().itemNumber = 10;
    }

    // Update is called once per frame
    void Update()
    {
        InventoryInput();

        if (Input.GetKeyDown(KeyCode.F1))
        {
            for (int i = 0; i < itemButtonsArray.Length; i++)
            {
                if (itemButtonsArray[i].GetComponent<ItemButton>().itemPresent == false)
                {
                    itemButtonsArray[i].GetComponent<ItemButton>().itemPresent = true;
                    itemButtonsArray[i].GetComponent<ItemButton>().itemNumber = 10;

                    CheckInventoryButtons();

                    return;
                }
            }            
        }
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
        for (int i = 0; i < itemButtonsArray.Length; i++)
        {
            if (itemButtonsArray[i].GetComponent<ItemButton>().itemPresent == false)
            {
                itemButtonsArray[i].SetActive(false);
            }

            else
            { 
                itemButtonsArray[i].SetActive(true);
            }
        }
    }
}
