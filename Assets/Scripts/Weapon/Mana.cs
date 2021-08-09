using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    [SerializeField] int manaAmount = 10;
    [SerializeField] ManaSlot[] manaSlots;

    [System.Serializable]
    class ManaSlot
    {
        public ManaType manaType;
        public int manaAmount;
    }

    void Start() 
    {
    }

    public int GetCurrentMana(ManaType manaType)
    {
       return GetManaSlot(manaType).manaAmount;
    }

    public void ReduceCurrentMana(ManaType manaType)
    {
        GetManaSlot(manaType).manaAmount--;
    }

    public void IncreaseCurrentMana(int amount, ManaType manaType)
    {
        GetManaSlot(manaType).manaAmount += amount;
    }

    ManaSlot GetManaSlot(ManaType manaType)
    {
        foreach(ManaSlot slot in manaSlots)
        {
            if(slot.manaType == manaType)
            {
                return slot;
            }
        }

        return null;
    }
}
