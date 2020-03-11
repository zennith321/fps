using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera = null;
    [SerializeField] float range = 100f;
    [SerializeField] float weaponDamage = 1f;
    [SerializeField] ParticleSystem staffVFX;
    [SerializeField] GameObject staffHitFX;
    [SerializeField] Transform vfxParent;
    //[SerializeField] Ammo ammoSlot;
    Ammo ammoSlot;

    void Awake()
    {
        ammoSlot = FindObjectOfType<Ammo>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ammoSlot.GetCurrentAmmo() > 0)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        PlayMuzzleFlash();
        ProcessRaycast();
        ammoSlot.ReduceCurrentAmmo();
    }

    private void PlayMuzzleFlash()
    {
        staffVFX.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        var hasRaycastHit = Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range);
        if (hasRaycastHit)
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(weaponDamage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        var impact = Instantiate(staffHitFX, hit.point, Quaternion.LookRotation(hit.normal), vfxParent);
        Destroy(impact.gameObject, 0.1f); //TODO change 1f to duration of particlesystem
    }
}
