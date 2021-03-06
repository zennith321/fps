﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 120f;

    DeathHandler deathHandler;

    void Start()
    {
        deathHandler = FindObjectOfType<DeathHandler>();
    }
    public void ProcessHit(float damage)
    {
        hitPoints -= damage;
        IfDeadKillPlayer();
    }

    void IfDeadKillPlayer()
    {
        if (hitPoints <= 0)
        {
            deathHandler.HandleDeath();
        }     
    }
}
