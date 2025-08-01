using UnityEngine;
using TMPro;

public class Gold : MonoBehaviour
{
    public GoldChannelSO _gold;

    private void Update()
    {
        GetComponent<TextMeshProUGUI>().text = _gold.Gold.ToString();
    }
}
