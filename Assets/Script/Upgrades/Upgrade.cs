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
                return (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Art/Upgrades/Yellow_Arrow.png", typeof(Sprite));
            case UpgradeType.IncreaseHoldAmount:
                return (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Art/Upgrades/Storage.png", typeof(Sprite));
            case UpgradeType.IncreaseSalary:
                return (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Art/Upgrades/Coin.png", typeof(Sprite));
            case UpgradeType.HealthPotion:
                return (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Art/Upgrades/Red_Arrow.png", typeof(Sprite));
            default:
                return (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Art/Upgrades/Yellow_Arrow.png", typeof(Sprite));
        }
    }
}
