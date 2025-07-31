using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public void OnEnable()
    {
        Vector2 Distance = (gameObject.transform.position - Manager.manager.Spwan.First(transform).transform.position).normalized;
        float Lookat = Mathf.Atan2(Distance.y, Distance.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, Lookat);
    }
    public abstract void Ability();
}
