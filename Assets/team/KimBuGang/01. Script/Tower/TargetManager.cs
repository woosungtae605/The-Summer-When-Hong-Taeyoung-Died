using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public List<TowerAttack> towers;
    public List<TargetTrace> targets;

    public static TargetManager Instance;

    private void Awake()
    {
        if  (Instance == null)
            Instance = this;
        else Destroy(this);
    }

    private void Update()
    {
        SetPriority();
        foreach (TowerAttack tower in towers)
            SetTarget(tower);
        
    }

    private void SetPriority()
    {
        if (targets.Count > 1)
        {
            for (int i = 0; i < targets.Count - 1; i++)
                if (targets[i].moveCount < targets[i + 1].moveCount)
                    (targets[i], targets[i + 1]) = (targets[i + 1], targets[i]);
            for (int i = 0; i < targets.Count; i++)
                targets[i].priority = i;
        }
    }

    public void SetTarget(TowerAttack tower)
    {
        List<TargetTrace> targets = new List<TargetTrace>();
        foreach (var target in this.targets)
            if (math.distance(target.transform.position, tower.transform.position) < tower.stat.range)
                targets.Add(target);
        TargetTrace finalTarget = null;
        foreach (var target in targets)
        {
            if (finalTarget == null)
                finalTarget = target;
            else if (finalTarget.priority > target.priority)
                finalTarget = target;
        }
        tower.target = finalTarget == null? null : finalTarget.gameObject;
    }
    
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
        tower.GetComponent<TowerAttack>().target= null;
        towerScript.icon = towerStat.icon;
        towerScript.name = towerStat.name;
        towerScript.dmg = towerStat.dmg;
        towerScript.rate = towerStat.rate;
        towerScript.range = towerStat.range;
        towerScript.bulletSpeed = towerStat.bulletSpeed;
        towerScript.upgradeCost = towerStat.upgradeCost;
        towerScript.sellCost = towerStat.sellCost;
        towerScript.bullet = towerStat.bullet;
        towerScript.lvl = 1;
        tower.transform.GetChild(0).transform.localScale = new Vector2(towerStat.range * 2, towerStat.range * 2);
        tower.transform.GetChild(0).gameObject.SetActive(false);
        tower.GetComponent<MouseFollow>().enabled = false;
    }
}