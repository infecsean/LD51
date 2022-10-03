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
    GameObject objectToRemove;
    int objectIndex;

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
        Debug.Log(customerP);
    }
    public override void UpdateState(CustomerStateManager customer)
    {
        //Debug.Log("Customer Patience: " + customerPatience);
        
        if (customerPatience > 0 && !recievedDrink)
        {
            customerPatience -= Time.deltaTime;
            //what the fuck is this long ass shit? so basically i had to set the width and height of the fillup bar to indicate that patience is running out so yea
            customer.button.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2((customer.button.transform.GetChild(1).GetComponent<RectTransform>().sizeDelta.x/customerP)*customerPatience, (customer.button.transform.GetChild(1).GetComponent<RectTransform>().sizeDelta.y / customerP) * customerPatience);
        }
        else if (!recievedDrink)
        {
            customer.leave = true;
            customer.button.SetActive(false);
            customer.SwitchState(customer.Leaving, 0f);
        }

        if (recievedDrink)
        {
            customer.player.GetComponent<Player>().money += customer.player.GetComponent<Player>().salary;
            customer.SwitchState(customer.Eating, 0f);
        }

    }
    public override void OnCollisionEnter(CustomerStateManager customer, Collider2D collision)
    {

    }
    public override void OnButtonPress(CustomerStateManager customer)
    {
        

        //check drinks on hand, if correct drink in hand, go to eating state, if not, do nothing
        foreach (GameObject obj in customer.player.GetComponent<Player>().HasDrinks())
        {
            //Debug.Log(obj.GetComponent<SpriteRenderer>().sprite.name + ", " + wishDrink.name);
            if (obj.GetComponent<SpriteRenderer>().sprite.name == wishDrink.name)
            {
                objectIndex = customer.player.GetComponent<Player>().drinksInHand.IndexOf(obj);
                objectToRemove = customer.player.GetComponent<Player>().drinksInHand[objectIndex];

                recievedDrink = true;
                if (objectToRemove != null)
                {
                    Object.Destroy(objectToRemove, .1f);

                }
            }
        }

        customer.player.GetComponent<Player>().drinksInHand.Remove(objectToRemove);

    }
}
