using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerWalking : CustomerBaseState
{

    public override void EnterState(CustomerStateManager customer)
    {
        Debug.Log(customer.stoolManager.GetComponent<StoolManager>().GetAvailableSeats().Count);
        customer.gameObject.GetComponent<Unit>().target = customer.stoolManager.GetComponent<StoolManager>().GetAvailableSeats()[0].transform;
        customer.gameObject.GetComponent<Unit>().Navigate();
    }
    public override void UpdateState(CustomerStateManager customer)
    {

    }
    public override void OnCollisionEnter(CustomerStateManager customer)
    {

    }
}
