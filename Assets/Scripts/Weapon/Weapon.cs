using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera fPCamera;
    [SerializeField] ParticleSystem shootVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] Mana manaSlot;
    [SerializeField] ManaType manaType;
    [SerializeField] TextMeshProUGUI manaUI;
    [SerializeField] float range = 100f;
    [SerializeField] int damage = 10;
    [SerializeField] float hitVFXDestroyDelay = 1f;
    [SerializeField] float shootCooldown = 0f;

    bool isActiveWeapon = false;
    bool onCooldown = false;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Shoot());
        }
    }

    public void SetActiveWeaponStatus(bool isActive)
    {
        isActiveWeapon = isActive;
        if(isActive)
        {
            UpdateUI();
        }
    }

    IEnumerator Shoot()
    {
        if(manaSlot.GetCurrentMana(manaType) > 0 && isActiveWeapon && !onCooldown)
        {
            onCooldown = true;

            manaSlot.ReduceCurrentMana(manaType);
            UpdateUI();
            PlayShootVFX();
            ProcessRaycast();

            yield return new WaitForSeconds(shootCooldown);
            onCooldown = false;
        }
    }

    void PlayShootVFX()
    {
        shootVFX.Play();
    }

    void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(fPCamera.transform.position, fPCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

            if (target != null)
            {
                CreateHitImpact(hit);
                target.TakeDamage(damage);
            }
        }
    }

    void CreateHitImpact(RaycastHit hit)
    {
        GameObject vfx = Instantiate(hitVFX, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(vfx, hitVFXDestroyDelay);
    }

    void UpdateUI()
    {
        manaUI.text = manaSlot.GetCurrentMana(manaType).ToString();
    }
}
