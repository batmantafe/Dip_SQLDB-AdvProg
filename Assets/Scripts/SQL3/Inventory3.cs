using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace sql3
{
    public class Inventory3 : MonoBehaviour
    {
        [Header("Toggling Main Inv On/Off")]
        public bool mainInvOn;
        public QuickSelect quickSelect;
        public GameObject mainInv;
        public MouseLook mouseXLook, mouseYLook;
        public Movement movement;

        [Header("Main Inv Items")]
        public int[] mainInvItemsArray;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab) && !quickSelect.showSelectMenu)
            {
                mainInvOn = !mainInvOn;
            }

            ShowMainInv();
        }

        void ShowMainInv()
        {
            if (mainInvOn)
            {
                mainInv.SetActive(true);

                movement.enabled = false;
                mouseXLook.enabled = false;
                mouseYLook.enabled = false;
            }

            else
            {
                mainInv.SetActive(false);

                movement.enabled = true;
                mouseXLook.enabled = true;
                mouseYLook.enabled = true;
            }
        }
    }
}
