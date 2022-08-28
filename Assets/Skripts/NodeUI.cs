using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private node target;
    public GameObject ui;
    public Text upgrateCost;
    public Text sellCost;

    public void SetTarget(node target)
    {
        this.target = target;
        transform.position = target.GetBuildPosition();
        ui.SetActive(true);
        if (target.isUpgrated)
        {
            upgrateCost.text = "MAX";
            sellCost.text = target.turretBluePrint.upgrateSellCost.ToString();
        }
        else
        {
            upgrateCost.text = target.turretBluePrint.upgrateCost.ToString();
            sellCost.text = target.turretBluePrint.sellCost.ToString();
        }
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrate()
    {
        target.UpgrateTurret();
        BuildManager.instance.DiselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DiselectNode();
    }
}
