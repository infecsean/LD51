using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Health : MonoBehaviour
{
    public GameObject player;
    public Transform healthBar;

    public Transform img;

    private int health;
    private int lastHealth;

    private string path;

    private void Start()
    {
        health = player.GetComponent<Player>().health;

        img = healthBar.Find("HealthBar");
        img.GetComponent<Image>().sprite = Resources.Load<Sprite>("Stuff/Health-Bar-90");
    }

    private void Update()
    {
        health = player.GetComponent<Player>().health;
        if (lastHealth != health && health > 0)
        {
            path = $"Stuff/Health-Bar-{health}";
            img.GetComponent<Image>().sprite = Resources.Load<Sprite>(path);
        }
        else if (lastHealth != health && health < 0)
        {
            path = $"Stuff/Health-Bar-0";
            img.GetComponent<Image>().sprite = Resources.Load<Sprite>(path);
        }

        lastHealth = health;
    }
}
