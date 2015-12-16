using UnityEngine;
using System.Collections;

public class SH_Pause : MonoBehaviour {
    /// <summary>
    /// pause or unpauses game when called
    /// </summary>
	public void Pause()
    {
        if (Time.timeScale > 0)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
