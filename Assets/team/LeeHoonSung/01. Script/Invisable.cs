using UnityEngine;

public class Invisable : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }
}
