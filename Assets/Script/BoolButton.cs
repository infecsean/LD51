using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolButton : MonoBehaviour
{
    [HideInInspector]
    public bool pressed = false;

    private void Start()
    {
        pressed = false;
    }

    public void PressButton()
    {
        pressed = true;
    }
}
