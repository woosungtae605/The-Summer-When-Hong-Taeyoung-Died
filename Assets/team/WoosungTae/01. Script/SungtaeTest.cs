using UnityEngine;
using UnityEngine.InputSystem;

public class SungtaeTest : MonoBehaviour
{
    private void Update()
    {
        if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            SpawnManager.instance.SpawnEnemy(1);
        }
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            SpawnManager.instance.SpawnEnemy(2);
        }
    }
}
