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

    }
    public override void OnCollisionEnter(CustomerStateManager customer, Collider2D collision)
    {

    }

    public override void OnButtonPress(CustomerStateManager customer)
    {
        
    }
}
