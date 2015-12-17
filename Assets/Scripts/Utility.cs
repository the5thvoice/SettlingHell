using UnityEngine;
using System.Collections;

/// <summary>
/// Anything in this class are general utility functions that i feel will come in useful in futue projects
/// </summary>
public class Utility  {

	
    /// <summary>
    /// reounds submitted float to nearest .5 
    /// </summary>
    /// <param name="p">float</param>
    /// <returns>float</returns>
    internal static float RoundToPointFive(float p)
    {
        return p = Mathf.Round(p * 2f) * 0.5f;
    }
}
