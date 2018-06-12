using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

namespace sql3
{
    public class InvButtons : MonoBehaviour
    {
        public bool buttonHasItem;
        public int buttonItemNumber;

        public Inventory3 inv3;
        public InvStats invStats;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (buttonHasItem)
            {
                GetComponent<Image>().sprite = invStats.itemIcons[buttonItemNumber - 1];
            }
        }

        public void InvButtonClicked()
        {
            inv3.currentInvGobj = gameObject;
        }
    }
}
