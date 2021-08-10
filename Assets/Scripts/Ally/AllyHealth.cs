using UnityEngine;

public class AllyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 100;
    
    int currHitPoints;
    public int CurrHitPoints { get { return currHitPoints; } }
    bool isDead = false;
    public bool IsDead { get { return isDead; } }

    void Start() 
    {
        currHitPoints = maxHitPoints;
    }

    public void TakeDamage(int damage)
    {
        currHitPoints -= Mathf.Abs(damage);
        if(currHitPoints <= 0)
        {
            Die();
        }
    }

    public void HealDamage(int damage)
    {
        if (isDead)
        {
            return;
        }
        currHitPoints = Mathf.Min(currHitPoints+Mathf.Abs(damage), maxHitPoints);
        Debug.Log("Healed to " + currHitPoints);
    }

    void Die()
    {
        if(isDead)
        {
            return;
        }
        //GetComponent<Animator>().SetTrigger("Die");
        isDead = true;
    }
}
