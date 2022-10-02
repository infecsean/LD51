using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerWalking : CustomerBaseState
{
    int indexOfChosenSeat;
    public override void EnterState(CustomerStateManager customer)
    {
        
        //Debug.Log(customer.stoolManager.GetComponent<StoolManager>().GetAvailableSeats().Count);
        indexOfChosenSeat = customer.stoolManager.GetComponent<StoolManager>().stools.FindIndex(x => x.Equals(customer.stoolManager.GetComponent<StoolManager>().GetAvailableSeats()[0]));
        customer.gameObject.GetComponent<Unit>().target = customer.stoolManager.GetComponent<StoolManager>().GetAvailableSeats()[0].transform;
        customer.gameObject.GetComponent<Unit>().Navigate();
        customer.stoolManager.GetComponent<StoolManager>().GetAvailableSeats()[0].gameObject.GetComponent<Stool>().isSeated = true;
    }
    public override void UpdateState(CustomerStateManager customer)
    {

    }
    public override void OnCollisionEnter(CustomerStateManager customer, Collision2D collision)
    {
        GameObject other = collision.gameObject;
        if (other == customer.stoolManager.GetComponent<StoolManager>().stools[indexOfChosenSeat])
        {
            customer.SwitchState(customer.Seated, 0f);
        }
    }
}
