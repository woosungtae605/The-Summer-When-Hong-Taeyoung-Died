using UnityEngine;

public class NomalBullet : Bullet
{
    [SerializeField] string name;
    public override void Ability()
    {
        Instantiate(gameObject);
    }
}
