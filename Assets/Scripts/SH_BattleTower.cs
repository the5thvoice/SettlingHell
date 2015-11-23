using UnityEngine;
using System.Collections;
using System;

public class SH_BattleTower : SH_Building {

    public GameObject TargetEnemy;
    public float speed = 6f;

    public override void Update()
    {
        base.Update();
        FindTarget();
        TrackTarget();

    }

    private void TrackTarget()
    {
        transform.LookAt(transform.position + new Vector3(0, 0, 1), TargetEnemy.transform.position - transform.position);
        

    }
        
        

    private void FindTarget()
    {
        return;
    }
}
