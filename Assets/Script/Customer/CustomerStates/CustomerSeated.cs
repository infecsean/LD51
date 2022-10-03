using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSeated : CustomerBaseState
{

    public override void EnterState(CustomerStateManager customer)
    {
        int customerDecisionTime = customer.customerObject.decisionTime;

        customer.SwitchState(customer.Ordering, customerDecisionTime);
        
    }
    public override void UpdateState(CustomerStateManager customer)
    {
        
    }
    public override void OnCollisionEnter(CustomerStateManager customer, Collider2D collision)
    {

    }
}
