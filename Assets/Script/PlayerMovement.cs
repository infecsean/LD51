using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform player;
    public float walkSpeed;

    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        walkSpeed /= 100;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", (Mathf.Abs(Input.GetAxisRaw("Horizontal")) + Mathf.Abs(Input.GetAxisRaw("Vertical"))));
        animator.SetInteger("XDirection", (int)Input.GetAxisRaw("Horizontal"));

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            animator.SetInteger("YDirection", (int)Input.GetAxisRaw("Vertical"));
        } 
        else
        {
            animator.SetInteger("YDirection", 0);
        }

        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1)
        {
            player.position += new Vector3(Input.GetAxisRaw("Horizontal") * walkSpeed, 0f, 0f);
        }
        else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
        {
            player.position += new Vector3(0f, Input.GetAxisRaw("Vertical") * walkSpeed, 0f);
        }
        

        //Debug.Log(Input.GetAxis("Horizontal") + ", " + Input.GetAxis("Vertical"));

    }
}
