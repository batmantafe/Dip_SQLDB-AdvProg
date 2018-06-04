using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EthanInput : MonoBehaviour
{
    public float ethanMoveHorizontal;
    public float ethanMoveFwd;
    public Animator ethanAnim;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        EthanInputFunction();
    }

    void EthanInputFunction()
    {
        // Horizontal Movement
        ethanMoveHorizontal = Input.GetAxis("Horizontal");
        ethanMoveFwd = Input.GetAxis("Vertical");

        ethanAnim.SetFloat("EForward", ethanMoveFwd);
        ethanAnim.SetFloat("EHorizontal", ethanMoveHorizontal);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            ethanAnim.SetBool("isRunning", true);
        }
        else
        {
            ethanAnim.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (ethanAnim.GetBool("isCrouching"))
            {
                ethanAnim.SetBool("isCrouching", false);
            }
            else
            {
                ethanAnim.SetBool("isCrouching", true);
            }
        }
    }
}
