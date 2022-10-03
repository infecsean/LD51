using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Money : MonoBehaviour
{
    public GameObject player;
    public Transform moneyText;
    public Transform moneyNum;

    private float money;

    private void Start()
    {
        money = player.GetComponent<Player>().money;
        moneyNum = moneyText.Find("Money");
        moneyNum.GetComponent<TextMeshProUGUI>().SetText($"{money}");
    }

    private void Update()
    {
        money = player.GetComponent<Player>().money;
        moneyNum.GetComponent<TextMeshProUGUI>().SetText($"{money}");
    }
}
