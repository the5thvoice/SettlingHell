using UnityEngine;
using System.Collections;

public class SH_HabBuilding : SH_Building {

    /// <summary>
    /// tracks "Health" of building
    /// </summary>
    public float Population;

    public override void Start()
    {
        base.Start();

        if (SH_GameManager.GM.DebugMode)
            MakeViableTarget();

    }

    private void MakeViableTarget()
    {
        if (SH_GameManager.GM.ViableTargets.Contains(gameObject))
            return;

        SH_GameManager.GM.ViableTargets.Add(gameObject);
    }

    public override void OnMouseUp()
    {
        base.OnMouseUp();

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
