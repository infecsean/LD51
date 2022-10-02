using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "/Custom Ass/Customer Object")]
public class CustomerObject : ScriptableObject
{
    // Identify Customer
    public Sprite customerSprite;
    public string customerName;


    public List<GameObject> orderPool;
    public int decisionTime; //how long til decide to order. alcoholics 0, children 30, adult 10
    public int patience; //how many intervals waiting
    public int tolerance; //alcoholics have 5, meaning they order 5 refills
    public int tip; //how much they tip, children tip 0, alcoholic tip random, adult tip tolerance amount, 
}
