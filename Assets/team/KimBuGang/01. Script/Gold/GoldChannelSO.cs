using UnityEngine;

[CreateAssetMenu(fileName =  "GoldChannel", menuName = "Scriptable Objects/GoldChannelSO")]
public class GoldChannelSO : ScriptableObject
{
    [field:SerializeField]public ulong Gold { get; private set; }

    public void ChangeGold(int amount, GoldTypeEnum type)
    {
        switch (type)
        {
            case GoldTypeEnum.GET:
                Gold += (ulong)amount;
                break;
            case GoldTypeEnum.SPEND:
                if (Gold >= (ulong)amount)
                    Gold = (ulong)((int)Gold - amount);
                break;
            case GoldTypeEnum.CHEAT:
                Gold += (ulong)amount;
                break;
        }
    }
    public void SetGold()
    {
        Gold = 500;
    }
}
