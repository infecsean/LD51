using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Upgrade : MonoBehaviour
{
    public enum UpgradeType
    {
        IncreaseRunSpeed,
        IncreaseHoldAmount,
        IncreaseSalary,
        HealthPotion
    }
    

    public static int GetCost(UpgradeType upgradeType)
    {
        switch (upgradeType)
        {
            case UpgradeType.IncreaseRunSpeed:
                return 10;
            case UpgradeType.IncreaseHoldAmount:
                return 21;
            case UpgradeType.IncreaseSalary:
                return 14;
            case UpgradeType.HealthPotion:
                return 7;
            default:
                return 0;
        }
    }

    public static Sprite GetSprite(UpgradeType upgradeType)
    {
        switch (upgradeType)
        {
            case UpgradeType.IncreaseRunSpeed:
                return Resources.Load<Sprite>("Stuff/Yellow_Arrow");
            case UpgradeType.IncreaseHoldAmount:
                return Resources.Load<Sprite>("Stuff/Storage");
            case UpgradeType.IncreaseSalary:
                return Resources.Load<Sprite>("Stuff/Coin");
            case UpgradeType.HealthPotion:
                return Resources.Load<Sprite>("Stuff/Red_Arrow");
            default:
                return Resources.Load<Sprite>("Stuff/Yellow_Arrow");
        }
    }
}
