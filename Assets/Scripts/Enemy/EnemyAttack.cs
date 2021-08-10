using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] int damage = 40;

    AllyHealth target;

    void Start()
    {
        target = FindObjectOfType<AllyHealth>();
    }

    public void AttackHitEvent()
    {
        if(target == null)
        {
            return;
        }

        //FindObjectOfType<DisplayDamage>().TakeDamage();
        target.TakeDamage(damage);
    }
}
