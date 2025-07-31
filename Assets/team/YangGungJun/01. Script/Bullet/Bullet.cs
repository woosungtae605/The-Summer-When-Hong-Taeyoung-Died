using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public void OnEnable()
    {
        //가장 가까운 enemy찾아서 그 각도로 쳐다본다
    }
    public abstract void Ability();
}
