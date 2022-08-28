using UnityEngine;

public class node : MonoBehaviour
{
    public Color changeColorGood;
    public Color changeColorBad;
    private Renderer rend;
    public GameObject turret;
    private Color startColor;
    public Vector3 positionOffset;
    BuildManager buildManager;
    public TurretBluePrint turretBluePrint;
    public bool isUpgrated = false;
    private string[] tags= { "GraundNode", "Node" };
    private string[] turatsTags = { "BlockTurret", "BlockturretUpgrated" };

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    void OnMouseEnter()
    {
        if (!buildManager.canBuild) return;
        if (buildManager.enoughMoney)
        {
            rend.material.color = changeColorGood;
        }
        else rend.material.color = changeColorBad;
        if (turret != null)
        {
            if (turret.tag == turretBluePrint.upgrededPrefarb.tag) isUpgrated = true;
            else isUpgrated = false;
        }
    }

    void OnMouseDown()
    {
        if(turret!=null)
        {
            buildManager.SelectNode(this);
            if (turret != null)
            {
                if (turret.tag == turretBluePrint.upgrededPrefarb.tag) isUpgrated = true;
                else isUpgrated = false;
            }
        }
        if (!buildManager.canBuild)
        {
            return;
        }
        if ((buildManager.GetTurretToBuild().prefarb.tag == buildManager.tags[0] || buildManager.GetTurretToBuild().prefarb.tag == buildManager.tags[1]) && this.tag == tags[1])
            BuildTurret(buildManager.GetTurretToBuild());
        else if (buildManager.GetTurretToBuild().prefarb.tag == buildManager.tags[2] && this.tag == tags[0])
        {
            BuildTurret(buildManager.GetTurretToBuild());
            if (turret != null)
            {
                if (turret.tag == turretBluePrint.upgrededPrefarb.tag) isUpgrated = true;
                else isUpgrated = false;
            }
        }
        else return;
    }

    void BuildTurret(TurretBluePrint bluePrint)
    {
        if (PlayrStats.money < bluePrint.cost)
        {
            Debug.Log("NOT ENOUGH OXYGEN");
            return;
        }
        GameObject turret = (GameObject)Instantiate(bluePrint.prefarb,GetBuildPosition(),transform.rotation);
        this.turret = turret;
        turretBluePrint = bluePrint;
        PlayrStats.money -= bluePrint.cost;
    }

    public void UpgrateTurret()
    {
        if (PlayrStats.money < turretBluePrint.upgrateCost)
        {
            Debug.Log("NOT ENOUGH OXYGEN");
            return;
        }
        Destroy(this.turret);
        GameObject turret = (GameObject)Instantiate(turretBluePrint.upgrededPrefarb, GetBuildPosition(), transform.rotation);
        this.turret = turret;
        isUpgrated = true;
        PlayrStats.money -= turretBluePrint.upgrateCost;
    }

    public void SellTurret()
    {
        if(turret.tag==turatsTags[0]|| turret.tag == turatsTags[1])
        {
            turret.GetComponent<BlockTurret>().CeepMoving();
        }
        Destroy(this.turret);
        this.turret = null;
        if (isUpgrated)
            PlayrStats.money += turretBluePrint.upgrateSellCost;
        else
            PlayrStats.money += turretBluePrint.sellCost;
        isUpgrated = false;    
        
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;   
    }

}
