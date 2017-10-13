using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ScriptableObject , IDamagable,IDamager
{
    public float health;
    public float damage;

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public void DoDamage(IDamagable target)
    {
        target.TakeDamage(damage);
    }
}
