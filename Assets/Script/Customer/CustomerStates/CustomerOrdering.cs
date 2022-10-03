using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrdering : CustomerBaseState
{
    float customerPatience;
    int indexToDisplay;

    public override void EnterState(CustomerStateManager customer)
    {
        customer.button.SetActive(true);
        indexToDisplay = Random.Range(0, customer.drinkPool.Count);
        customer.buttonSprite = customer.drinkPool[indexToDisplay].GetComponent<SpriteRenderer>().sprite;

        //order from customerobject.drinkpool.random
        //start countdown till patience runs out
        customerPatience = customer.customerObject.patience;
    }
    public override void UpdateState(CustomerStateManager customer)
    {
        //Debug.Log("Customer Patience: " + customerPatience);
        if (customerPatience > 0)
        {
            customerPatience -= Time.deltaTime;
        }
        else
        {
            customer.leave = true;
            customer.button.SetActive(false);
            customer.SwitchState(customer.Leaving, 0f);
        }
    }
    public override void OnCollisionEnter(CustomerStateManager customer, Collider2D collision)
    {

    }
}
