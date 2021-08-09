using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;

    Transform[] weapons;

    void Start()
    {
        SetWeaponActive();
    }

    void Update()
    {
        int previousWeapon = currentWeapon;
        ProcessKeyInput();
        ProcessScrollWheel();

        if(previousWeapon != currentWeapon)
        {
            SetWeaponActive();
        }
    }

    void ProcessKeyInput()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }
        
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }
    }

    void ProcessScrollWheel()
    {
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            currentWeapon = (currentWeapon+1) % transform.childCount;
        }

        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if(currentWeapon == 0)
            {
                currentWeapon = transform.childCount - 1;
            }
            else
            {
                currentWeapon--;
            }
        }
    }

    void SetWeaponActive()
    {
        int weaponIndex = 0;
        Weapon myWeapon;
        WeaponZoom zoom;

        foreach (Transform weapon in transform)
        {
            myWeapon = weapon.GetComponent<Weapon>();
            zoom = weapon.GetComponent<WeaponZoom>();
            if(myWeapon != null)
            {
                MeshRenderer meshRenderer = weapon.GetComponent<MeshRenderer>();
                if (weaponIndex == currentWeapon)
                {
                    meshRenderer.enabled = true;
                    myWeapon.SetActiveWeaponStatus(true);
                    if(zoom != null)
                    {
                        zoom.enabled = true;
                    }
                    
                }
                else
                {
                    meshRenderer.enabled = false;
                    myWeapon.SetActiveWeaponStatus(false);
                    if(zoom != null)
                    {
                        zoom.enabled = false;
                    }
                    else
                    {
                        
                    }
                }
            }

            weaponIndex++;
        }
    }
}
