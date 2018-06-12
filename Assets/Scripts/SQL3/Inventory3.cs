using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

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
        public int[] playerInvIntArray;
        public int[] equipInvIntArray, quickSelectInvIntArray;
        public GameObject[] playerInvGobjArray, equipInvGobjArray, quickSelectInvGobjArray;

        [Header("Currently Selected Item")]
        public GameObject currentInvGobj;
        public GameObject currentEquipInvGobj, currentQuickSelectInvGobj;
        public GameObject defaultButton;
        public Sprite defaultButtonSprite;

        // Use this for initialization
        void Start()
        {
            defaultButtonSprite = defaultButton.GetComponent<Image>().sprite;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab) && !quickSelect.showSelectMenu)
            {
                mainInvOn = !mainInvOn;
            }

            ShowMainInv();

            if (Input.GetKeyDown(KeyCode.F1))
            {
                for (int i = 0; i < playerInvGobjArray.Length; i++)
                {
                    if (playerInvGobjArray[i].GetComponent<InvButtons>().buttonHasItem == false)
                    {
                        playerInvGobjArray[i].GetComponent<InvButtons>().buttonItemNumber = 1;
                        playerInvGobjArray[i].GetComponent<InvButtons>().buttonHasItem = true;

                        return;
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.F2))
            {
                for (int i = 0; i < playerInvGobjArray.Length; i++)
                {
                    if (playerInvGobjArray[i].GetComponent<InvButtons>().buttonHasItem == false)
                    {
                        playerInvGobjArray[i].GetComponent<InvButtons>().buttonItemNumber = 2;
                        playerInvGobjArray[i].GetComponent<InvButtons>().buttonHasItem = true;

                        return;
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.F3))
            {
                for (int i = 0; i < playerInvGobjArray.Length; i++)
                {
                    if (playerInvGobjArray[i].GetComponent<InvButtons>().buttonHasItem == false)
                    {
                        playerInvGobjArray[i].GetComponent<InvButtons>().buttonItemNumber = 3;
                        playerInvGobjArray[i].GetComponent<InvButtons>().buttonHasItem = true;

                        return;
                    }
                }
            }
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

        public void PlayerInvToEquipButton()
        {
            if (currentInvGobj != null & currentEquipInvGobj != null)
            {
                if (currentInvGobj.GetComponent<InvButtons>().buttonHasItem == true &&
                    currentEquipInvGobj.GetComponent<EqpButtons>().buttonHasItem == false)
                {
                    currentEquipInvGobj.GetComponent<EqpButtons>().buttonItemNumber = currentInvGobj.GetComponent<InvButtons>().buttonItemNumber;
                    currentInvGobj.GetComponent<InvButtons>().buttonItemNumber = 0;

                    currentEquipInvGobj.GetComponent<EqpButtons>().buttonHasItem = true;
                    currentInvGobj.GetComponent<InvButtons>().buttonHasItem = false;
                }
            }
        }

        public void EquipToPlayerInvButton()
        {
            if (currentInvGobj != null & currentEquipInvGobj != null)
            {
                if (currentInvGobj.GetComponent<InvButtons>().buttonHasItem == false &&
                    currentEquipInvGobj.GetComponent<EqpButtons>().buttonHasItem == true)
                {
                    currentInvGobj.GetComponent<InvButtons>().buttonItemNumber = currentEquipInvGobj.GetComponent<EqpButtons>().buttonItemNumber;
                    currentEquipInvGobj.GetComponent<EqpButtons>().buttonItemNumber = 0;

                    currentEquipInvGobj.GetComponent<EqpButtons>().buttonHasItem = false;
                    currentInvGobj.GetComponent<InvButtons>().buttonHasItem = true;
                }
            }
        }
    }
}
