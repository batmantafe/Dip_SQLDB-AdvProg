using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject rightDoor, leftDoor;

    public Transform rightPos1, rightPos2, leftPos1, leftPos2;

    public bool playerAtDoor;

    public float doorSpeed;

    // Use this for initialization
    void Start()
    {
        playerAtDoor = false;
        doorSpeed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerAtDoor == true)
        {
            rightDoor.transform.position = Vector3.MoveTowards(rightDoor.transform.position, rightPos2.position, doorSpeed * Time.deltaTime);

            leftDoor.transform.position = Vector3.MoveTowards(leftDoor.transform.position, leftPos2.position, doorSpeed * Time.deltaTime);
        }

        else
        {
            rightDoor.transform.position = Vector3.MoveTowards(rightDoor.transform.position, rightPos1.position, doorSpeed * Time.deltaTime);

            leftDoor.transform.position = Vector3.MoveTowards(leftDoor.transform.position, leftPos1.position, doorSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerAtDoor = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerAtDoor = false;
        }
    }
}
