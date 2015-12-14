using UnityEngine;
using System.Collections;
/// <summary>
/// controls how much resourse the resource generates
/// </summary>
public class SH_ResourceBuilding : SH_Building {

    public float ResourcePerSecond;
    public float Asecond = 1;

    /// <summary>
    /// acceses the total resourse feild in the game manager
    /// </summary>
    public float TotalResource
    {
        get
        {
            return SH_GameManager.GM.TotalResource;
        }
        set
        {
            SH_GameManager.GM.TotalResource = value;
        }
    }

    public override void Update()
    {
        base.Update();

        Asecond -= Time.deltaTime;

        if (Asecond > 0)
            return;

        Asecond = 1;

        TotalResource += ResourcePerSecond;


    }

}
