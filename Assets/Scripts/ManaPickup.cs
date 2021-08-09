using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPickup : MonoBehaviour
{
    [SerializeField] int manaAmount = 10;
    [SerializeField] ManaType manaType;

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<Mana>().IncreaseCurrentMana(manaAmount, manaType);
            Destroy(gameObject);
        }
    }
}
