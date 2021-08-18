using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField]int hitPoints = 100;
    public int HitPoints { get { return hitPoints; } }
    bool isDead = false;
    public bool IsDead { get { return isDead; } }

    public void TakeDamage(int damage)
    {
        hitPoints -= Mathf.Abs(damage);
        BroadcastMessage("OnDamageTaken");
        if(hitPoints <= 0)
        {
            Die();
        }
    }

    public void HealDamage(int damage)
    {
        hitPoints += Mathf.Abs(damage);
    }

    void Die()
    {
        if(isDead)
        {
            return;
        }
        GetComponent<Animator>().SetTrigger("Die");
        isDead = true;
    }
}
