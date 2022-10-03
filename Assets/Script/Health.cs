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
        img.GetComponent<Image>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Art/UI/Health-Bar-90.png", typeof(Sprite));
    }

    private void Update()
    {
        health = player.GetComponent<Player>().health;
        if (lastHealth != health)
        {
            path = $"Assets/Art/UI/Health-Bar-{health}.png";
            img.GetComponent<Image>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath(path, typeof(Sprite));
        }
        lastHealth = health;
    }
}
