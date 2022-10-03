using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerEating : CustomerBaseState
{

    public override void EnterState(CustomerStateManager customer)
    {
        customer.button.SetActive(false);
    }
    public override void UpdateState(CustomerStateManager customer)
    {
        if(customer.customerTolerance > 0)
        {
            //for expanding, change value in switch to be a parameter
            customer.SwitchState(customer.Ordering, 10f);
            customer.customerTolerance -= 1;
        }
        else
        {
            customer.SwitchState(customer.Paying, 10f);
        }
    }
    public override void OnCollisionEnter(CustomerStateManager customer, Collider2D collision)
    {

    }

    public override void OnButtonPress(CustomerStateManager customer)
    {
        
    }
}
