using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory2 : MonoBehaviour
{
    public GameObject playerInventory, miniMap;

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
    }

    void InventoryInput()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (playerInventory.activeSelf == false)
            {
                playerInventory.SetActive(true);

                miniMap.SetActive(false);
            }
            else
            {
                playerInventory.SetActive(false);

                miniMap.SetActive(true);
            }

        }
    }
}
