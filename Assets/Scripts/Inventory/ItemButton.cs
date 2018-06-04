using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public int itemNumber;
    public bool itemPresent;

    public Text itemName;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (itemPresent == true)
        {
            itemName = gameObject.GetComponentInChildren<Text>();
            itemName.text = "Item # is " + itemNumber.ToString();
        }
    }


}
