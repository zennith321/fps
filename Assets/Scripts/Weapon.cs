using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera = null;
    [SerializeField] float range = 100f;
    [SerializeField] float weaponDamage = 1f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        var hasRaycastHit = Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range);
        if (hasRaycastHit)
        {
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            print("I hit this thing:" + hit.transform.name);
            // TODO: add some hit effect for visual players
            if (target == null) return ;
            target.TakeDamage(weaponDamage);
        }
        else
        {
            return;
        }
    }
}
