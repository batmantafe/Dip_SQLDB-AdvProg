﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SQL_Inventory : MonoBehaviour
{
    public string[] itemList;
    public bool loaded;
    public Vector2 scr;
    public List<Items> item;
    //public Dictionary<int, Weapon> weapons = new Dictionary<int, Weapon>();
    public Dictionary<int, ItemInfo> itemsList = new Dictionary<int, ItemInfo>();

    // Use this for initialization
    void Start()
    {
        StartCoroutine(LoadItemData());
    }

    void OnGUI()
    {
        scr.x = Screen.width / 16;
        scr.y = Screen.height / 9;

        if (!loaded)
        {
            GUI.Box(new Rect(scr.x * 0, scr.y * 0, scr.x * 16, scr.y), "Loading...");
        }
    }

    IEnumerator LoadItemData()
    {
        WWW itemDataURL = new WWW("localhost/ninja/ItemData.php");
        yield return itemDataURL;
        string textDataString = itemDataURL.text;
        string[] items = textDataString.Split('#');
        itemList = new string[items.Length - 1];

        for (int i = 0; i < items.Length - 1; i++)
        {
            itemList[i] = items[i];
        }

        SetItems();
    }

    void SetItems()
    {
        for (int i = 0; i < itemList.Length; i++)
        {
            string[] current = itemList[i].Split('|');

            ItemInfo thisItem = new ItemInfo(int.Parse(current[0]), current[1], int.Parse(current[2]), int.Parse(current[3]), float.Parse(current[4]), current[5], current[6]);

            itemsList.Add(i, thisItem);
            Debug.Log(itemsList[i].name);

            /*Weapon weapon = new Weapon(int.Parse(current[0]), current[1], int.Parse(current[2]), int.Parse(current[3]), float.Parse(current[4]),
                                        float.Parse(current[5]), current[6], current[7], current[8]);

            weapons.Add(i, weapon);
            Debug.Log(weapons[i].name);*/
        }

        loaded = true;
    }
}
