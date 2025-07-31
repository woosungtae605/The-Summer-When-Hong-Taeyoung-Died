using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    List<Tower> towers = new List<Tower>();
    public void SpwanTower(Tower target)
    {
        Tower tower = Instantiate(target);
        towers.Add(tower);
    }
    public void Delete(Tower target)
    {
        Destroy(target);
        towers.Remove(target);
    }
}
