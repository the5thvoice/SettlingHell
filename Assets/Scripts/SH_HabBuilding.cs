﻿using UnityEngine;
using System.Collections;

public class SH_HabBuilding : SH_Building {

    /// <summary>
    /// tracks "Health" of building
    /// </summary>
    public float Population;

    public override void Start()
    {
        base.Start();

        

    }

    /// <summary>
    /// sets the building to be included as a viable target for enemies
    /// </summary>
    private void MakeViableTarget()
    {
        if (SH_GameManager.GM.ViableTargets.Contains(gameObject))
            return;

        SH_GameManager.GM.ViableTargets.Add(gameObject);
    }

    public override void OnMouseUp()
    {
        if (CurrentState == BuildingState.OnMouse)
        {

            if (Cost > SH_GameManager.GM.TotalResource)
            {
                Destroy(gameObject);
                return;
            }

            SH_GameManager.GM.TotalResource -= Cost;
            CurrentState = BuildingState.Placed;
            SH_GameManager.GM.OccupiredGrids.Add(transform.position, gameObject);

        }



        MakeViableTarget();

    }

    public override void Update()
    {
        base.Update();

        if (Population < 1)
            DestroyBuilding();

    }

    /// <summary>
    /// destroys building
    /// </summary>
    private void DestroyBuilding()
    {
        if (SH_GameManager.GM.ViableTargets.Contains(gameObject))
            SH_GameManager.GM.ViableTargets.Remove(gameObject);

        Destroy(gameObject);
    }

    internal void Damage(float Strength)
    {
        Population -= Strength;
    }
}
