using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using TMPro;

public class CustomerStateManager : MonoBehaviour
{
    public CustomerObject customerObject;
    public GameObject exitTarget;
    public GameObject stoolManager;
    //public TMPro.TextMeshProUGUI timeLeftIndicator;
    private float timeRemaining;

    [ReadOnly]
    public string currentstate;


    public CustomerBaseState currentState;
    public CustomerWalking Walking = new CustomerWalking();
    public CustomerWalking Leaving = new CustomerWalking();
    public CustomerSeated Seated = new CustomerSeated();
    public CustomerOrdering Ordering = new CustomerOrdering();
    public CustomerEating Eating = new CustomerEating();
    public CustomerPaying Paying = new CustomerPaying();

    private void Start()
    {

        currentState = Walking;

        currentState.EnterState(this);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }


    private void Update()
    {

        currentState.UpdateState(this);
        //timeLeftIndicator.text = timeRemaining.ToString();
        currentstate = currentState.ToString();
    }

    public void SwitchState(CustomerBaseState state, float secondsToWait)
    {
        WaitForSeconds wait = new WaitForSeconds(secondsToWait);

        StartCoroutine(WaitForSomething());
        IEnumerator WaitForSomething()
        {
            yield return wait;

            currentState = state;
            state.EnterState(this);
        }

        
    }
}
