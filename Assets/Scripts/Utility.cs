using UnityEngine;
using System.Collections;

public class Utility  {

	

    internal static float RoundToPointFive(float p)
    {
        return p = Mathf.Round(p * 2f) * 0.5f;
    }
}
