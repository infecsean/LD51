using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform player;
    public float walkSpeed;
    



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1)
        {
            player.position += new Vector3(Input.GetAxisRaw("Horizontal") * walkSpeed, 0f, 0f);
            UpdateRotation();
        }
        else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
        {
            player.position += new Vector3(0f, Input.GetAxisRaw("Vertical") * walkSpeed, 0f);
        }

        //Debug.Log(Input.GetAxis("Horizontal") + ", " + Input.GetAxis("Vertical"));

    }

    private void UpdateRotation()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            player.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            player.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
            return;
    }

}
