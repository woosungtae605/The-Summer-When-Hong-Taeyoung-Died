using UnityEngine;

public class YEnemy : MonoBehaviour
{
    public int maxHp = 100;
    private int currentHp;

    public bool IsDead => currentHp <= 0;

    private void Start()
    {
        currentHp = maxHp;
    }

    public void TakeDamage(int damage)
    {
        if (IsDead) return;

        currentHp -= damage;
        if (IsDead)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"{name} 사망!");
        Destroy(gameObject);
    }
}