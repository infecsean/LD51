using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class CustomerStateManager : MonoBehaviour
{
    public CustomerObject customerObject;
    public GameObject exitTarget;
    public GameObject stoolManager;


    [ReadOnly]
    CustomerBaseState currentState;
    CustomerWalking Walking = new CustomerWalking();
    CustomerWalking Leaving = new CustomerWalking();
    CustomerSeated Seated = new CustomerSeated();
    CustomerOrdering Ordering = new CustomerOrdering();
    CustomerEating Eating = new CustomerEating();
    CustomerPaying Paying = new CustomerPaying();

    private void Start()
    {

        currentState = Walking;

        currentState.EnterState(this);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.OnCollisionEnter(this);
    }


    private void Update()
    {
        currentState.UpdateState(this);
    }
}
