using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace sql3
{
    public class Chest : MonoBehaviour
    {
        public bool chestIsLarge, chestIsMedium, chestIsSmall;
        public Inventory3 inv3;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            
        }

        void OnTriggerEnter (Collider other)
        {
            Debug.Log(other.gameObject);

            if (other.gameObject.CompareTag("Player"))
            {
                if (chestIsLarge == true)
                {
                    inv3.playerAtLargeChest = true;
                }

                if (chestIsMedium == true)
                {
                    inv3.playerAtMediumChest = true;
                }

                if (chestIsSmall == true)
                {
                    inv3.playerAtSmallChest = true;
                }
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (chestIsLarge == true)
                {
                    inv3.playerAtLargeChest = false;
                }

                if (chestIsMedium == true)
                {
                    inv3.playerAtMediumChest = false;
                }

                if (chestIsSmall == true)
                {
                    inv3.playerAtSmallChest = false;
                }
            }
        }
    }
}
