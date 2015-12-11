using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SH_SpawnController : MonoBehaviour {

    public static SH_SpawnController SC;
    public GameObject EnemyPrefab; 
    public float WaveCounter;
    public float WaveInterval;
    public float timer;


    public List<GameObject> Enemies
    {
        get
        {
            return SH_GameManager.GM.Enemies;
        }
    } 


    void Awake()
    {
        if (SC== null)
            SC = this;
    }


    public GameObject SpawnEnemy()
    {
        GameObject newEnemy;

        foreach (GameObject enemy in Enemies)
        {
            if (enemy.GetComponent<SH_Enemey>().Active)
                continue;

            return enemy;
        }

        newEnemy = Instantiate(EnemyPrefab) as GameObject;
        return newEnemy;

    }


    public delegate void SpawnWave();
    public static event SpawnWave OnSpawnWave; 

	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {

        if (WaveCounter < 1)//todo: insert win condition here
            return;

        timer += Time.deltaTime;

        if (timer < WaveInterval)
            return;

        WaveCounter--;
        timer = 0;

        OnSpawnWave();

	
	}
}
