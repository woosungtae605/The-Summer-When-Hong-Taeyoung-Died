using UnityEngine;
using UnityEngine.InputSystem;

public class SungtaeTest : MonoBehaviour
{
    private void Update()
    {
        if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            SpawnManager.instance.First(transform);
            Debug.Log(SpawnManager.instance.First(transform));
        }
        if(Keyboard.current.qKey.wasPressedThisFrame)
        {
            SpawnManager.instance.SpawnEnemy(2);
        }
       
    }
}
