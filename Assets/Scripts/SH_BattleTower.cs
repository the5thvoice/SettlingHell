﻿using UnityEngine;
using System.Collections;
using System;

public class SH_BattleTower : SH_Building {

    public GameObject TargetEnemy;
    public GameObject Ammotype;
    public float speed = 6f;
    public float FixedInterval;
    public float ShootInterval = 1;

    

    public override void Update()
    {
        base.Update();
        FindTarget();
        TrackTarget();

    }


    /// <summary>
    /// rotates to and tracks current target 
    /// </summary>
    private void TrackTarget()
    {
        if (TargetEnemy == null)
            return;

        transform.LookAt(transform.position + new Vector3(0, 0, 1), TargetEnemy.transform.position - transform.position);
        Shoot();

    }

    /// <summary>
    /// fires of a pojectile
    /// </summary>
    private void Shoot()
    {
        if (ShootInterval > 0)
        {
            ShootInterval -= Time.deltaTime;
            return;
        }

        ShootInterval = FixedInterval;

        GameObject projectile;

      
        projectile = SH_GameManager.GM.GetAmmo();
            
        
        projectile.transform.position = transform.position;
        projectile.transform.rotation = transform.rotation;
        projectile.GetComponent<SpriteRenderer>().enabled = true;




        return;
    }
        
        
    /// <summary>
    /// find the target that is closest to tower
    /// </summary>
    private void FindTarget()
    {
        if(TargetEnemy != null)
            if (TargetEnemy.GetComponent<SH_Enemey>().Active)
                return;

        TargetEnemy = SH_GameManager.GM.NewTargetEnemeny();
    }
}
