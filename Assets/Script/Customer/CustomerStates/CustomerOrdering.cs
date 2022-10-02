using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrdering : CustomerBaseState
{

    public override void EnterState(CustomerStateManager customer)
    {
        //order from customerobject.drinkpool.random
        //start countdown till patience runs out
    }
    public override void UpdateState(CustomerStateManager customer)
    {
        //maybe ui to indicate time remaining
    }
    public override void OnCollisionEnter(CustomerStateManager customer, Collision2D collision)
    {

    }
}
