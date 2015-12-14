using UnityEngine;
using System.Collections;

public class SH_ResourceBuilding : SH_Building {

    public float ResourcePerSecond;
    public float Asecond = 1;

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
