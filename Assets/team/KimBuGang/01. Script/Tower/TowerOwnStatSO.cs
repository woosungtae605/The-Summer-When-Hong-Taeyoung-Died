using UnityEngine;

[CreateAssetMenu(fileName = "TowerOwnStatSO", menuName = "Scriptable Objects/TowerOwnStatSO")]
public class TowerOwnStatSO : ScriptableObject
{
    public string name;
    public GameObject tower;
    public int dmg;
    public float rate;
    public float range;
    public float bulletSpeed;
    public int upgradeCost;
    public int sellCost;
    public Color bulletColor;
}
