using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    public GameObject UiLevelUpdate;

    public void Cancel()
    {
        UiLevelUpdate.GetComponentInChildren<TowerUI>()._towerAttack = null;
        UiLevelUpdate.SetActive(false);
    }
}
