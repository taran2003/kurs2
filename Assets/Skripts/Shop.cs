using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public TurretBluePrint standardTurret;
    public TurretBluePrint missleLauncherTurret;
    public TurretBluePrint blockTurret;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandartTurret()
    {
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissleLauncherTurret()
    {
        buildManager.SelectTurretToBuild(missleLauncherTurret);
    }

    public void SelectBlockTurret()
    {
        buildManager.SelectTurretToBuild(blockTurret);
    }
}
