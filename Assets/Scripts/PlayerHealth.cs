using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int healthPoints = 200;

    public void TakeDamage(int damage)
    {
        healthPoints -= Mathf.Abs(damage);
        Debug.Log("Current hp: " + healthPoints);
        
        if(healthPoints <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
