using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [Range(1,9)]
    public int chestMaxItems;

    [Header("Arrays")]
    public GameObject[] cans;

    public List<Items> currentChestItems;

    // Use this for initialization
    void Start()
    {
        SetCans();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetCans()
    {
        for (int can = 0; can < chestMaxItems; can++)
        {
            cans[can].SetActive(true);
        }
    }

    void GenerateChestItems()
    {

    }
}
