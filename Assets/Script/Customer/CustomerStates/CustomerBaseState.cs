using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CustomerBaseState
{
    public GameObject target;
    public string dialogue;
    public int waitingInterval;

    public abstract void EnterState(CustomerStateManager customer);
    public abstract void UpdateState(CustomerStateManager customer);
    public abstract void OnCollisionEnter(CustomerStateManager customer);
}
