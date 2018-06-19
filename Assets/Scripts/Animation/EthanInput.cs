using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EthanInput : MonoBehaviour
{
    [Header("Float Positions")]
    public float ethanMoveHorizontal;
    public float ethanMoveFwd;
    public float ethanCurrentY;
    public float ethanJumpHeight;
    public float ethanSetY;

    [Header("Animator")]
    public Animator ethanAnim;

    // Use this for initialization
    void Start()
    {
        ethanJumpHeight = 1;
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

        ethanCurrentY = transform.position.y;
        ethanAnim.SetFloat("EVerticalY", ethanCurrentY);

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!ethanAnim.GetBool("isJumping"))
            {
                ethanSetY = transform.position.y;

                ethanAnim.SetBool("isJumping", true);
            }
        }

        /*if (ethanCurrentY > ethanSetY + ethanJumpHeight)
        {
            ethanAnim.SetBool("isJumping", false);
        }*/
    }

    /*IEnumerator Jump()
    {
        ethanAnim.SetBool("isJumping", true);

        yield return new WaitForSeconds(2);

        ethanAnim.SetBool("isJumping", false);
    }*/
}
