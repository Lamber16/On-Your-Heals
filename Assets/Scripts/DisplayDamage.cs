using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{

    [SerializeField] float displayTime = 0.5f;

    Canvas indicator;

    void Start() 
    {
        indicator = GetComponent<Canvas>();
        indicator.enabled = false;
    }

    public void TakeDamage()
    {
        StartCoroutine("FlashIndicator");
    }

    IEnumerator FlashIndicator()
    {
        indicator.enabled = true;
        yield return new WaitForSeconds(displayTime);
        indicator.enabled = false;
    }
}
