using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public Vector3 lastPos;
    public Vector3 currentPos;

    public Animator animator;

    private float speed;

    private float dX;
    private float dY;

    private void Start()
    {
        lastPos = transform.position;
        speed = 0;
    }

    private void Update()
    {
        currentPos = transform.position;

        dX = currentPos.x - lastPos.x;
        dY = currentPos.y - lastPos.y;
        speed = Mathf.Sqrt(dX * dX + dY * dY);

        if (speed > .0001) 
        {
            playRunAnimation();
        }
        animator.SetFloat("Speed", speed);
        lastPos = transform.position;
    }

    private void playRunAnimation()
    {
        if (dX >= dY)
        {
            if (dX > 0)
            {
                animator.SetInteger("xVector", 1);
            } 
            else
            {
                animator.SetInteger("xVector", -1);
            }
            animator.SetInteger("yVector", 0);
            return;
        } 
        animator.SetInteger("xVector", 0);
        if (dX > 0)
        {
            animator.SetInteger("yVector", 1);
        }
        else
        {
            animator.SetInteger("yVector", -1);
        }
        return;
    }
}
