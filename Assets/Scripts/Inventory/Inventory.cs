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
    public GameObject charView;

    [Header("Cert IV Inventory")]
    //the toggle for showing our inventory
    //public bool showInv;
    public List<Items> inventory = new List<Items>();
    public int slotX, slotY;
    private Rect inventorySize;

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

    #region AddItem
    public void AddItem(int iD)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].name == null)
            {
                inventory[i] = ItemGen.CreateItem(iD);
                Debug.Log("Added Item: " + inventory[i].name);
                return;
            }
        }
    }
    #endregion

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
            charView.SetActive(false);

            GetComponent<HUD>().hudCheckInvOn = false;

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
            charView.SetActive(true);

            GetComponent<HUD>().hudCheckInvOn = true;

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

        /***********************************/

        #region DragInventory from Cert IV

        //void InventoryDrag(int windowID)
    //{
            //GUI.Box(new Rect(0, 0.25f * scrH, 6 * scrW, 0.5f * scrH), "Banner");
            //GUI.Box(new Rect(0, 4.25f * scrH, 6 * scrW, 0.5f * scrH), "Gold n EXP");
            //showToolTip = false;
            #region Nested For Loop
            Event e = Event.current;
            int i = 0;
            for (int y = 0; y < slotY; y++)
            {
                for (int x = 0; x < slotX; x++)
                {
                    Rect slotLocation = new Rect(scrW * 0.125f + x * (scrW * 0.75f), scrH * 0.75f + y * (scrH * 0.65f), 0.75f * scrW, 0.65f * scrH);
                    GUI.Box(slotLocation, "");

                    #region Pickup Item
                    /*
                    if (e.button == 0 && e.type == EventType.MouseDown && slotLocation.Contains(e.mousePosition) && !dragging && inventory[i].Name != null && !Input.GetKey(KeyCode.LeftShift))
                    {
                        draggedItem = inventory[i];//we pick up item
                        inventory[i] = new Item();//the slot item is now blank
                        dragging = true;//we are holding an item
                        draggedFrom = i;//this is so we know where the item came from
                        Debug.Log("Dragging: "+ draggedItem.Name);
                    }
                    #endregion
                    #region Swap Item
                    if (e.button == 0 && e.type == EventType.MouseUp && slotLocation.Contains(e.mousePosition) && dragging && inventory[i].Name != null)
                    {
                        Debug.Log("Swapping: " + draggedItem.Name + " :With: " + inventory[i].Name);

                        inventory[draggedFrom] = inventory[i];//our pick up slot now has our other item
                        inventory[i] = draggedItem;//the slot we are dropping the Item is now filled with our drag item
                        draggedItem = new Item();//the item we use to be dragging is empty
                        dragging = false;//we are not holding an item

                    }
                    #endregion
                    #region Place Item
                    if (e.button == 0 && e.type == EventType.MouseUp && slotLocation.Contains(e.mousePosition) && dragging && inventory[i].Name == null)
                    {
                        Debug.Log("Place: " + draggedItem.Name + " :Into: " + i);

                        inventory[i] = draggedItem;//the slot we are dropping the Item is now filled with our drag item
                        draggedItem = new Item();//the item we use to be dragging is empty
                        dragging = false;//we are not holding an item

                    }
                    #endregion
                    #region Return Item
                    if (e.button == 0 && e.type == EventType.MouseUp && i == ((slotX*slotY)-1) && dragging)
                    {
                        Debug.Log("Return: " + draggedItem.Name + " :Into: " + draggedFrom);

                        inventory[draggedFrom] = draggedItem;//the slot we are dropping the Item is now filled with our drag item
                        draggedItem = new Item();//the item we use to be dragging is empty
                        dragging = false;//we are not holding an item

                    }
                    */
                    #endregion


                    #region Draw Item Icon
                    if (inventory[i].name != null)
                    {
                        GUI.DrawTexture(slotLocation, inventory[i].iconName);

                        Debug.Log("Draw Item Icon");

                        #region Set ToolTip on Mouse Hover
                        if (slotLocation.Contains(e.mousePosition) /*&& !dragging*/ && showInv)
                        {
                            //toolTipItem = i;
                            //showToolTip = true;
                        }
                        #endregion
                    }
                    #endregion
                    i++;
                }
            }
            #endregion
            
            
            #region Drag Window
            /*
            GUI.DragWindow(new Rect(0 * scrW, 0 * scrH, 6 * scrW, 0.5f * scrH));//Top Drag
            GUI.DragWindow(new Rect(0 * scrW, 0.5f * scrH, 0.25f * scrW, 3.5f * scrH));//Left Drag
            GUI.DragWindow(new Rect(5.5f * scrW, 0.5f * scrH, 0.25f * scrW, 3.5f * scrH));//Right Drag
            GUI.DragWindow(new Rect(0 * scrW, 4 * scrH, 0.25f * scrW, 3.5f * scrH));//Bottom Drag
            */
            #endregion
        //}

        #endregion

        /***********************************/

        if (playerAtShop == true)
        {
            GUI.Box(new Rect(scrW * 12f, scrH * 1f, scrW * 3f, scrH * 7f), "Shop");
        }

        if (playerAtChest == true)
        {
            if (thisChestMaxItems <= 3)
            {
                GUI.Box(new Rect(scrW * 12f, scrH * 1f, scrW * 3f, scrH * 1f), "Little Chest");
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
