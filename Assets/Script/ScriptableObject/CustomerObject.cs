using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Custom Ass/Customer Object")]
public class CustomerObject : ScriptableObject
{
    // Identify Customer
    public Sprite customerSprite;
    public string customerName;


    public GameObject[] orderPool;
    public int patience; //how many intervals waiting
    public int tolerance; //alcoholics have 5, meaning they order 5 refills
    public int tip;
    public CustomerBaseState state;
}
