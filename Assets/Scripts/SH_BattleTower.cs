﻿using UnityEngine;
using System.Collections;
using System;

public class SH_BattleTower : SH_Building {

    public GameObject TargetEnemy;//current enemy being targeted
    
    public GameObject Launcher;// spawn point for projectiles
    public float speed = 6f;
    public float FixedInterval;
    public float ShootInterval = 1;
    public float Range;

    public override void Start()
    {
        base.Start();
        ShootInterval = FixedInterval + UnityEngine.Random.Range(0.01f, 0.05f);

    }

    

    public override void Update()
    {
        base.Update();

        if (CurrentState != BuildingState.Placed)
            return;

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

        ShootInterval = FixedInterval + UnityEngine.Random.Range(0.01f, 0.05f);

        GameObject projectile;

      
        projectile = SH_GameManager.GM.GetAmmo();

        projectile.transform.rotation = transform.rotation;
        projectile.transform.position = Launcher.transform.position;
        
        projectile.GetComponent<SpriteRenderer>().enabled = true;




        return;
    }
        
        
    /// <summary>
    /// find the target that is closest to tower
    /// </summary>
    private void FindTarget()
    {
        if (TargetEnemy != null)// checks if tower has a current target
        {
            if (Vector3.Distance(transform.position, TargetEnemy.transform.position)<= Range)//chackes if targerts is in range
                if (TargetEnemy.GetComponent<SH_Enemey>().Active)// makes sure the target is active
                    return;
        }




        TargetEnemy = SH_GameManager.GM.NewTargetEnemeny(transform.position, Range);
    }

    public override void OnMouseEnter()
    {
        base.OnMouseEnter();

        if (CurrentState == BuildingState.OnMouse)
            return;

        SH_DisplayStats.DS.DisplayLineTwo("Turret Range:", Range);
    }

}
