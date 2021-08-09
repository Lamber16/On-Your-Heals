using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]int hitPoints = 100;
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
