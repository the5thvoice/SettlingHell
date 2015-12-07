using UnityEngine;
using System.Collections;
using System;

public class SH_BattleTower : SH_Building {

    public GameObject TargetEnemy;
    public GameObject Ammotype;
    public float speed = 6f;

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
        transform.LookAt(transform.position + new Vector3(0, 0, 1), TargetEnemy.transform.position - transform.position);
        Shoot();

    }

    /// <summary>
    /// fires of a pojectile
    /// </summary>
    private void Shoot()
    {
        GameObject projectile;

        if (SH_GameManager.GM.Ammo.Count < 1)
            projectile = Instantiate(SH_GameManager.GM.AmmoPrefab, transform.position, transform.rotation) as GameObject;


        return;
    }
        
        
    /// <summary>
    /// find the target that is closest to tower
    /// </summary>
    private void FindTarget()
    {
        return;
    }
}
