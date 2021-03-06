﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class SH_EndGameMenu : MonoBehaviour {

    public GameObject EndGameMenu;

	// Use this for initialization
	void Start () {

        SH_GameManager.OnLoseCondition += LoseGame;
        SH_GameManager.OnWinCondition += WinGame;
	
	}
    /// <summary>
    /// display game over message
    /// </summary>
    private void LoseGame()
    {
        SH_GameManager.OnLoseCondition -= LoseGame;
        SH_GameManager.OnWinCondition -= WinGame;
        EndGameMenu.SetActive(true);
        EndGameMenu.GetComponentInChildren<Text>().text = "Game Over";

        
    }
    /// <summary>
    /// display wing game message
    /// </summary>
    private void WinGame()
    {
        SH_GameManager.OnLoseCondition -= LoseGame;
        SH_GameManager.OnWinCondition -= WinGame;
        EndGameMenu.SetActive(true);
        EndGameMenu.GetComponentInChildren<Text>().text = "You Win";
        
    }

    public void OnDisable()
    {

        SH_GameManager.OnLoseCondition -= LoseGame;
        SH_GameManager.OnWinCondition -= WinGame;

    }


    
    
	
	
}
