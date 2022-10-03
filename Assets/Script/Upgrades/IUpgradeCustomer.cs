using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpgradeCustomer
{
    void BoughtItem(Upgrade.UpgradeType upgradeType);
}
