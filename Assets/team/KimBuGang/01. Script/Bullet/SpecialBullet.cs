using UnityEngine;

public enum SpecialBulletType
{
    Default,
    Slow,
    DotDamage,
    Piercing
}
public class SpecialBullet : MonoBehaviour
{
    public SpecialBulletType type;

    public void Damage(Monster monster,int damage)
    {
        switch (type)
        {
            case SpecialBulletType.Slow:
                Slow(monster,damage);
                break;
            case SpecialBulletType.DotDamage:
                DotDamage(monster,damage);
                break;
            case SpecialBulletType.Piercing:
            case SpecialBulletType.Default:
                Default(monster,damage);
                break;
        }
    }
    
    bool canDamage = true;
    int damage = 0;
    Monster monster;
    private void DotDamage(Monster monster, int damage)
    {
        this.damage = damage;
        this.monster = monster;
        InvokeRepeating(nameof(TickDamage), 0.5f,0.5f);
        Invoke(nameof(InvokeCancel), 2f);
    }
    void InvokeCancel()
    {CancelInvoke(nameof(TickDamage));}
    void TickDamage()
    {monster.SetHP(damage);}
    private void Slow(Monster monster, int damage)
    {
        monster.SetSpeed(damage,1.5f);
    }
    private void Default(Monster monster,int damage)
    {
        monster.SetHP(damage);
    }
}
