using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    EnemyHealth health;
    [SerializeField] Transform[] potentialTargets;
    Transform target;
    public Transform Target { get { return target; } }

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        target = potentialTargets[0];
    }

    void Update()
    {
        if(health.IsDead)
        {
            navMeshAgent.enabled = false;
            enabled = false;
        }
        if(isProvoked)
        {
            distanceToTarget = Vector3.Distance(target.position, transform.position); //Update distance to current target
            EngageTarget();
        }
        else
        {
            FindClosestTarget();    //Consider all potential targets since the enemy isn't provoked yet
            if(distanceToTarget < chaseRange)
            {
                isProvoked = true;
            }
        }

    }

    public void OnDamageTaken()
    {
        isProvoked = true; //Will begin to chase/attack its current target next update
    }

    //Show the chase range when selected
    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    void EngageTarget()
    {
        FaceTarget();
        if(distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        else
        {
            AttackTarget();
        }
    }

    void ChaseTarget()
    {
        GetComponent<Animator>().SetTrigger("Move");
        GetComponent<Animator>().SetBool("Attack", false);
        navMeshAgent.SetDestination(target.position);
    }

    void AttackTarget()
    {
        GetComponent<Animator>().SetBool("Attack", true);
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    void FindClosestTarget()
    {
        foreach (Transform currTarget in potentialTargets)
        {
            if(Vector3.Distance(currTarget.position, transform.position) < distanceToTarget)
            {
                distanceToTarget = Vector3.Distance(currTarget.position, transform.position);
                target = currTarget;
            }
        }
    }
}
