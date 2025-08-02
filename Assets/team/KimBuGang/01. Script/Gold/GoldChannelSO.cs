using UnityEngine;

[CreateAssetMenu(fileName =  "GoldChannel", menuName = "Scriptable Objects/GoldChannelSO")]
public class GoldChannelSO : ScriptableObject
{
    [field:SerializeField]public ulong Gold { get; private set; }

    public void ChangeGold(ulong amount, GoldTypeEnum type)
    {
        switch (type)
        {
            case GoldTypeEnum.GET:
                Gold += amount;
                break;
            case GoldTypeEnum.SPEND:
                Gold -= amount;
                break;
            case GoldTypeEnum.CHEAT:
                Gold += amount;
                break;
        }
    }
    public void SetGold()
    {
        Gold = 500;
    }
}
