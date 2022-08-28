using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private TurretBluePrint turretToBuild;
    private node selectedNode;
    public bool canBuild { get { return turretToBuild != null; } }
    public bool enoughMoney { get { return PlayrStats.money >= turretToBuild.cost; } }
    public NodeUI nodeUI;
    public string[] tags = { "StandartTurret", "MissleLauncherTurret", "BlockTurret" };
    
    public TurretBluePrint GetTurretToBuild()
    {
        return turretToBuild;
    }

    private void Awake()
    {
        if(instance!=null)
        {
            Debug.LogError("More than one BuildManager in scene!");
        }
        instance = this;
    }

    public void SelectNode(node node)
    {
        if (selectedNode == node)
        {
            DiselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;
        nodeUI.SetTarget(node);
    }

    public void DiselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;
        DiselectNode();
    }
}
