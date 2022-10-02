using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DialogueBaseState
{
    public abstract void EnterState(DialogueManager dialogue);
    public abstract void UpdateState(DialogueManager dialogue);
    public abstract void OnCollisionEnter(DialogueManager dialogue, Collider2D collision);
}
