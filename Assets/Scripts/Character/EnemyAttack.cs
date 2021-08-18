using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] int damage = 40;

    Transform target;

    public void AttackHitEvent()
    {
        target = GetComponent<AI>().Target;

        if(target == null)
        {
            return;
        }

        target.BroadcastMessage("TakeDamage", damage);
    }
}
