using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Player", order = 0)]
public class Player : ScriptableObject, IDamagable, IDamager
{
    public float damage;
    public float health;
    public float attackRange;

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public void DoDamage(IDamagable target)
    {
        target.TakeDamage(damage);
    }
}