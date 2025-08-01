using UnityEngine;

[CreateAssetMenu(fileName = "TowerStatSO", menuName = "Scriptable Objects/TowerStatSO")]
public class TowerStatSO : ScriptableObject
{
    [TextArea] public string Name;
    public int dmg;
    public float attackSpeed;
    public float Range;
    public int UpdateCost;
    public int SellCost;
}
