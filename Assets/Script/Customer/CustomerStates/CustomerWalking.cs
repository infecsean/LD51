using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerWalking : CustomerBaseState
{
    int indexOfChosenSeat;
    public override void EnterState(CustomerStateManager customer)
    {
        if (customer.button.activeSelf)
        {
            customer.button.SetActive(false);
        }

        if (!customer.leave)
        {
            //Debug.Log(customer.stoolManager.GetComponent<StoolManager>().GetAvailableSeats().Count);
            indexOfChosenSeat = customer.stoolManager.GetComponent<StoolManager>().stools.FindIndex(x => x.Equals(customer.stoolManager.GetComponent<StoolManager>().GetAvailableSeats()[0].gameObject));
            //Debug.Log(indexOfChosenSeat);
            customer.gameObject.GetComponent<Unit>().target = customer.stoolManager.GetComponent<StoolManager>().GetAvailableSeats()[0].transform;
            customer.gameObject.GetComponent<Unit>().Navigate();
            customer.stoolManager.GetComponent<StoolManager>().GetAvailableSeats()[0].gameObject.GetComponent<Stool>().isSeated = true;
        }
        else
        {
            customer.gameObject.GetComponent<Unit>().target = customer.exitTarget.transform;
            customer.gameObject.GetComponent<Unit>().Navigate();
            customer.stoolManager.GetComponent<StoolManager>().stools[indexOfChosenSeat].gameObject.GetComponent<Stool>().isSeated = false;
        }
    }
    public override void UpdateState(CustomerStateManager customer)
    {

    }
    public override void OnCollisionEnter(CustomerStateManager customer, Collider2D collision)
    {
        GameObject other = collision.gameObject;
        
        if (!customer.leave)
        {
            if (other == customer.stoolManager.GetComponent<StoolManager>().stools[indexOfChosenSeat])
            {
                customer.SwitchState(customer.Seated, 0f);
            }
        }
        else
        {
            //Debug.Log(other.name + ", " + customer.exitTarget.name);
            if (other.name == customer.exitTarget.name)
            {
                customer.GoDestroy();
            }
        }
    }
    public override void OnButtonPress(CustomerStateManager customer)
    {

    }
}
