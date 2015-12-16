using UnityEngine;
using System.Collections;

public class SH_MenuTransitions : MonoBehaviour {

    /// <summary>
    /// quits to main menu
    /// </summary>
    public void QuitToMain()
    {
        Application.LoadLevel(0);
    }


    public void StartGame()
    {
        Application.LoadLevel(1);
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
