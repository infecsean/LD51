using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Upgrades : MonoBehaviour
{

    public Transform container;
    public Transform shopItemTemplate;
    private IUpgradeCustomer customer;

    private void Awake()
    {
    }

    private void Start()
    {
        CreateItemButton(Upgrade.UpgradeType.IncreaseRunSpeed, Upgrade.GetSprite(Upgrade.UpgradeType.IncreaseRunSpeed), "Increase Speed", Upgrade.GetCost(Upgrade.UpgradeType.IncreaseRunSpeed), 0);
        CreateItemButton(Upgrade.UpgradeType.IncreaseHoldAmount, Upgrade.GetSprite(Upgrade.UpgradeType.IncreaseHoldAmount), "Expand Slots", Upgrade.GetCost(Upgrade.UpgradeType.IncreaseHoldAmount), 1);
        CreateItemButton(Upgrade.UpgradeType.IncreaseSalary, Upgrade.GetSprite(Upgrade.UpgradeType.IncreaseSalary), "Increase Earn", Upgrade.GetCost(Upgrade.UpgradeType.IncreaseSalary), 2);
        CreateItemButton(Upgrade.UpgradeType.HealthPotion, Upgrade.GetSprite(Upgrade.UpgradeType.HealthPotion), "Health Potion", Upgrade.GetCost(Upgrade.UpgradeType.HealthPotion), 3);
        shopItemTemplate.gameObject.SetActive(false);

        Hide();
    }


    private void CreateItemButton(Upgrade.UpgradeType upgradeType ,Sprite itemSprite, string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();


        float shopItemHeight = 200f;
        shopItemRectTransform.anchoredPosition = new Vector2(650, 400 - shopItemHeight * positionIndex);

        shopItemTransform.Find("UpgradeTitle").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("CostText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());

        shopItemTransform.Find("UpgradeSprite").GetComponent<SpriteRenderer>().sprite = itemSprite;

        shopItemTransform.GetComponent<Button>().onClick.AddListener(() =>
        {
            TryBuyUpgrade(upgradeType);
        });
    }

    private void TryBuyUpgrade(Upgrade.UpgradeType upgradeType)
    {
        customer.BoughtItem(upgradeType);
    }

    public void Show(IUpgradeCustomer customer)
    {
        this.customer = customer;
        Debug.Log(customer);
        Debug.Log("Show!");
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
