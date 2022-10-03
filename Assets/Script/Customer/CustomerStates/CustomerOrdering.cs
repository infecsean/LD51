using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerOrdering : CustomerBaseState
{
    float customerPatience;
    int indexToDisplay;
    float customerP;
    Sprite wishDrink;

    bool recievedDrink;

    public override void EnterState(CustomerStateManager customer)
    {
        recievedDrink = false;
        customer.button.SetActive(true);
        customer.button.transform.GetChild(1).GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
        indexToDisplay = Random.Range(0, customer.drinkPool.Count);
        //Debug.Log(customer.drinkPool[indexToDisplay].GetComponent<SpriteRenderer>().sprite.name);
        wishDrink = customer.drinkPool[indexToDisplay].GetComponent<SpriteRenderer>().sprite;
        customer.button.transform.GetChild(1).GetComponent<Image>().sprite = customer.drinkPool[indexToDisplay].GetComponent<SpriteRenderer>().sprite;

        //order from customerobject.drinkpool.random
        //start countdown till patience runs out
        customerPatience = customer.customerObject.patience;
        customerP = customerPatience;
    }
    public override void UpdateState(CustomerStateManager customer)
    {
        //Debug.Log("Customer Patience: " + customerPatience);
        
        if (customerPatience > 0)
        {
            customerPatience -= Time.deltaTime;
            //what the fuck is this long ass shit? so basically i had to set the width and height of the fillup bar to indicate that patience is running out so yea
            customer.button.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2((customer.button.transform.GetChild(1).GetComponent<RectTransform>().sizeDelta.x/customerP)*customerPatience, (customer.button.transform.GetChild(1).GetComponent<RectTransform>().sizeDelta.y / customerP) * customerPatience);
        }
        else
        {
            customer.leave = true;
            customer.button.SetActive(false);
            customer.SwitchState(customer.Leaving, 0f);
        }

        if (recievedDrink)
        {
            customer.SwitchState(customer.Eating, 0f);
        }

    }
    public override void OnCollisionEnter(CustomerStateManager customer, Collider2D collision)
    {

    }
    public override void OnButtonPress(CustomerStateManager customer)
    {
        //check drinks on hand, if correct drink in hand, go to eating state, if not, do nothing
        foreach (GameObject obj in customer.player.GetComponent<DrinksInHand>().HasDrinks())
        {
            if (obj.GetComponent<SpriteRenderer>().sprite.name == wishDrink.name)
            {
                //customer.player
                recievedDrink = true;
            }
        }
    }
}
