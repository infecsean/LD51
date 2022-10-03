using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTrigger : MonoBehaviour
{
    [SerializeField] private UI_Upgrades uiUpgrades;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IUpgradeCustomer customer = collision.GetComponent<IUpgradeCustomer>();
        if (customer != null)
        {
            uiUpgrades.Show(customer);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IUpgradeCustomer customer = collision.GetComponent<IUpgradeCustomer>();
        if (customer != null)
        {
            uiUpgrades.Hide();
        }
    }
}
