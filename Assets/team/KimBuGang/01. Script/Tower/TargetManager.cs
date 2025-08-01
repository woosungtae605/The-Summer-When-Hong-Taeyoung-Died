using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public List<TowerAttack> towers;
    public GameObject testTarget;

    public void AddTower(TowerStats.TowerStat towerStat)
    {
        GameObject tower = Instantiate(towerStat.tower,
            new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0),
            Quaternion.identity);
        if (tower.GetComponent<TowerAttack>().stat == null)
            tower.GetComponent<TowerAttack>().stat = Instantiate(Resources.Load<TowerOwnStatSO>("TowerOwnStat"));
        TowerOwnStatSO towerScript = tower.GetComponent<TowerAttack>().stat;
        towers.Add(tower.GetComponent<TowerAttack>());
        tower.GetComponent<TowerAttack>().target= testTarget;
        towerScript.name = tower.name;
        towerScript.dmg = towerStat.dmg;
        towerScript.rate = towerStat.rate;
        towerScript.range = towerStat.range;
        towerScript.bulletSpeed = towerStat.bulletSpeed;
        towerScript.upgradeCost = towerStat.upgradeCost;
        towerScript.sellCost = towerStat.sellCost;
        towerScript.bulletColor = towerStat.bulletColor;
        tower.transform.GetChild(0).transform.localScale = new Vector2(towerStat.range * 2, towerStat.range * 2);
    }
}