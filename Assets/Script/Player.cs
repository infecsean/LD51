using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IUpgradeCustomer
{
    public Transform player;
    public int holdCount;
    public float walkSpeed;
    public float salary;
    public int health;

    public float money;

    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        walkSpeed /= 100;
        holdCount = 1;
        salary = 1;
        health = 90;
        money = 3;
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

    public void BoughtItem(Upgrade.UpgradeType upgradeType)
    {
        float cost = Upgrade.GetCost(upgradeType);
        if (cost > money)
        {
            Debug.Log("Failed To Purchase (Cost > Money) " + upgradeType);
            return;
        }

        Debug.Log("Bought Item: " + upgradeType);

        switch (upgradeType)
        {
            case Upgrade.UpgradeType.IncreaseRunSpeed:
                walkSpeed += 0.002f;
                money -= cost;
                return;
            case Upgrade.UpgradeType.IncreaseHoldAmount:
                holdCount += 1;
                money -= cost;
                return;
            case Upgrade.UpgradeType.IncreaseSalary:
                salary += 0.2f;
                money -= cost;
                return;
            case Upgrade.UpgradeType.HealthPotion:
                if (health >= 90 || health < 0)
                {
                    return;
                }
                health += 10;
                money -= cost;
                return;
            default:
                return;
        }
    }
}
